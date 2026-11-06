using System;
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

// Orders asks Catalog for prices through the gateway, so it references the gateway and not Catalog.
// The gateway waits for Orders, so Orders must not wait for the gateway.
var orders = builder.AddProject<Projects.Cat_Demo_OrderService_Api>("orders")
    .WithHttpEndpoint(port: 5102, name: "http", isProxied: false)
    .WithReference(payment)
    .WaitFor(payment)
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

// The gateway is the single front door. The services are found by name through service discovery.
var authority = $"http://localhost:{keycloakPort}/realms/cat-demo";
catalog.WithEnvironment("Authentication__Authority", authority);
orders.WithEnvironment("Authentication__Authority", authority);
const int gatewayPort = 5100;
const int webPort = 5104;
var gatewayUrl = $"http://localhost:{gatewayPort}";
var webUrl = $"http://localhost:{webPort}";
var gateway = builder.AddProject<Projects.Cat_Demo_Api_Gateway>("gateway")
    .WithHttpEndpoint(port: gatewayPort, name: "http", isProxied: false)
    .WithReference(catalog)
    .WithReference(orders)
    .WaitFor(catalog)
    .WaitFor(orders)
    .WaitFor(keycloak)
    .WithEnvironment("CatGateway__Services__catalog__Address", "http://catalog")
    .WithEnvironment("CatGateway__Services__orders__Address", "http://orders")
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
}
else
{
    var catalogConnection = builder.Configuration["ConnectionStrings:catalog"]
        ?? throw new InvalidOperationException("ConnectionStrings:catalog is missing.");
    var ordersConnection = builder.Configuration["ConnectionStrings:orders"]
        ?? throw new InvalidOperationException("ConnectionStrings:orders is missing.");

    catalog.WithEnvironment("ConnectionStrings__catalog", catalogConnection);
    orders.WithEnvironment("ConnectionStrings__orders", ordersConnection);
}

builder.Build().Run();
