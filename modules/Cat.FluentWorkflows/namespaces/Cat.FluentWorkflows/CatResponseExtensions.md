<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Extensions](Cat.FluentWorkflows.Extensions.md 'Cat\.FluentWorkflows\.Extensions')

## CatResponseExtensions Class

Turns a response of a command, a query or a service request into a workflow response\.

```csharp
public static class CatResponseExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatResponseExtensions

| Methods | |
| :--- | :--- |
| [Cast\(this ICatResponse, CatStepExecutionResult\)](CatResponseExtensions.Cast.md#Cat.FluentWorkflows.Extensions.CatResponseExtensions.Cast(thisCat.Responses.Abstractions.ICatResponse,Cat.FluentWorkflows.Abstractions.CatStepExecutionResult) 'Cat\.FluentWorkflows\.Extensions\.CatResponseExtensions\.Cast\(this Cat\.Responses\.Abstractions\.ICatResponse, Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)') | Turns a response into a workflow response\. The errors of a failed response come along\. |
| [Cast&lt;TSource&gt;\(this ICatResponse&lt;TSource&gt;, CatStepExecutionResult\)](CatResponseExtensions.Cast.md#Cat.FluentWorkflows.Extensions.CatResponseExtensions.Cast_TSource_(thisCat.Responses.Abstractions.ICatResponse_TSource_,Cat.FluentWorkflows.Abstractions.CatStepExecutionResult) 'Cat\.FluentWorkflows\.Extensions\.CatResponseExtensions\.Cast\<TSource\>\(this Cat\.Responses\.Abstractions\.ICatResponse\<TSource\>, Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\)') | Turns a response with a payload into a workflow response\. The payload is dropped and the errors of a failed response come along\. |
