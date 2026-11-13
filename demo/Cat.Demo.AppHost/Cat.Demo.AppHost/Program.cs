using System;
using System.IO;
using System.Linq;
using System.Text;
using Aspire.Hosting;
using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);

// Sql:Mode picks where the databases live.
// Container starts a SQL Server container. Existing uses the connection strings from the configuration.
var sqlMode = builder.Configuration["Sql:Mode"] ?? "Container";
var useContainer = sqlMode.Equals("Container", StringComparison.OrdinalIgnoreCase);
if (!useContainer && !sqlMode.Equals("Existing", StringComparison.OrdinalIgnoreCase))
{
    throw new NotSupportedException($"Sql:Mode '{sqlMode}' is not supported. Use 'Container' or 'Existing'.");
}

var catalog = builder.AddProject<Projects.Cat_Demo_CatalogService_Api>("catalog")
    .WithHttpEndpoint(port: 5101, name: "http", isProxied: false)
    .WithHttpHealthCheck("/health");

// The payment service can fail on purpose. Set Payment:Latency, Payment:ErrorPercentage or Payment:Outage in the
// configuration of the AppHost (for example in the user secrets) and restart. The demo readme explains the values.
var payment = builder.AddProject<Projects.Cat_Demo_PaymentService_Api>("payment")
    .WithHttpEndpoint(port: 5103, name: "http", isProxied: false)
    .WithHttpHealthCheck("/health");

foreach (var (setting, variable) in new[]
{
    ("Payment:Latency", "PaymentFailures__Latency"),
    ("Payment:ErrorPercentage", "PaymentFailures__ErrorPercentage"),
    ("Payment:Outage", "PaymentFailures__Outage")
})
{
    var value = builder.Configuration[setting];
    if (!string.IsNullOrWhiteSpace(value))
    {
        payment.WithEnvironment(variable, value);
    }
}

// Inventory is the database first service. Its database comes from the SQL scripts of the Database folder.
var inventory = builder.AddProject<Projects.Cat_Demo_InventoryService_Api>("inventory")
    .WithHttpEndpoint(port: 5105, name: "http", isProxied: false)
    .WithHttpHealthCheck("/health");

// Notifications sends the order confirmed mail. It has no route in the gateway, because only messages reach it.
// Mailpit is a small SMTP server that keeps every mail in a web inbox at http://localhost:8025. Nothing leaves the machine.
const int smtpPort = 1025;
const int mailInboxPort = 8025;
var mailpit = builder.AddContainer("mailpit", "axllent/mailpit")
    .WithEndpoint(port: smtpPort, targetPort: 1025, name: "smtp", scheme: "tcp", isProxied: false)
    .WithHttpEndpoint(port: mailInboxPort, targetPort: 8025, name: "http", isProxied: false);
var notifications = builder.AddProject<Projects.Cat_Demo_NotificationService_Api>("notifications")
    .WithHttpEndpoint(port: 5106, name: "http", isProxied: false)
    .WithHttpHealthCheck("/health")
    .WithEnvironment("Smtp__Host", "localhost")
    .WithEnvironment("Smtp__Port", smtpPort.ToString())
    .WaitFor(mailpit);

// Orders asks Catalog for prices and the payment service for payments through the gateway, so it references the gateway
// and not the services.
// The gateway waits for Orders, so Orders must not wait for the gateway.
var orders = builder.AddProject<Projects.Cat_Demo_OrderService_Api>("orders")
    .WithHttpEndpoint(port: 5102, name: "http", isProxied: false)
    .WithHttpHealthCheck("/health");

// Keycloak is the identity provider of the demo. The realm file is imported at the first start.
// The admin console is at http://localhost:8180 (admin / admin). Do not use these settings outside the demo.
const int keycloakPort = 8180;
var keycloak = builder.AddContainer("keycloak", "quay.io/keycloak/keycloak", "26.5")
    .WithHttpEndpoint(port: keycloakPort, targetPort: 8080, name: "http", isProxied: false)
    .WithEnvironment("KC_BOOTSTRAP_ADMIN_USERNAME", "admin")
    .WithEnvironment("KC_BOOTSTRAP_ADMIN_PASSWORD", "admin")
    .WithBindMount("keycloak/cat-demo-realm.json", "/opt/keycloak/data/import/cat-demo-realm.json", isReadOnly: true)
    .WithArgs("start-dev", "--import-realm");

