using System;
using Aspire.Hosting;
using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);

// Sql:Mode picks where the databases live. Only Existing is built so far.
var sqlMode = builder.Configuration["Sql:Mode"] ?? "Existing";
if (!string.Equals(sqlMode, "Existing", StringComparison.OrdinalIgnoreCase))
{
    throw new NotSupportedException($"Sql:Mode '{sqlMode}' is not supported yet. Use 'Existing'.");
}

var catalogConnection = builder.Configuration["ConnectionStrings:catalog"]
    ?? throw new InvalidOperationException("ConnectionStrings:catalog is missing.");
var ordersConnection = builder.Configuration["ConnectionStrings:orders"]
    ?? throw new InvalidOperationException("ConnectionStrings:orders is missing.");

var catalog = builder.AddProject<Projects.Cat_Demo_CatalogService_Api>("catalog")
    .WithHttpEndpoint(port: 5101, name: "http", isProxied: false)
    .WithEnvironment("ConnectionStrings__catalog", catalogConnection)
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.Cat_Demo_OrderService_Api>("orders")
    .WithHttpEndpoint(port: 5102, name: "http", isProxied: false)
    .WithEnvironment("ConnectionStrings__orders", ordersConnection)
    .WithReference(catalog)
    .WaitFor(catalog)
    .WithHttpHealthCheck("/health");

builder.Build().Run();
