using System;
using System.Reflection;
using Cat.Messaging.Abstractions;

namespace Cat.Messaging;

/// <summary>
/// Default <see cref="ICatMessageNameResolver"/>.
/// The name of the type is the name on the bus, unless <see cref="CatMessageAttribute"/> says otherwise.
/// </summary>
internal sealed class CatMessageNameResolver : ICatMessageNameResolver
{
    /// <inheritdoc />
    public string GetName(Type messageType)
    {
        var name = messageType.GetCustomAttribute<CatMessageAttribute>(inherit: false)?.Name;
        return string.IsNullOrWhiteSpace(name) ? messageType.Name : name!;
    }

    /// <inheritdoc />
    public bool RequiresSession(Type messageType)
    {
        return messageType.GetCustomAttribute<CatMessageAttribute>(inherit: false)?.RequiresSession ?? false;
    }

    /// <inheritdoc />
    public CatMessageKind GetKind(Type messageType)
    {
        var isEvent = typeof(ICatEventMessage).IsAssignableFrom(messageType);
        var isCommand = typeof(ICatCommandMessage).IsAssignableFrom(messageType);

        if (isEvent == isCommand)
        {
            throw new ArgumentException(
                $"{messageType.Name} must be an event or a command message, not both and not neither.",
                nameof(messageType));
        }

        return isEvent ? CatMessageKind.Event : CatMessageKind.Command;
    }
}
