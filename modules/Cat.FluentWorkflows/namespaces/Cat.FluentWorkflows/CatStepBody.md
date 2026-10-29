<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatStepBody Class

Base class for a step that works synchronously and doesn't need the workflow state directly\.
Get its data through `Input` and hand results back through `Output`\. Implement [Run\(\)](CatStepBody.Run().md 'Cat\.FluentWorkflows\.CatStepBody\.Run\(\)')\.

```csharp
public abstract class CatStepBody : Cat.FluentWorkflows.CatStepBodyAsync
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') &#129106; CatStepBody

Derived  
&#8627; [CatBreakStep](CatBreakStep.md 'Cat\.FluentWorkflows\.Steps\.CatBreakStep')

| Constructors | |
| :--- | :--- |
| [CatStepBody\(ILogger\)](CatStepBody..ctor.PRKLCTCDL24JHB32LR876DDKB.md 'Cat\.FluentWorkflows\.CatStepBody\.CatStepBody\(Microsoft\.Extensions\.Logging\.ILogger\)') | Creates the step\. |

| Methods | |
| :--- | :--- |
| [Run\(\)](CatStepBody.Run().md 'Cat\.FluentWorkflows\.CatStepBody\.Run\(\)') | Does the work of the step\. |
| [RunAsync\(CancellationToken\)](CatStepBody.RunAsync.F0CROBL00G1DJYC6ZWR3F6RU9.md 'Cat\.FluentWorkflows\.CatStepBody\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
