using System.Text;
using Cat.EventProcessor.Abstractions;
using Cat.Messaging.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cat.EventProcessor.Minimal.Api.Extensions;

/// <summary>
/// Maps the development endpoint of the event processor.
/// </summary>
public static class EndpointRouteBuilderExtensions
{
    /// <summary>
    /// The OpenAPI group name of the development endpoints.
    /// </summary>
    public const string DevDocumentName = "dev";

    /// <summary>
    /// Maps <c>GET /dev/event-processor</c>, which lists the declared message types, and <c>POST /dev/event-processor/{messageType}</c>,
    /// which takes the JSON of a message and runs it through the same pipeline as a real message.
    /// The endpoints exist only in the Development environment. In any other environment nothing is mapped.
    /// The result says what the broker would do with the message, but nothing is settled, because there is no real message.
    /// The <c>Authorization</c> header of the request becomes the token of the message, so a message type with an authorization rule can be tried
    /// with the same token as the API. Without the header the message has no token.
    /// The group has the OpenAPI group name <c>dev</c>, so the endpoints are not in the default OpenAPI document and no generated client gets them.
    /// To see them in an API explorer, add a document with <c>AddOpenApi("dev")</c> and map it.
    /// </summary>
    /// <param name="endpoints">The endpoint route builder of the API.</param>
    /// <returns>The group of the development endpoints, or null when the environment is not Development.</returns>
    public static RouteGroupBuilder? MapCatEventProcessor(this IEndpointRouteBuilder endpoints)
    {
        var environment = endpoints.ServiceProvider.GetRequiredService<IHostEnvironment>();
        if (!environment.IsDevelopment())
        {
            return null;
        }

        var group = endpoints.MapGroup("/dev/event-processor").WithGroupName(DevDocumentName);

        group.MapGet("", (ICatReceiveRegistry registry, ICatMessageNameResolver names) =>
            Results.Ok(registry.Registrations.Select(registration => new
            {
                MessageType = registration.MessageType.Name,
                Entity = names.GetName(registration.MessageType),
                Kind = names.GetKind(registration.MessageType).ToString()
            })));

        group.MapPost("{messageType}", async (string messageType, HttpRequest request, ICatReceiveRegistry registry,
            ICatMessageReceiver receiver, CancellationToken cancellationToken) =>
        {
            var registration = registry.Registrations.FirstOrDefault(r =>
                string.Equals(r.MessageType.Name, messageType, StringComparison.OrdinalIgnoreCase));
            if (registration is null)
            {
                return Results.NotFound($"{messageType} is not a declared message type.");
            }

            using var reader = new StreamReader(request.Body, Encoding.UTF8);
            var json = await reader.ReadToEndAsync(cancellationToken);

            var message = CreateMessage(json, request.Headers.Authorization.ToString());

            var result = await receiver.ReceiveAsync(registration.MessageType, message, cancellationToken);

            return Results.Ok(new
            {
                Settlement = result.Settlement.ToString(),
                result.Reason,
                result.Description
            });
        });

        return group;
    }

    /// <summary>
    /// Builds the incoming message of a development request. A real message carries the token of its sender in the
    /// <c>Authorization</c> property, so the <c>Authorization</c> header of the request goes into that property.
    /// Without the header the message has no token.
    /// </summary>
    internal static CatIncomingMessage CreateMessage(string json, string? authorizationHeader)
    {
        var message = new CatIncomingMessage
        {
            Body = Encoding.UTF8.GetBytes(json),
            ContentType = "application/json",
            MessageId = Guid.NewGuid().ToString(),
            DeliveryCount = 1
        };

        if (!string.IsNullOrWhiteSpace(authorizationHeader))
        {
            message.Properties[CatMessageProperties.Authorization] = authorizationHeader!;
        }

        return message;
    }
}
