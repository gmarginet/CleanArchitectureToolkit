using System;

namespace Cat.Demo.OrderService.CoreService.Workflows;

/// <summary>Settings of the place order workflow. The host fills them from the configuration.</summary>
public class PlaceOrderOptions
{
    /// <summary>
    /// How long the order waits for the answer of Payment. After that the order is cancelled with the reason <c>PaymentUnavailable</c>.
    /// </summary>
    public TimeSpan PaymentTimeout { get; set; } = TimeSpan.FromMinutes(2);
}
