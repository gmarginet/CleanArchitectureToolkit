using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Steps;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Extensions;

/// <summary>
/// The steps you can add to a workflow. Every method adds one step to the builder, and the steps run in the order you add them.
/// </summary>
public static class CatWorkflowBuilderExtensions
{
    /// <summary>
    /// Adds a step that runs your own step body. Register the body with <c>AddCatFluentWorkflowsSteps</c>.
    /// Give both type arguments, like <c>builder.Run&lt;OrderState, CheckStockStep&gt;()</c>.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <typeparam name="TStepBody">The step body to run.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <returns>A builder to connect the step to the state with <c>Input</c> and <c>Output</c>.</returns>
    public static ICatStepBuilder<TWorkflowState, TStepBody> Run<TWorkflowState, TStepBody>(
        this ICatWorkflowBuilder<TWorkflowState> builder)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
        where TStepBody : class, ICatStepBodyAsync
    {
        var workflowStep = new CatWorkflowStep<TStepBody>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, TStepBody>(workflowStep);

        builder.WorkflowSteps.Add(workflowStep);
        return stepBuilder;
    }

    /// <summary>
    /// Adds a step that runs another workflow, the sub-workflow, on its own state.
    /// The state of the main workflow holds the state of the sub-workflow in <see cref="ICatHasSubWorkflowState{TSubWorkflowState}.WorkflowState"/>.
    /// A <see cref="CatStepExecutionResult.BreakFromCurrentFlowOnly"/> inside the sub-workflow ends only the sub-workflow.
    /// </summary>
    /// <typeparam name="TSubWorkflow">The workflow to run. It must be registered.</typeparam>
    /// <typeparam name="TSubWorkflowState">The state of the sub-workflow.</typeparam>
    /// <typeparam name="TWorkflowState">The state of the main workflow.</typeparam>
    /// <param name="workflowBuilder">The builder to add the step to.</param>
    /// <returns>A builder to connect the step to the state with <c>Input</c> and <c>Output</c>.</returns>
    public static ICatStepBuilder<TWorkflowState, CatRunSubWorkflowStep<TWorkflowState, TSubWorkflow, TSubWorkflowState>>
        Run<TSubWorkflow, TSubWorkflowState, TWorkflowState>(this ICatWorkflowBuilder<TWorkflowState> workflowBuilder)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>, ICatHasSubWorkflowState<TSubWorkflowState>
        where TSubWorkflow : ICatWorkflow<TSubWorkflowState>
        where TSubWorkflowState : class, ICatWorkflowState<TSubWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatRunSubWorkflowStep<TWorkflowState, TSubWorkflow, TSubWorkflowState>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatRunSubWorkflowStep<TWorkflowState, TSubWorkflow, TSubWorkflowState>>(workflowStep);

