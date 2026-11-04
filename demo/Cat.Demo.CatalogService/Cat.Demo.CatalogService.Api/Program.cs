using System;
using Cat.Commands.Decorators.Logging.Extensions;
using Cat.Commands.Extensions;
using Cat.Demo.CatalogService.Api.Extensions;
using Cat.Demo.CatalogService.CoreService.ServiceRequestHandlers;
using Cat.Demo.CatalogService.CoreService.Validators;
using Cat.Demo.CatalogService.Infrastructure.CommandHandlers;
using Cat.Demo.CatalogService.Infrastructure.Extensions;
using Cat.Demo.CatalogService.Infrastructure.QueryHandlers;
using Cat.Expressions.Extensions;
using Cat.Minimal.Api.Extensions;
using Cat.Queries.Decorators.Logging.Extensions;
using Cat.Queries.Extensions;
using Cat.ServiceRequests.Decorators.Logging.Extensions;
using Cat.ServiceRequests.Decorators.Validation.Extensions;
using Cat.ServiceRequests.Extensions;
using Cat.Validators.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddCatMinimalApiModule();
builder.Services.AddCatCompiledMemberExpressionCache();
builder.Services.AddCatValidatorsModule(typeof(BookSaveRequestValidator));
builder.Services.AddCatServiceRequestsModule(typeof(BookGetRequestHandler));
builder.Services.AddCatQueriesModule(typeof(BookGetQueryHandler));
builder.Services.AddCatCommandsModule(typeof(BookSaveCommandHandler));

var connectionString = builder.Configuration.GetConnectionString("catalog")
    ?? throw new InvalidOperationException("Connection string 'catalog' is missing.");
builder.Services.AddCatDemoCatalogDatabase(connectionString);

var app = builder.Build();
app.UseCatMinimalApiModule();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    await app.Services.InitializeCatalogDatabaseAsync();
}

app.UseHttpsRedirection();

app.MapCatalogServiceEndpoints();
app.Services.AddCatServiceRequestsModuleValidationDecorator();
app.Services.AddCatServiceRequestsModuleLoggingDecorator();
app.Services.AddCatQueriesModuleLoggingDecorator();
app.Services.AddCatCommandsModuleLoggingDecorator();

app.Run();
