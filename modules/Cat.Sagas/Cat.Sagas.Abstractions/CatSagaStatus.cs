namespace Cat.Sagas.Abstractions;

/// <summary>
/// Where a saga instance is in its life.
/// </summary>
public enum CatSagaStatus
{
    /// <summary>
    /// The workflow stopped at a wait step and its state is saved. An answer resumes it.
    /// </summary>
    Waiting = 0,

    /// <summary>
    /// The workflow ran to the end without errors.
    /// </summary>
    Completed = 1,

    /// <summary>
    /// The workflow ended with errors.
    /// </summary>
    Failed = 2
}
