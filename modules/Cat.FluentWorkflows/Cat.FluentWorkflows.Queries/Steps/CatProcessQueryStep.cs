using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.Queries.Abstractions;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Queries.Steps;

/// <summary>
/// Built-in step behind <c>ProcessQuery</c>. It processes a query with the query processor.
/// A succeeded query continues the workflow. A failed query ends it with BreakCascade and the errors.
/// </summary>
/// <typeparam name="TQuery">The query to process.</typeparam>
/// <typeparam name="TResult">The type of the data the query returns.</typeparam>
public class CatProcessQueryStep<TQuery, TResult> : CatStepBodyAsync
    where TQuery : class, ICatQuery<TResult>
{
    private readonly ICatQueryProcessor _queryProcessor;

    /// <summary>
    /// Creates the step and the query, using the parameterless constructor of the query.
    /// </summary>
    /// <param name="queryProcessor">Processes the query.</param>
    /// <param name="logger">The logger the step can use.</param>
    public CatProcessQueryStep(
        ICatQueryProcessor queryProcessor,
        ILogger<CatProcessQueryStep<TQuery, TResult>> logger)
        : base(logger)
    {
        _queryProcessor = queryProcessor;

        Query = (TQuery)Activator.CreateInstance(typeof(TQuery));
    }

    /// <summary>
    /// The query to process. Fill its members with <c>Input</c>.
    /// </summary>
    public TQuery Query { get; set; }

    /// <summary>
    /// The response of the query. Read it with <c>Output</c> after the step ran.
    /// </summary>
    public ICatResponse<TResult>? Response { get; private set; }

    /// <inheritdoc />
    public override async Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            Response = await _queryProcessor.ProcessAsync(Query, cancellationToken);
            
            return CatResponseExtensions.Cast(Response, Response.IsSucceeded
                ? CatStepExecutionResult.Continue
                : CatStepExecutionResult.BreakCascade);
        }
        catch (Exception ex)
        {
            var queryName = typeof(TQuery).Name;
            Logger.LogError(ex, "Unhandled exception was thrown during processing of query '{queryName}'.", queryName);
            throw;
        }
    }
}