        workflowBuilder.WorkflowSteps.Add(workflowStep);
        return stepBuilder;
    }

    /// <summary>
    /// Adds a step that runs your code. The workflow always goes on with the next step.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="body">Gets the workflow state.</param>
    public static void Run<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        Action<TWorkflowState> body)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatInlineActionStep<TWorkflowState>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatInlineActionStep<TWorkflowState>>(workflowStep);

        stepBuilder.Input(state => (l, s) => body(s), step => step.Body);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that runs your code with a logger. The workflow always goes on with the next step.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="body">Gets the logger and the workflow state.</param>
    public static void Run<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        Action<ILogger, TWorkflowState> body)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatInlineActionStep<TWorkflowState>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatInlineActionStep<TWorkflowState>>(workflowStep);

        stepBuilder.Input(state => body, step => step.Body);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that runs your code and decides how the workflow goes on.
    /// A succeeded response carries the <see cref="CatStepExecutionResult"/> to use.
    /// A failed response ends the workflow with <see cref="CatStepExecutionResult.BreakCascade"/> and the errors.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="body">Gets the workflow state.</param>
    public static void Run<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        Func<TWorkflowState, ICatResponse<CatStepExecutionResult>> body)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatInlineFuncStep<TWorkflowState>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatInlineFuncStep<TWorkflowState>>(workflowStep);

        stepBuilder.Input(state => (l, s) => body(s), step => step.Body);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that runs your code with a logger and decides how the workflow goes on.
    /// A succeeded response carries the <see cref="CatStepExecutionResult"/> to use.
    /// A failed response ends the workflow with <see cref="CatStepExecutionResult.BreakCascade"/> and the errors.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="body">Gets the logger and the workflow state.</param>
    public static void Run<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        Func<ILogger, TWorkflowState, ICatResponse<CatStepExecutionResult>> body)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatInlineFuncStep<TWorkflowState>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatInlineFuncStep<TWorkflowState>>(workflowStep);

        stepBuilder.Input(state => body, step => step.Body);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that sets a property of the state.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="stateProperty">Picks the property, like <c>s =&gt; s.Total</c>.</param>
    /// <param name="getPropertyValue">Calculates the new value from the state.</param>
    public static void Set<TWorkflowState, TProperty>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        Expression<Func<TWorkflowState, TProperty>> stateProperty,
        Func<TWorkflowState, TProperty> getPropertyValue)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatSetStatePropertyStep<TWorkflowState, TProperty>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatSetStatePropertyStep<TWorkflowState, TProperty>>(workflowStep);

        stepBuilder.Input(state => stateProperty, step => step.StateProperty);
        stepBuilder.Input(state => (l, s) => getPropertyValue(s), step => step.GetPropertyValue);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that sets a property of the state, using a logger to calculate the value.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="stateProperty">Picks the property, like <c>s =&gt; s.Total</c>.</param>
    /// <param name="getPropertyValue">Calculates the new value from the logger and the state.</param>
    public static void Set<TWorkflowState, TProperty>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        Expression<Func<TWorkflowState, TProperty>> stateProperty,
        Expression<Func<ILogger, TWorkflowState, TProperty>> getPropertyValue)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatSetStatePropertyStep<TWorkflowState, TProperty>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatSetStatePropertyStep<TWorkflowState, TProperty>>(workflowStep);

        stepBuilder.Input(state => stateProperty, step => step.StateProperty);
        stepBuilder.Input(state => getPropertyValue, step => step.GetPropertyValue);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that ends the workflow when the check returns <c>true</c>.
    /// The caller of the workflow goes on as if it succeeded.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="check">Gets the workflow state.</param>
    public static void BreakFromCurrentFlowOnlyIf<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        Func<TWorkflowState, bool> check)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatBreakIfStep<TWorkflowState>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatBreakIfStep<TWorkflowState>>(workflowStep);

        stepBuilder.Input(state => CatBreakType.BreakFromCurrentFlowOnly, step => step.BreakType);
        stepBuilder.Input(state => (l, s) => check(s), step => step.Check);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that ends the workflow when the check returns <c>true</c>, using a logger.
    /// The caller of the workflow goes on as if it succeeded.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="check">Gets the logger and the workflow state.</param>
    public static void BreakFromCurrentFlowOnlyIf<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        Func<ILogger, TWorkflowState, bool> check)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatBreakIfStep<TWorkflowState>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatBreakIfStep<TWorkflowState>>(workflowStep);

        stepBuilder.Input(state => CatBreakType.BreakFromCurrentFlowOnly, step => step.BreakType);
        stepBuilder.Input(state => check, step => step.Check);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that ends the workflow and every workflow around it when the check returns <c>true</c>.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="check">Gets the workflow state.</param>
    public static void BreakCascadeIf<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        Func<TWorkflowState, bool> check)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatBreakIfStep<TWorkflowState>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatBreakIfStep<TWorkflowState>>(workflowStep);

        stepBuilder.Input(state => CatBreakType.BreakCascade, step => step.BreakType);
        stepBuilder.Input(state => (l, s) => check(s), step => step.Check);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that ends the workflow and every workflow around it when the check returns <c>true</c>, using a logger.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="check">Gets the logger and the workflow state.</param>
    public static void BreakCascadeIf<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        Func<ILogger, TWorkflowState, bool> check)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatBreakIfStep<TWorkflowState>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatBreakIfStep<TWorkflowState>>(workflowStep);

        stepBuilder.Input(state => CatBreakType.BreakCascade, step => step.BreakType);
        stepBuilder.Input(state => check, step => step.Check);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that leaves the nearest loop when the check returns <c>true</c>.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="check">Gets the workflow state.</param>
    public static void BreakFromLoopIf<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        Func<TWorkflowState, bool> check)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatBreakIfStep<TWorkflowState>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatBreakIfStep<TWorkflowState>>(workflowStep);

        stepBuilder.Input(state => CatBreakType.BreakFromLoop, step => step.BreakType);
        stepBuilder.Input(state => (l, s) => check(s), step => step.Check);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that leaves the nearest loop when the check returns <c>true</c>, using a logger.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="check">Gets the logger and the workflow state.</param>
    public static void BreakFromLoopIf<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        Func<ILogger, TWorkflowState, bool> check)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatBreakIfStep<TWorkflowState>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatBreakIfStep<TWorkflowState>>(workflowStep);

        stepBuilder.Input(state => CatBreakType.BreakFromLoop, step => step.BreakType);
        stepBuilder.Input(state => check, step => step.Check);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that ends the workflow. The caller of the workflow goes on as if it succeeded.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    public static void BreakFromCurrentFlowOnly<TWorkflowState>(this ICatWorkflowBuilder<TWorkflowState> builder)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatBreakStep>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatBreakStep>(workflowStep);

        stepBuilder.Input(state => CatBreakType.BreakFromCurrentFlowOnly, step => step.BreakType);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that ends the workflow and every workflow around it.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    public static void BreakCascade<TWorkflowState>(this ICatWorkflowBuilder<TWorkflowState> builder)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatBreakStep>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatBreakStep>(workflowStep);

        stepBuilder.Input(state => CatBreakType.BreakCascade, step => step.BreakType);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that leaves the nearest loop.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    public static void BreakFromLoop<TWorkflowState>(this ICatWorkflowBuilder<TWorkflowState> builder)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatBreakStep>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatBreakStep>(workflowStep);

        stepBuilder.Input(state => CatBreakType.BreakFromLoop, step => step.BreakType);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that runs one of two lists of steps, depending on a condition.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="condition">Gets the workflow state.</param>
    /// <param name="buildThen">Adds the steps to run when the condition is <c>true</c>.</param>
    /// <param name="buildElse">Adds the steps to run when the condition is <c>false</c>. Leave it out to do nothing.</param>
    public static void If<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        Func<TWorkflowState, bool> condition,
        Action<ICatWorkflowBuilder<TWorkflowState>> buildThen,
        Action<ICatWorkflowBuilder<TWorkflowState>>? buildElse = null)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatIfStep<TWorkflowState>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatIfStep<TWorkflowState>>(workflowStep);

        stepBuilder.Input(state => condition, step => step.Condition);

        var thenBuilder = new CatWorkflowBuilder<TWorkflowState>();
        buildThen(thenBuilder);
        stepBuilder.Input(state => thenBuilder, step => step.ThenBuilder);

        if (buildElse != null)
        {
            var elseBuilder = new CatWorkflowBuilder<TWorkflowState>();
            buildElse(elseBuilder);
            stepBuilder.Input(state => elseBuilder, step => step.ElseBuilder);
        }

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that repeats a list of steps while a condition is <c>true</c>.
    /// A <see cref="CatStepExecutionResult.BreakFromLoop"/> inside leaves the loop and the workflow goes on.
    /// A <see cref="CatStepExecutionResult.BreakCascade"/> inside leaves the loop and ends the workflow.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="condition">Gets the workflow state. It is checked before every pass.</param>
    /// <param name="build">Adds the steps to repeat.</param>
    public static void While<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        Func<TWorkflowState, bool> condition,
        Action<ICatWorkflowBuilder<TWorkflowState>> build)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatWhileStep<TWorkflowState>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatWhileStep<TWorkflowState>>(workflowStep);

        stepBuilder.Input(state => condition, step => step.Condition);

        var whileBuilder = new CatWorkflowBuilder<TWorkflowState>();
        build(whileBuilder);
        stepBuilder.Input(state => whileBuilder, step => step.Builder);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that runs the list of steps of the case that matches a value.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <typeparam name="TSwitchValue">The type of the value, like an enum.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="switchValue">Gets the value from the workflow state.</param>
    /// <param name="buildSwitchCase">Adds the cases.</param>
    public static void Switch<TWorkflowState, TSwitchValue>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        Func<TWorkflowState, TSwitchValue> switchValue,
        Action<ICatSwitchCaseBuilder<TWorkflowState, TSwitchValue>> buildSwitchCase)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
        where TSwitchValue : struct
    {
        var workflowStep = new CatWorkflowStep<CatSwitchStep<TWorkflowState, TSwitchValue>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatSwitchStep<TWorkflowState, TSwitchValue>>(workflowStep);

        stepBuilder.Input(state => switchValue, step => step.SwitchValue);

        var switchCaseBuilder = new CatSwitchCaseBuilder<TWorkflowState, TSwitchValue>();
        buildSwitchCase(switchCaseBuilder);

        if (switchCaseBuilder.BuildDefaultCase != null)
        {
            var defaultBuilder = new CatWorkflowBuilder<TWorkflowState>();
            switchCaseBuilder.BuildDefaultCase(defaultBuilder);
            stepBuilder.Input(state => defaultBuilder, step => step.DefaultCaseBuilder);
        }

        var caseBuilders = switchCaseBuilder.BuildCases.ToDictionary(d => d.Key, d =>
        {
            var caseBuilder = new CatWorkflowBuilder<TWorkflowState>();
            d.Value(caseBuilder);
            return caseBuilder;
        });
        stepBuilder.Input(state => caseBuilders, step => step.CaseBuilders);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that writes a log entry at the Error level.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="message">The message template, like <c>Order {orderId} failed</c>.</param>
    /// <param name="getArgs">Gets the values for the placeholders from the workflow state.</param>
    public static void LogError<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        string message,
        Func<TWorkflowState, object[]> getArgs)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        builder.Log(LogLevel.Error, message, getArgs);
    }

    /// <summary>
    /// Adds a step that writes a log entry at the Debug level.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="message">The message template, like <c>Order {orderId} failed</c>.</param>
    /// <param name="getArgs">Gets the values for the placeholders from the workflow state.</param>
    public static void LogDebug<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        string message,
        Func<TWorkflowState, object[]> getArgs)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        builder.Log(LogLevel.Debug, message, getArgs);
    }

    /// <summary>
    /// Adds a step that writes a log entry at the Critical level.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="message">The message template, like <c>Order {orderId} failed</c>.</param>
    /// <param name="getArgs">Gets the values for the placeholders from the workflow state.</param>
    public static void LogCritical<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        string message,
        Func<TWorkflowState, object[]> getArgs)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        builder.Log(LogLevel.Critical, message, getArgs);
    }

    /// <summary>
    /// Adds a step that writes a log entry at the Information level.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="message">The message template, like <c>Order {orderId} failed</c>.</param>
    /// <param name="getArgs">Gets the values for the placeholders from the workflow state.</param>
    public static void LogInformation<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        string message,
        Func<TWorkflowState, object[]> getArgs)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        builder.Log(LogLevel.Information, message, getArgs);
    }

    /// <summary>
    /// Adds a step that writes a log entry at the Trace level.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="message">The message template, like <c>Order {orderId} failed</c>.</param>
    /// <param name="getArgs">Gets the values for the placeholders from the workflow state.</param>
    public static void LogTrace<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        string message,
        Func<TWorkflowState, object[]> getArgs)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        builder.Log(LogLevel.Trace, message, getArgs);
    }

    /// <summary>
    /// Adds a step that writes a log entry at the Warning level.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="message">The message template, like <c>Order {orderId} failed</c>.</param>
    /// <param name="getArgs">Gets the values for the placeholders from the workflow state.</param>
    public static void LogWarning<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        string message,
        Func<TWorkflowState, object[]> getArgs)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        builder.Log(LogLevel.Warning, message, getArgs);
    }

    /// <summary>
    /// Adds a step that writes a log entry at the given level.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="logLevel">The level to log at.</param>
    /// <param name="message">The message template, like <c>Order {orderId} failed</c>.</param>
    /// <param name="getArgs">Gets the values for the placeholders from the workflow state.</param>
    public static void Log<TWorkflowState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        LogLevel logLevel,
        string message,
        Func<TWorkflowState, object[]> getArgs)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatLogStep<TWorkflowState>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatLogStep<TWorkflowState>>(workflowStep);

        stepBuilder.Input(state => logLevel, step => step.LogLevel);
        stepBuilder.Input(state => message, step => step.Message);
        stepBuilder.Input(state => getArgs, step => step.GetArgs);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that runs a list of steps for every item of a collection.
    /// The inner steps work on an <see cref="ICatForeachState{TCollection, TWorkflowState}"/>, which holds the current item
    /// and the state of the workflow around the loop.
    /// Let the compiler work out the type arguments, like <c>builder.Foreach(s =&gt; s.Lines, loop =&gt; loop.Run(item =&gt; Process(item)))</c>.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <typeparam name="TCollection">The type of the items.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="collection">Gets the collection from the workflow state.</param>
    /// <param name="build">Adds the steps to run for each item.</param>
    public static void Foreach<TWorkflowState, TCollection>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        Func<TWorkflowState, IEnumerable<TCollection>> collection,
        Action<ICatWorkflowBuilder<ICatForeachState<TCollection, TWorkflowState>>> build)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflowStep = new CatWorkflowStep<CatForeachStep<TWorkflowState, TCollection, ICatForeachState<TCollection, TWorkflowState>>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatForeachStep<TWorkflowState, TCollection, ICatForeachState<TCollection, TWorkflowState>>>(workflowStep);

        stepBuilder.Input(state => collection, step => step.Collection);

        var foreachBuilder = new CatWorkflowBuilder<ICatForeachState<TCollection, TWorkflowState>>();
        build(foreachBuilder);
        stepBuilder.Input(state => foreachBuilder, step => step.Builder);

        builder.WorkflowSteps.Add(workflowStep);
    }

    /// <summary>
    /// Adds a step that runs a list of steps for every item of a collection, on a state class of your own.
    /// Use it when the inner steps need extra data next to the current item. The class needs a parameterless constructor.
    /// Give all three type arguments, like <c>builder.Foreach&lt;OrderState, OrderLine, OrderLineState&gt;(s =&gt; s.Lines, buildLoop)</c>.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <typeparam name="TCollection">The type of the items.</typeparam>
    /// <typeparam name="TForeachState">Your state class for the loop.</typeparam>
    /// <param name="builder">The builder to add the step to.</param>
    /// <param name="collection">Gets the collection from the workflow state.</param>
    /// <param name="build">Adds the steps to run for each item.</param>
    public static void Foreach<TWorkflowState, TCollection, TForeachState>(
        this ICatWorkflowBuilder<TWorkflowState> builder,
        Func<TWorkflowState, IEnumerable<TCollection>> collection,
        Action<ICatWorkflowBuilder<TForeachState>> build)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
        where TForeachState : class, ICatForeachState<TCollection, TWorkflowState>, ICatWorkflowState<TForeachState>
    {
        var workflowStep = new CatWorkflowStep<CatForeachStep<TWorkflowState, TCollection, TForeachState>>();
        var stepBuilder = new CatStepBuilder<TWorkflowState, CatForeachStep<TWorkflowState, TCollection, TForeachState>>(workflowStep);

        stepBuilder.Input(state => collection, step => step.Collection);

        var foreachBuilder = new CatWorkflowBuilder<TForeachState>();
        build(foreachBuilder);
        stepBuilder.Input(state => foreachBuilder, step => step.Builder);

        builder.WorkflowSteps.Add(workflowStep);
    }
}
