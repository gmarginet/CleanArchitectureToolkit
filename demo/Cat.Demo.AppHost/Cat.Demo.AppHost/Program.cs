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

var orders = builder.AddProject<Projects.Cat_Demo_OrderService_Api>("orders")
    .WithHttpEndpoint(port: 5102, name: "http", isProxied: false)
    .WithReference(catalog)
    .WaitFor(catalog)
    .WithHttpHealthCheck("/health");

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
