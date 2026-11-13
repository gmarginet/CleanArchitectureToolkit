using System.Collections.Generic;

namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// The position in one list of steps: which step suspended, and what that step looked like inside.
/// A step that waits for an answer is the end of the chain and has no <see cref="Child"/> and no <see cref="Branches"/>.
/// A container step such as an if, a loop or a sub-workflow points to the frame of the step inside it with <see cref="Child"/>.
/// A parallel step holds one entry per branch in <see cref="Branches"/>.
/// </summary>
public class CatCheckpointFrame
{
    /// <summary>
    /// The position of the step in its list.
    /// </summary>
    public int StepIndex { get; set; }

    /// <summary>
    /// The name of the step, when the developer gave it one. A name wins over the position when the workflow is rebuilt.
    /// </summary>
    public string? StepName { get; set; }

    /// <summary>
    /// The full name of the step body type. A resume checks it against the rebuilt step.
    /// </summary>
    public string? BodyType { get; set; }

    /// <summary>
    /// The branch a container step was in, see <see cref="CatCheckpointBranches"/>.
    /// </summary>
    public string? Branch { get; set; }

    /// <summary>
    /// The value of the case a switch step ran.
    /// </summary>
    public string? CaseValue { get; set; }

    /// <summary>
    /// The pass of a while, or the index of the item of a foreach, that was running.
    /// </summary>
    public int Iteration { get; set; }

    /// <summary>
    /// The number of items a foreach had. A resume fails when the collection has another count.
    /// </summary>
    public int ItemCount { get; set; }

    /// <summary>
    /// The state of a foreach, shared by all its items. The engine sets its parent state to <c>null</c>, so a serializer does not drag the whole workflow state along.
    /// The resume sets it again.
    /// </summary>
    public object? LoopState { get; set; }

    /// <summary>
    /// The assembly qualified name of the type of <see cref="LoopState"/>, so the serializer knows what to create.
    /// </summary>
    public string? LoopStateType { get; set; }

    /// <summary>
    /// The version of a sub-workflow that suspended inside this step.
    /// </summary>
    public int WorkflowVersion { get; set; }

    /// <summary>
    /// The frame of the step inside this container step, or <c>null</c> for a step that waits itself.
    /// </summary>
    public CatCheckpointFrame? Child { get; set; }

    /// <summary>
    /// The branches of a parallel step. It is empty for every other step.
    /// </summary>
    public List<CatParallelBranchFrame> Branches { get; set; } = [];

    /// <summary>
    /// <c>true</c> for a step that waits for an answer itself.
    /// </summary>
    public bool IsLeaf => Child == null && Branches.Count == 0;

    /// <summary>
    /// Finds the steps that wait for an answer, at any depth.
    /// </summary>
    /// <returns>The frames of the waiting steps. More than one means a parallel step waits on several branches.</returns>
    public IEnumerable<CatCheckpointFrame> Leaves()
    {
        if (Child != null)
        {
            foreach (var leaf in Child.Leaves())
            {
                yield return leaf;
            }

            yield break;
        }

        if (Branches.Count > 0)
        {
            foreach (var branch in Branches)
            {
                if (branch.Frame == null)
                {
                    continue;
                }

                foreach (var leaf in branch.Frame.Leaves())
                {
                    yield return leaf;
                }
            }

            yield break;
        }

        yield return this;
    }
}
