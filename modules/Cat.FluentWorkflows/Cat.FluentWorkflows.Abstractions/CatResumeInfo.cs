namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// The saved frame of the step that is being resumed, together with the resume request.
/// The step processor gives it to a container step through <see cref="ICatContainerStepBody.Resume"/>.
/// </summary>
public sealed class CatResumeInfo
{
    /// <summary>
    /// Creates the info.
    /// </summary>
    /// <param name="frame">The saved frame of the step.</param>
    /// <param name="request">The answer and its target.</param>
    public CatResumeInfo(CatCheckpointFrame frame, CatResumeRequest request)
    {
        Frame = frame;
        Request = request;
    }

    /// <summary>
    /// The saved frame of the step.
    /// </summary>
    public CatCheckpointFrame Frame { get; }

    /// <summary>
    /// The answer and its target.
    /// </summary>
    public CatResumeRequest Request { get; }

    /// <summary>
    /// Gets the info for the list of steps inside the container.
    /// </summary>
    /// <returns>The info for the child frame, or <c>null</c> when the frame has no child.</returns>
    public CatResumeInfo? ForChild()
    {
        return Frame.Child == null ? null : new CatResumeInfo(Frame.Child, Request);
    }
}
