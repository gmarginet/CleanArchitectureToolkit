namespace Cat.Sagas;

/// <summary>
/// Settings of the saga engine. Register them with the extension methods and do not create them yourself.
/// </summary>
public sealed class CatSagaOptions
{
    /// <summary>
    /// When true, the engine hands the request message to the sender first and saves the instance after that, in one go.
    /// Use it with the outbox of <c>Cat.Messaging</c>, where the sender only adds a row to the context and the save commits it with the instance.
    /// <c>AddCatSagasOutbox</c> sets it. When false, the engine saves the instance first and sends after, so an answer cannot arrive before its instance exists.
    /// </summary>
    public bool SendBeforeSave { get; set; }
}
