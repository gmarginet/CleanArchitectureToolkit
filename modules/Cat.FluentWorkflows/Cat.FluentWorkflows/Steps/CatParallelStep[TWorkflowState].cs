using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Steps;

/// <summary>
/// Built-in step behind <c>Parallel</c>. It runs several branches on the same workflow state.
/// The code steps of the branches run one after another, in the order the branches were added. Only the waiting is parallel:
/// a branch that suspends waits while the other branches run. <see cref="Rule"/> says what a failure or a suspend does.
/// Two branches must not write the same property of the state.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
public class CatParallelStep<TWorkflowState> : CatContainerStepBody<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    private readonly ICatStepProcessor _catStepProcessor;

    /// <summary>
    /// Creates the step.
    /// </summary>
    /// <param name="catStepProcessor">Runs the steps of a branch.</param>
    /// <param name="logger">The logger the step can use.</param>
    public CatParallelStep(
        ICatStepProcessor catStepProcessor,
        ILogger<CatParallelStep<TWorkflowState>> logger)
        : base(logger)
    {
        _catStepProcessor = catStepProcessor;
    }

    /// <summary>
    /// Holds the steps of each branch.
    /// </summary>
    public List<CatWorkflowBuilder<TWorkflowState>> Branches { get; set; } = null!;

    /// <summary>
    /// What a failing or suspending branch does to the other branches.
    /// </summary>
    public CatParallelRule Rule { get; set; } = CatParallelRule.FailFast;

    /// <inheritdoc />
    public override async Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        var count = Branches.Count;
        var branchFrames = new List<CatParallelBranchFrame>();

        for (var i = 0; i < count; i++)
        {
            branchFrames.Add(new CatParallelBranchFrame());
        }

        if (SavedFrame != null)
        {
            if (SavedFrame.Branches.Count != count)
            {
                throw new CatWorkflowResumeException(
                    $"The checkpoint has {SavedFrame.Branches.Count} branches for a parallel step, but the workflow has {count}.");
            }

            branchFrames = SavedFrame.Branches;
        }

        var errors = new List<ICatError>();

        for (var i = 0; i < count; i++)
        {
            var branchFrame = branchFrames[i];
            ICatWorkflowResponse result;

            if (branchFrame.Status is CatParallelBranchStatus.Done or CatParallelBranchStatus.Failed)
            {
                continue;
            }

            if (branchFrame.Status == CatParallelBranchStatus.Suspended)
            {
                if (Resume == null || branchFrame.Frame == null || !Resume.Request.IsMeantFor(branchFrame.Frame))
                {
                    continue;
                }

                result = await _catStepProcessor.RunStepsAsync(Branches[i], WorkflowState, new CatResumeInfo(branchFrame.Frame, Resume.Request), cancellationToken);
            }
            else
            {
                result = await _catStepProcessor.RunStepsAsync(Branches[i], WorkflowState, null, cancellationToken);
            }

            errors.AddRange(result.ErrorList);

            switch (result.WorkflowResult)
            {
                case CatStepExecutionResult.Suspend:
                    branchFrame.Status = CatParallelBranchStatus.Suspended;
                    branchFrame.Frame = result.Checkpoint?.Frame;

                    if (Rule == CatParallelRule.FailFast)
                    {
                        return Suspended(branchFrames, errors);
                    }

                    break;

                case CatStepExecutionResult.BreakCascade:
                    if (Rule != CatParallelRule.WaitForAll)
                    {
                        return CatWorkflowResponse.WithErrors(result, errors);
                    }

                    branchFrame.Status = CatParallelBranchStatus.Failed;
                    branchFrame.Frame = null;
                    break;

                case CatStepExecutionResult.BreakFromLoop:
                    return CatWorkflowResponse.WithErrors(result, errors);

                default:
                    branchFrame.Status = CatParallelBranchStatus.Done;
                    branchFrame.Frame = null;
                    break;
            }
        }

        if (branchFrames.Any(b => b.Status == CatParallelBranchStatus.Suspended))
        {
            return Suspended(branchFrames, errors);
        }

        var outcome = branchFrames.Any(b => b.Status == CatParallelBranchStatus.Failed)
            ? CatStepExecutionResult.BreakCascade
            : CatStepExecutionResult.Continue;

        return new CatWorkflowResponse(outcome, errors);
    }

    private static ICatWorkflowResponse Suspended(List<CatParallelBranchFrame> branchFrames, List<ICatError> errors)
    {
        var frame = new CatCheckpointFrame { Branches = branchFrames };
        return CatWorkflowResponse.Suspended(frame, errors);
    }
}
