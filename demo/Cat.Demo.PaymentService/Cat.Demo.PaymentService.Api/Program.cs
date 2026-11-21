using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Cat.Demo.PaymentService.CoreService;
using Microsoft.AspNetCore.Mvc;

// A stand-in for an outside payment provider. It is a plain REST API: no CAT module, no ServiceDefaults,
// and it does not sit behind the gateway. A caller sends the API key as a bearer token and an Idempotency-Key header.
var builder = WebApplication.CreateBuilder(args);

// The default document describes a decimal as a double, and so does the generated client. Say decimal, so money stays decimal.
builder.Services.AddOpenApi(options => options.AddSchemaTransformer((schema, context, _) =>
{
    if ((Nullable.GetUnderlyingType(context.JsonTypeInfo.Type) ?? context.JsonTypeInfo.Type) == typeof(decimal))
    {
        schema.Format = "decimal";
    }

    return Task.CompletedTask;
}));

// Numbers are numbers only, so the OpenAPI document describes the amount as a number and not as a number or a string.
builder.Services.ConfigureHttpJsonOptions(options =>
    options.SerializerOptions.NumberHandling = JsonNumberHandling.Strict);

builder.Services.Configure<PaymentFailureOptions>(builder.Configuration.GetSection(PaymentFailureOptions.SectionName));
builder.Services.AddSingleton(TimeProvider.System);
builder.Services.AddSingleton<PaymentProcessor>();
builder.Services.AddHealthChecks();

var apiKey = builder.Configuration["Provider:ApiKey"];

var app = builder.Build();

app.MapHealthChecks("/health");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var provider = app.MapGroup(string.Empty);

// The provider knows its caller by the API key. A call without the right key gets 401.
provider.AddEndpointFilter(async (context, next) =>
{
    var header = context.HttpContext.Request.Headers.Authorization.ToString();
    return !string.IsNullOrEmpty(apiKey) && header == $"Bearer {apiKey}"
        ? await next(context)
        : Results.Unauthorized();
});

// Takes a payment. A declined payment answers 200 with the status declined. A failure that was switched on answers 503.
// The idempotency key makes a repeated call return the first answer, and charge nothing again.
provider.MapPost("/charges", async (
    ChargeRequest request,
    [FromHeader(Name = "Idempotency-Key")] string idempotencyKey,
    PaymentProcessor processor,
    CancellationToken cancellationToken) =>
{
    if (string.IsNullOrWhiteSpace(idempotencyKey) || string.IsNullOrWhiteSpace(request.OrderNumber) || request.Amount <= 0)
    {
        return Results.BadRequest(new { error = "An Idempotency-Key header, an order number and an amount above zero are required." });
    }

    var outcome = await processor.ChargeAsync(idempotencyKey, request, cancellationToken);

    return outcome.Failed
        ? Results.Problem("The payment provider is failing on purpose.", statusCode: StatusCodes.Status503ServiceUnavailable)
        : Results.Ok(outcome.Response);
})
.Produces<ChargeResponse>(StatusCodes.Status200OK)
.ProducesProblem(StatusCodes.Status400BadRequest)
.ProducesProblem(StatusCodes.Status401Unauthorized)
.ProducesProblem(StatusCodes.Status503ServiceUnavailable)
.WithName("CreateCharge");

// Gives the money of an approved charge back. An order with no approved charge answers 200 with the status nothing_to_refund.
provider.MapPost("/refunds", async (
    RefundRequest request,
    [FromHeader(Name = "Idempotency-Key")] string idempotencyKey,
    PaymentProcessor processor,
    CancellationToken cancellationToken) =>
{
    if (string.IsNullOrWhiteSpace(idempotencyKey) || string.IsNullOrWhiteSpace(request.OrderNumber))
    {
        return Results.BadRequest(new { error = "An Idempotency-Key header and an order number are required." });
    }

    var outcome = await processor.RefundAsync(idempotencyKey, request, cancellationToken);

    return outcome.Failed
        ? Results.Problem("The payment provider is failing on purpose.", statusCode: StatusCodes.Status503ServiceUnavailable)
        : Results.Ok(outcome.Response);
})
.Produces<RefundResponse>(StatusCodes.Status200OK)
.ProducesProblem(StatusCodes.Status400BadRequest)
.ProducesProblem(StatusCodes.Status401Unauthorized)
.ProducesProblem(StatusCodes.Status503ServiceUnavailable)
.WithName("CreateRefund");

app.Run();
