using System;
using Cat.Commands.Decorators.Logging.Extensions;
using Cat.Commands.Extensions;
using Cat.Demo.NotificationService.Api.Extensions;
using Cat.Demo.NotificationService.CoreService.ServiceRequestHandlers;
using Cat.Demo.NotificationService.CoreService.Validators;
using Cat.Demo.NotificationService.Infrastructure.CommandHandlers;
using Cat.Demo.NotificationService.Infrastructure.Extensions;
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
builder.Services.AddCatValidatorsModule(typeof(StockChangedValidator));
builder.Services.AddCatServiceRequestsModule(typeof(OrderConfirmedHandler));
builder.Services.AddCatCommandsModule(typeof(SendOrderConfirmedMailCommandHandler));

var connectionString = builder.Configuration.GetConnectionString("notifications")
    ?? throw new InvalidOperationException("Connection string 'notifications' is missing.");
builder.Services.AddCatDemoNotificationDatabase(connectionString);
builder.Services.AddCatDemoNotificationMail(builder.Configuration);

// The listener for the messages of other services. It is on when the host gives Notifications the connection string "messaging".
var eventProcessorOn = builder.Services.AddCatDemoNotificationEventProcessor(builder.Configuration);

// The development endpoints of the event processor are not in the default OpenAPI document.
// The dev document holds them, and Scalar shows it next to the default one.
var devDocument = Cat.EventProcessor.Minimal.Api.Extensions.EndpointRouteBuilderExtensions.DevDocumentName;
if (eventProcessorOn)
{
    builder.Services.AddOpenApi(devDocument);
}

var app = builder.Build();
app.UseCatMinimalApiModule();

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

    await app.Services.InitializeNotificationDatabaseAsync();

    if (eventProcessorOn)
    {
        await app.Services.InitializeNotificationEventProcessorAsync();
        app.MapCatEventProcessor();
    }
}

app.UseHttpsRedirection();

app.MapDefaultEndpoints();
app.Services.AddCatServiceRequestsModuleValidationDecorator();
app.Services.AddCatServiceRequestsModuleLoggingDecorator();
app.Services.AddCatServiceRequestsModuleActivitySourceDecorator();
app.Services.AddCatCommandsModuleLoggingDecorator();

app.Run();
