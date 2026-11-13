using System;
using Cat.Commands.Decorators.Logging.Extensions;
using Cat.Commands.Extensions;
using Cat.Demo.InventoryService.Api.Extensions;
using Cat.Demo.InventoryService.CoreService.ServiceRequestHandlers;
using Cat.Demo.InventoryService.CoreService.Validators;
using Cat.Demo.InventoryService.Infrastructure.CommandHandlers;
using Cat.Demo.InventoryService.Infrastructure.Extensions;
using Cat.Demo.ServiceDefaults;
using Cat.EventProcessor.Minimal.Api.Extensions;
using Cat.Expressions.Extensions;
using Cat.Minimal.Api.Extensions;
using Cat.ServiceRequests.Decorators.ActivitySource.Extensions;
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

builder.AddServiceDefaults();

builder.Services.AddOpenApi();

builder.Services.AddCatMinimalApiModule();
builder.Services.AddCatCompiledMemberExpressionCache();
builder.Services.AddCatValidatorsModule(typeof(StockReserveRequestValidator));
builder.Services.AddCatServiceRequestsModule(typeof(StockReserveRequestHandler));
builder.Services.AddCatCommandsModule(typeof(StockReserveCommandHandler));

// The database and its schema come from the SQL scripts. This service never creates them.
var connectionString = builder.Configuration.GetConnectionString("inventory")
    ?? throw new InvalidOperationException("Connection string 'inventory' is missing.");
builder.Services.AddCatDemoInventoryDatabase(connectionString);

// The listener for the messages of other services. It is on when the host gives Inventory the connection string "messaging".
var eventProcessorOn = builder.Services.AddCatDemoInventoryEventProcessor(builder.Configuration);

// The development endpoints of the event processor are not in the default OpenAPI document, so no client gets them.
// The dev document holds them, and Scalar shows it next to the default one.
var devDocument = Cat.EventProcessor.Minimal.Api.Extensions.EndpointRouteBuilderExtensions.DevDocumentName;
if (eventProcessorOn)
{
    builder.Services.AddOpenApi(devDocument);
}

var authenticationOn = builder.AddDemoJwtAuthentication();

var app = builder.Build();
app.UseCatMinimalApiModule();

if (authenticationOn)
{
    app.UseAuthentication();
    app.UseAuthorization();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        if (eventProcessorOn)
        {
            options.AddDocuments("v1", devDocument);
        }
    });

    if (eventProcessorOn)
    {
        await app.Services.InitializeInventoryEventProcessorAsync();
        app.MapCatEventProcessor();
    }
}

app.UseHttpsRedirection();

app.MapDefaultEndpoints();
app.MapInventoryServiceEndpoints(authenticationOn);
app.Services.AddCatServiceRequestsModuleValidationDecorator();
app.Services.AddCatServiceRequestsModuleLoggingDecorator();
app.Services.AddCatServiceRequestsModuleActivitySourceDecorator();
app.Services.AddCatCommandsModuleLoggingDecorator();

app.Run();
