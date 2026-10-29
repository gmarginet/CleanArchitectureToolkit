using Cat.Commands.Decorators.Logging.Extensions;
using Cat.Commands.Extensions;
using Cat.Decorators.Extensions;
using Cat.Demo.TodoService.Api.Extensions;
using Cat.Demo.ToDoService.Core.ServiceRequestHandlers;
using Cat.Demo.TodoService.Events.ServiceRequests;
using Cat.Demo.TodoService.Infrastructure.CommandHandlers;
using Cat.Demo.TodoService.Infrastructure.Database;
using Cat.Demo.TodoService.Infrastructure.QueryHandlers;
using Cat.Expressions.Extensions;
using Cat.Minimal.Api.Extensions;
using Cat.Queries.Decorators.Logging.Extensions;
using Cat.Queries.Extensions;
using Cat.ServiceRequests.Decorators.Logging.Extensions;
using Cat.ServiceRequests.Decorators.Validation.Extensions;
using Cat.ServiceRequests.Extensions;
using Cat.Validators.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Logging.ClearProviders();
if (builder.Environment.IsDevelopment())
{
    builder.Logging.AddConsole();
}

builder.Services.AddCatMinimalApiModule();
builder.Services.AddCatCompiledMemberExpressionCache();
builder.Services.AddCatValidatorsModule(typeof(TodoGetRequestValidator));
builder.Services.AddCatServiceRequestsModule(typeof(TodoGetRequestHandler));
builder.Services.AddCatQueriesModule(typeof(TodoGetQueryHandler));
builder.Services.AddCatCommandsModule(typeof(TodoSaveCommandHandler));

builder.Services.AddCatDemoDatabase();

var app = builder.Build();
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithDefaultHttpClient(ScalarTarget.Http, ScalarClient.Http);
    });
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("openapi/v1.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
app.UseHttpsRedirection();
app.Urls.Add("http://localhost:5000");

app.MapToDoServiceEndpoints();
app.Services.AddCatServiceRequestsModuleValidationDecorator();
app.Services.AddCatServiceRequestsModuleLoggingDecorator();
app.Services.AddCatQueriesModuleLoggingDecorator();
app.Services.AddCatCommandsModuleLoggingDecorator();

app.Run();
