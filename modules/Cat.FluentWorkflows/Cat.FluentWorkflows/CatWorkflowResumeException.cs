using System;

namespace Cat.FluentWorkflows;

/// <summary>
/// A resume could not go on, because the checkpoint does not fit the workflow that was built again.
/// The message says what differs: the version, a step name, a step type, the number of items of a foreach or the target of the answer.
/// </summary>
public class CatWorkflowResumeException : InvalidOperationException
{
    /// <summary>
    /// Creates the exception.
    /// </summary>
    /// <param name="message">What differs.</param>
    public CatWorkflowResumeException(string message) : base(message)
    {
    }
}
