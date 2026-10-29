using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Commands.Steps;

/// <summary>
/// Built-in step behind <c>ProcessCommand</c>. It processes a command with the command processor.
/// A succeeded command continues the workflow. A failed command ends it with BreakCascade and the errors.
/// </summary>
/// <typeparam name="TCommand">The command to process.</typeparam>
public class CatProcessCommandStep<TCommand> : CatStepBodyAsync
    where TCommand : class, ICatCommand
{
    private readonly ICatCommandProcessor _commandProcessor;

    /// <summary>
    /// Creates the step and the command, using the parameterless constructor of the command.
    /// </summary>
    /// <param name="commandProcessor">Processes the command.</param>
    /// <param name="logger">The logger the step can use.</param>
    public CatProcessCommandStep(
        ICatCommandProcessor commandProcessor,
        ILogger<CatProcessCommandStep<TCommand>> logger)
        : base(logger)
    {
        _commandProcessor = commandProcessor;

        Command = (TCommand)Activator.CreateInstance(typeof(TCommand));
    }

    /// <summary>
    /// The command to process. Fill its members with <c>Input</c>.
    /// </summary>
    public TCommand Command { get; }

    /// <summary>
    /// The response of the command. Read it with <c>Output</c> after the step ran.
    /// </summary>
    public ICatResponse? Response { get; private set; }

    /// <inheritdoc />
    public override async Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            Response = await _commandProcessor.ProcessAsync(Command, cancellationToken);

            return CatResponseExtensions.Cast(Response, Response.IsSucceeded
                ? CatStepExecutionResult.Continue
                : CatStepExecutionResult.BreakCascade);
        }
        catch (Exception ex)
        {
            var commandName = typeof(TCommand).Name;
            Logger.LogError(ex, "Unhandled exception was thrown during processing of command '{commandName}'.", commandName);
            throw;
        }
    }
}