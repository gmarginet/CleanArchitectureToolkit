using System;
using Cat.Commands.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Commands;

/// <summary>
/// Finds the customer with the external id, or creates it. Updates the name and email when they changed.
/// The handler fills <see cref="CustomerId"/>.
/// It is a class with a parameterless constructor, because a workflow step creates it and fills it.
/// </summary>
public class CustomerCreateOrUpdateCommand : ICatCommand
{
    public string ExternalId { get; set; } = "";
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";

    /// <summary>The result. Set by the handler.</summary>
    public Guid CustomerId { get; set; }
}
