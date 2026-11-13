namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// The names a container step writes in <see cref="CatCheckpointFrame.Branch"/>. A custom container can use its own names.
/// </summary>
public static class CatCheckpointBranches
{
    /// <summary>
    /// The then steps of an if.
    /// </summary>
    public const string Then = "then";

    /// <summary>
    /// The else steps of an if.
    /// </summary>
    public const string Else = "else";

    /// <summary>
    /// A case of a switch. The value is in <see cref="CatCheckpointFrame.CaseValue"/>.
    /// </summary>
    public const string Case = "case";

    /// <summary>
    /// The default case of a switch.
    /// </summary>
    public const string Default = "default";

    /// <summary>
    /// The inner steps of a loop.
    /// </summary>
    public const string Body = "body";

    /// <summary>
    /// The steps of a sub-workflow.
    /// </summary>
    public const string Sub = "sub";
}
