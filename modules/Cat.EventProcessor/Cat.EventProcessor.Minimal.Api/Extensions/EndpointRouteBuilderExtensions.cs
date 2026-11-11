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
    /// Maps <c>GET /dev/event-processor</c>, which lists the declared message types, and <c>POST /dev/event-processor/{messageType}</c>,
    /// which takes the JSON of a message and runs it through the same pipeline as a real message.
    /// The endpoints exist only in the Development environment. In any other environment nothing is mapped.
    /// The result says what the broker would do with the message, but nothing is settled, because there is no real message.
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

        var group = endpoints.MapGroup("/dev/event-processor");

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

            var message = new CatIncomingMessage
            {
                Body = Encoding.UTF8.GetBytes(json),
                ContentType = "application/json",
                MessageId = Guid.NewGuid().ToString(),
                DeliveryCount = 1
            };

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
}
