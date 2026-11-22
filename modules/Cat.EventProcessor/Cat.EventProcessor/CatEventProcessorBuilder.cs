using System;
using System.Collections.Generic;
using Cat.EventProcessor.Abstractions;
using Cat.Messaging.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.EventProcessor;

/// <summary>
/// Declares the message types a service receives. Use it where the API project registers the event processor, like you define the endpoints of an API.
/// </summary>
public sealed class CatEventProcessorBuilder
{
    private readonly List<CatReceiveRegistration> _registrations = new List<CatReceiveRegistration>();

    internal IReadOnlyList<CatReceiveRegistration> Registrations => _registrations;

    internal bool SenderCultureApplied { get; private set; }

    /// <summary>
    /// Makes the receiver set <c>CurrentCulture</c> and <c>CurrentUICulture</c> to the culture of the sender, for the handler of every message.
    /// The culture comes from the <c>Culture</c> property of the message, see <c>CatMessageProperties.Culture</c>.
    /// Without this call, or for a message without the property, the handler runs on the default culture of the service.
    /// </summary>
    /// <returns>The same builder, so calls can be chained.</returns>
    public CatEventProcessorBuilder ApplySenderCulture()
    {
        SenderCultureApplied = true;
        return this;
    }

    /// <summary>
    /// Declares a message type the service receives. Every message of the type becomes this service request.
    /// </summary>
    /// <typeparam name="TMessage">The message type. It is a message and a service request at the same time.</typeparam>
    /// <param name="configure">Changes the settings of the message type.</param>
    /// <returns>The same builder, so calls can be chained.</returns>
    /// <exception cref="InvalidOperationException">The message type is declared twice.</exception>
    public CatEventProcessorBuilder Receive<TMessage>(Action<CatReceiveOptions>? configure = null)
        where TMessage : class, ICatMessage, ICatServiceRequest
    {
        foreach (var registration in _registrations)
        {
            if (registration.MessageType == typeof(TMessage))
            {
                throw new InvalidOperationException($"{typeof(TMessage).Name} is declared twice.");
            }
        }

        var options = new CatReceiveOptions();
        configure?.Invoke(options);
        _registrations.Add(new CatReceiveRegistration(typeof(TMessage), options));

        return this;
    }
}
