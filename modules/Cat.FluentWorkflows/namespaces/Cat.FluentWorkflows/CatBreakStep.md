<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps')

## CatBreakStep Class

Built\-in step behind `BreakCascade`, `BreakFromCurrentFlowOnly` and `BreakFromLoop`\.
It always breaks the way [BreakType](CatBreakStep.BreakType.md 'Cat\.FluentWorkflows\.Steps\.CatBreakStep\.BreakType') says\.

```csharp
public class CatBreakStep : Cat.FluentWorkflows.CatStepBody
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') &#129106; [CatStepBody](CatStepBody.md 'Cat\.FluentWorkflows\.CatStepBody') &#129106; CatBreakStep

| Constructors | |
| :--- | :--- |
| [CatBreakStep\(ILogger&lt;CatBreakStep&gt;\)](CatBreakStep..ctor.MYV86KUK3UZ7WDO40EZQ6KTZE.md 'Cat\.FluentWorkflows\.Steps\.CatBreakStep\.CatBreakStep\(Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Steps\.CatBreakStep\>\)') | Creates the step\. |

| Properties | |
| :--- | :--- |
| [BreakType](CatBreakStep.BreakType.md 'Cat\.FluentWorkflows\.Steps\.CatBreakStep\.BreakType') | The kind of break to make\. |

| Methods | |
| :--- | :--- |
| [Run\(\)](CatBreakStep.Run().md 'Cat\.FluentWorkflows\.Steps\.CatBreakStep\.Run\(\)') | Does the work of the step\. |
