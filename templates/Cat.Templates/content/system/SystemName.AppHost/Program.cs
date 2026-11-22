using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

// The services have no launch settings, so the AppHost says that they run in Development.
// That is where they apply their migrations and create the topics of the bus.

#if (SqlServer)
// The memory limit stops SQL Server from taking all the memory it can get.
var sql = builder.AddSqlServer("sql")
    .WithEnvironment("MSSQL_MEMORY_LIMIT_MB", "2048");

// The resource names must differ from the project names. The connection name stays servicelower,
// because the service reads GetConnectionString("servicelower").
var database = sql.AddDatabase("servicelower-db", databaseName: "servicelower");
#if (DatabaseFirst)

// The schema of the service is the SQL project SystemName.ServiceShort.Database. The AppHost builds it and deploys it to the database.
var schema = builder.AddSqlProject<Projects.PROJECTS_SYSTEM_ServiceShort_Database>("servicelower-schema")
    .WithReference(database);
#endif
#else
#if (DatabaseFirst)
// The schema of the service is the plain scripts in SystemName.ServiceShort.Database/Scripts. PostgreSQL runs them when the container
// starts for the first time, in the default database, so the default database gets the name of the database of the service.
var postgres = builder.AddPostgres("postgres")
    .WithEnvironment("POSTGRES_DB", "servicelower")
    .WithInitFiles("../SystemName.ServiceShort.Database/Scripts");

// The database exists already, so the creation script of Aspire has nothing to create.
var database = postgres.AddDatabase("servicelower-db", databaseName: "servicelower")
    .WithCreationScript("SELECT 1;");
#else
var postgres = builder.AddPostgres("postgres");
var database = postgres.AddDatabase("servicelower-db", databaseName: "servicelower");
#endif
#endif

#if (Messages)
// The Azure Service Bus emulator carries the messages of the service. It runs in Docker with its own SQL Server container.
// The service creates its own topics and subscription at startup in Development, because the emulator forgets its entities
// at every restart. Creating them takes the administration client, which uses the management port 5300 of the emulator.
// The key is the fixed development key of the emulator. Do not use these settings outside development.
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

#endif
var service = builder.AddProject<Projects.PROJECTS_SYSTEM_ServiceShort_Api>("servicelower")
    .WithEnvironment("ASPNETCORE_ENVIRONMENT", "Development")
    .WithHttpEndpoint(name: "http")
    .WithHttpHealthCheck("/health")
    .WithReference(database, connectionName: "servicelower")
#if (DatabaseFirst && SqlServer)
    .WaitForCompletion(schema)
#else
    .WaitFor(database)
#endif
#if (Messages)
    .WithReference(bus)
    .WaitFor(bus)
    .WithEnvironment("Messaging__AdministrationConnectionString", serviceBusAdministrationConnection)
#endif
    ;

// The gateway is the front door of the system. It finds the service by name through service discovery.
// Fill in the identity provider in appsettings.json of the gateway. Until then, the gateway rejects every call.
builder.AddProject<Projects.PROJECTS_SYSTEM_Api_Gateway>("gateway")
    .WithEnvironment("ASPNETCORE_ENVIRONMENT", "Development")
    .WithHttpEndpoint(name: "http")
    .WithHttpHealthCheck("/health")
    .WithReference(service)
    .WaitFor(service);

builder.Build().Run();