// The Azure Service Bus emulator carries the messages between the services. It runs in Docker with its own SQL Server container.
// The entities are not declared here. Orders creates the topic of its messages at startup, and Inventory creates its subscription,
// because the emulator forgets its entities at every restart. Creating them takes the administration client, which uses the
// management port 5300 of the emulator. The ports are fixed, so the services can reach both.
// The key is the fixed development key of the emulator. Do not use these settings outside the demo.
const int serviceBusPort = 5672;
const int serviceBusManagementPort = 5300;
const string serviceBusAdministrationConnection =
    "Endpoint=sb://localhost:5300;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;";
var bus = builder.AddAzureServiceBus("messaging")
    .RunAsEmulator(emulator =>
    {
        emulator.WithHostPort(serviceBusPort);
        emulator.WithEndpoint(port: serviceBusManagementPort, targetPort: 5300, name: "management", scheme: "http", isProxied: false);
    });

// Orders publishes OrderConfirmed through its outbox. Inventory listens to it, so it waits for Orders, which creates the topic.
orders.WithReference(bus)
    .WaitFor(bus)
    .WithEnvironment("Messaging__AdministrationConnectionString", serviceBusAdministrationConnection);
inventory.WithReference(bus)
    .WaitFor(bus)
    .WaitFor(orders)
    .WithEnvironment("Messaging__AdministrationConnectionString", serviceBusAdministrationConnection);
notifications.WithReference(bus)
    .WaitFor(bus)
    .WaitFor(orders)
    .WithEnvironment("Messaging__AdministrationConnectionString", serviceBusAdministrationConnection);

// The gateway is the single front door. The services are found by name through service discovery.
var authority = $"http://localhost:{keycloakPort}/realms/cat-demo";
catalog.WithEnvironment("Authentication__Authority", authority);
orders.WithEnvironment("Authentication__Authority", authority);
payment.WithEnvironment("Authentication__Authority", authority);
inventory.WithEnvironment("Authentication__Authority", authority);
// Orders asks Keycloak for a token of its own when a call has no user, such as a job of the Scheduler.
// The secret is the one in the realm file. Do not use these settings outside the demo.
orders.WithEnvironment("Authentication__ClientId", "cat-demo-orders");
orders.WithEnvironment("Authentication__ClientSecret", "cat-demo-orders-secret");
const int gatewayPort = 5100;
const int webPort = 5104;
var gatewayUrl = $"http://localhost:{gatewayPort}";
var webUrl = $"http://localhost:{webPort}";
var gateway = builder.AddProject<Projects.Cat_Demo_Api_Gateway>("gateway")
    .WithHttpEndpoint(port: gatewayPort, name: "http", isProxied: false)
    .WithReference(catalog)
    .WithReference(orders)
    .WithReference(payment)
    .WithReference(inventory)
    .WaitFor(catalog)
    .WaitFor(orders)
    .WaitFor(payment)
    .WaitFor(inventory)
    .WaitFor(keycloak)
    .WithEnvironment("CatGateway__Services__catalog__Address", "http://catalog")
    .WithEnvironment("CatGateway__Services__orders__Address", "http://orders")
    .WithEnvironment("CatGateway__Services__payment__Address", "http://payment")
    .WithEnvironment("CatGateway__Services__inventory__Address", "http://inventory")
    .WithEnvironment("CatGateway__Authentication__Authority", authority)
    .WithEnvironment("CatGateway__Cors__AllowedOrigins__0", webUrl)
    .WithHttpHealthCheck("/health");
orders.WithReference(gateway);

