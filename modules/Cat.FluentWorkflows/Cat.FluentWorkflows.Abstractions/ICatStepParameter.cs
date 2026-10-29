namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// One input or output of a step.
/// </summary>
public interface ICatStepParameter
{
    /// <summary>
    /// Reads the value from the source and writes it to the target.
    /// </summary>
    /// <param name="source">The object to read from.</param>
    /// <param name="target">The object to write to.</param>
    void Assign(object source, object target);
}