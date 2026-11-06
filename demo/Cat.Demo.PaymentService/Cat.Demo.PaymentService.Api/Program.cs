using System.Text.Json.Serialization;
using Cat.Demo.PaymentService.CoreService;
using Cat.Demo.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddOpenApi();

// Numbers are numbers only, so the OpenAPI document describes the amount as a number and not as a number or a string.
builder.Services.ConfigureHttpJsonOptions(options =>
    options.SerializerOptions.NumberHandling = JsonNumberHandling.Strict);

builder.Services.Configure<PaymentFailureOptions>(builder.Configuration.GetSection(PaymentFailureOptions.SectionName));
builder.Services.AddSingleton(TimeProvider.System);
builder.Services.AddSingleton<PaymentProcessor>();

// With an authority in the configuration (the AppHost sets it) the service checks the token the gateway forwards.
// Without one, a plain dotnet run keeps working with no login.
var authenticationOn = builder.AddDemoJwtAuthentication();

var app = builder.Build();

if (authenticationOn)
{
    app.UseAuthentication();
    app.UseAuthorization();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapDefaultEndpoints();

// Takes a payment. A declined payment answers 200 with Approved false. A failure that was switched on answers 503.
// The path starts with the name of the service, as the gateway routes it.
var payments = app.MapPost("/payment/payments", async (PaymentRequest request, PaymentProcessor processor, CancellationToken cancellationToken) =>
{
    if (string.IsNullOrWhiteSpace(request.OrderNumber) || request.Amount <= 0)
    {
        return Results.BadRequest(new { error = "An order number and an amount above zero are required." });
    }

    var outcome = await processor.ProcessAsync(request, cancellationToken);

    return outcome.Failed
        ? Results.Problem("The payment service is failing on purpose.", statusCode: StatusCodes.Status503ServiceUnavailable)
        : Results.Ok(outcome.Response);
})
.Produces<PaymentResponse>(StatusCodes.Status200OK)
.ProducesProblem(StatusCodes.Status400BadRequest)
.ProducesProblem(StatusCodes.Status503ServiceUnavailable);

if (authenticationOn)
{
    payments.RequireAuthorization();
}

app.Run();
