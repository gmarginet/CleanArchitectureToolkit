using System;
using Cat.Commands.Decorators.Logging.Extensions;
using Cat.Commands.Extensions;
using Cat.Demo.OrderService.Api.Extensions;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.Demo.OrderService.CoreService.Extensions;
using Cat.Demo.OrderService.CoreService.ServiceRequestHandlers;
using Cat.Demo.OrderService.CoreService.Validators;
using Cat.Demo.OrderService.CoreService.Workflows;
using Cat.Demo.OrderService.CoreService.Workflows.Steps;
using Cat.Demo.OrderService.Infrastructure.CommandHandlers;
using Cat.Demo.OrderService.Infrastructure.Extensions;
using Cat.Demo.OrderService.Infrastructure.QueryHandlers;
using Cat.Demo.ServiceDefaults;
using Cat.EventAggregators.Extensions;
using Cat.Expressions.Extensions;
using Cat.FluentWorkflows.Commands.Extensions;
using Cat.FluentWorkflows.Extensions;
using Cat.Minimal.Api.Extensions;
using Cat.Queries.Decorators.Logging.Extensions;
using Cat.Queries.Extensions;
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
builder.Services.AddCatValidatorsModule(typeof(PlaceOrderRequestValidator));
builder.Services.AddCatServiceRequestsModule(typeof(PlaceOrderRequestHandler));
builder.Services.AddCatQueriesModule(typeof(OrderGetQueryHandler));
builder.Services.AddCatCommandsModule(typeof(OrderCreateCommandHandler));

builder.Services.AddCatEventAggregatorsModule();
builder.Services.AddCatDemoOrderEventSubscribers();

builder.Services.AddCatFluentWorkflowsModule();
builder.Services.AddCatBuildInCommandWorkflowStep();
builder.Services.AddCatFluentWorkflowsFlows(typeof(PlaceOrderWorkflow));
builder.Services.AddCatFluentWorkflowsSteps(typeof(PriceLinesStep));

var connectionString = builder.Configuration.GetConnectionString("orders")
    ?? throw new InvalidOperationException("Connection string 'orders' is missing.");
builder.Services.AddCatDemoOrderDatabase(connectionString);
builder.Services.AddCatDemoOrderFakes();

// The stub knows three demo users. The real one reads the token, once the gateway and Keycloak are there.
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUser, DevelopmentCurrentUser>();

var app = builder.Build();
app.UseCatMinimalApiModule();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    await app.Services.InitializeOrderDatabaseAsync();
}

app.UseHttpsRedirection();

app.MapDefaultEndpoints();
app.MapOrderServiceEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOrderServiceDevelopmentEndpoints();
}

app.Services.ActivateCatDemoOrderEventSubscribers();
app.Services.AddCatServiceRequestsModuleValidationDecorator();
app.Services.AddCatServiceRequestsModuleLoggingDecorator();
app.Services.AddCatServiceRequestsModuleActivitySourceDecorator();
app.Services.AddCatQueriesModuleLoggingDecorator();
app.Services.AddCatCommandsModuleLoggingDecorator();

app.Run();
