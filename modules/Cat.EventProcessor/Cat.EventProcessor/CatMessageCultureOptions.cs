namespace Cat.EventProcessor;

/// <summary>
/// Holds the choice of the service to apply the culture of the sender. Set by <see cref="CatEventProcessorBuilder.ApplySenderCulture"/>.
/// </summary>
internal sealed class CatMessageCultureOptions
{
    /// <summary>
    /// True when the receiver sets the culture of the sender for the handler.
    /// </summary>
    public bool ApplySenderCulture { get; set; }
}
