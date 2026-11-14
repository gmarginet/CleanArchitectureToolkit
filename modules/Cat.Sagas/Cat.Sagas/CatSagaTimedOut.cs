namespace Cat.Sagas;

/// <summary>
/// The "answer" the dispatcher gives to a wait step that timed out. The step sets its <c>TimedOut</c> flag when it gets it.
/// </summary>
internal sealed class CatSagaTimedOut
{
    public static readonly CatSagaTimedOut Instance = new CatSagaTimedOut();

    private CatSagaTimedOut()
    {
    }
}
