namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// The answer of a resume and the step it is meant for. All the levels of one resume share the same request.
/// </summary>
public sealed class CatResumeRequest
{
    /// <summary>
    /// Creates the request.
    /// </summary>
    /// <param name="answer">The answer for the waiting step.</param>
    /// <param name="target">The name of the waiting step that gets the answer, or <c>null</c> when only one step waits.</param>
    public CatResumeRequest(object? answer, string? target)
    {
        Answer = answer;
        Target = target;
    }

    /// <summary>
    /// The answer for the waiting step.
    /// </summary>
    public object? Answer { get; }

    /// <summary>
    /// The name of the waiting step that gets the answer, or <c>null</c> when only one step waits.
    /// </summary>
    public string? Target { get; }

    /// <summary>
    /// Checks if a frame holds the step that gets the answer, at any depth.
    /// </summary>
    /// <param name="frame">The frame to look in.</param>
    /// <returns><c>true</c> when the frame has a waiting step that this request is meant for.</returns>
    public bool IsMeantFor(CatCheckpointFrame frame)
    {
        foreach (var leaf in frame.Leaves())
        {
            if (Target == null || leaf.StepName == Target)
            {
                return true;
            }
        }

        return false;
    }
}