// The React client runs with Vite. The port is fixed, because the gateway lists it as an allowed CORS origin.
// The page reads the VITE_ variables when it starts.
builder.AddViteApp("web", "../../Cat.Demo.WebClient/Cat.Demo.WebClient.App")
    .WithEndpoint("http", endpoint =>
    {
        endpoint.Port = webPort;
        endpoint.IsProxied = false;
    })
    .WithEnvironment("VITE_GATEWAY_URL", gatewayUrl)
    .WithEnvironment("VITE_AUTHORITY", authority)
    .WaitFor(gateway);

if (useContainer)
{
    // The data volume keeps the databases when the container is removed.
    // The memory limit stops SQL Server from taking all the memory it can get.
    var sql = builder.AddSqlServer("sql")
        .WithDataVolume("cat-demo-sql-data")
        .WithEnvironment("MSSQL_MEMORY_LIMIT_MB", "2048");

    // The resource names must differ from the project names. The connection names stay catalog and orders,
    // because the services read GetConnectionString("catalog") and GetConnectionString("orders").
    var catalogDb = sql.AddDatabase("catalog-db", databaseName: "catalog");
    var ordersDb = sql.AddDatabase("orders-db", databaseName: "orders");

    catalog.WithReference(catalogDb, connectionName: "catalog").WaitFor(catalogDb);
    orders.WithReference(ordersDb, connectionName: "orders").WaitFor(ordersDb);

    var notificationsDb = sql.AddDatabase("notifications-db", databaseName: "notifications");
    notifications.WithReference(notificationsDb, connectionName: "notifications").WaitFor(notificationsDb);

    // The inventory database is database first. The creation script creates the database and runs the SQL scripts
    // of the Database folder. The scripts only create what is missing, so they can run at every start.
    var inventoryDb = sql.AddDatabase("inventory-db", databaseName: "inventory")
        .WithCreationScript(BuildInventoryCreationScript(builder.AppHostDirectory));
    inventory.WithReference(inventoryDb, connectionName: "inventory").WaitFor(inventoryDb);
}
else
{
    var catalogConnection = builder.Configuration["ConnectionStrings:catalog"]
        ?? throw new InvalidOperationException("ConnectionStrings:catalog is missing.");
    var ordersConnection = builder.Configuration["ConnectionStrings:orders"]
        ?? throw new InvalidOperationException("ConnectionStrings:orders is missing.");
    var notificationsConnection = builder.Configuration["ConnectionStrings:notifications"]
        ?? throw new InvalidOperationException("ConnectionStrings:notifications is missing.");

    // The owner of an existing inventory database owns its schema. In this mode the AppHost does not run the scripts.
    var inventoryConnection = builder.Configuration["ConnectionStrings:inventory"]
        ?? throw new InvalidOperationException("ConnectionStrings:inventory is missing.");

    catalog.WithEnvironment("ConnectionStrings__catalog", catalogConnection);
    orders.WithEnvironment("ConnectionStrings__orders", ordersConnection);
    notifications.WithEnvironment("ConnectionStrings__notifications", notificationsConnection);
    inventory.WithEnvironment("ConnectionStrings__inventory", inventoryConnection);
}

builder.Build().Run();

// Builds one script that creates the inventory database and applies the SQL scripts of the Database folder in name order.
// Aspire sends the script as a single batch, so the GO lines that separate batches in the files are left out.
// A batch cannot switch to a database that it creates itself, so every file runs through EXEC, in the new database.
static string BuildInventoryCreationScript(string appHostDirectory)
{
    var scriptsDirectory = Path.GetFullPath(Path.Combine(
        appHostDirectory, "..", "..", "Cat.Demo.InventoryService", "Cat.Demo.InventoryService.Database"));

    var script = new StringBuilder();
    script.AppendLine("IF DB_ID(N'inventory') IS NULL CREATE DATABASE [inventory];");

    foreach (var file in Directory.GetFiles(scriptsDirectory, "*.sql").OrderBy(path => path, StringComparer.Ordinal))
    {
        var content = string.Join(
            Environment.NewLine,
            File.ReadAllLines(file).Where(line => !line.Trim().Equals("GO", StringComparison.OrdinalIgnoreCase)));

        script.AppendLine($"EXEC (N'USE [inventory];{Environment.NewLine}{content.Replace("'", "''")}');");
    }

    return script.ToString();
}
