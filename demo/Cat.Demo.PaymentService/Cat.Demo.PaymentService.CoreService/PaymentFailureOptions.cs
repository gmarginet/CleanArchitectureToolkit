namespace Cat.Demo.PaymentService.CoreService;

/// <summary>
/// The failures the payment service can be told to show. They live in the <c>PaymentFailures</c> section of the settings.
/// All values are off by default. The settings are read again when they change, so a running service picks them up.
/// </summary>
public class PaymentFailureOptions
{
    public const string SectionName = "PaymentFailures";

    /// <summary>Waits this long before every answer. Zero means no delay.</summary>
    public TimeSpan Latency { get; set; } = TimeSpan.Zero;

    /// <summary>
    /// The share of calls, from 0 to 100, that fail after the payment is already taken.
    /// The caller gets an error and tries again. This is the case the idempotency key protects against.
    /// </summary>
    public int ErrorPercentage { get; set; }

    /// <summary>When true, every call fails at once and nothing is taken.</summary>
    public bool Outage { get; set; }
}
