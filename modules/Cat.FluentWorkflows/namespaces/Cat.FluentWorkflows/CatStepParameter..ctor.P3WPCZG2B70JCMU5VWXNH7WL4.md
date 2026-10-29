<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') > [CatStepParameter](CatStepParameter.md 'Cat\.FluentWorkflows\.CatStepParameter')

## CatStepParameter\(LambdaExpression, LambdaExpression\) Constructor

Creates the parameter\.

```csharp
public CatStepParameter(System.Linq.Expressions.LambdaExpression source, System.Linq.Expressions.LambdaExpression target);
```
#### Parameters

<a name='Cat.FluentWorkflows.CatStepParameter.CatStepParameter(System.Linq.Expressions.LambdaExpression,System.Linq.Expressions.LambdaExpression).source'></a>

`source` [System\.Linq\.Expressions\.LambdaExpression](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.lambdaexpression 'System\.Linq\.Expressions\.LambdaExpression')

Reads the value\.

<a name='Cat.FluentWorkflows.CatStepParameter.CatStepParameter(System.Linq.Expressions.LambdaExpression,System.Linq.Expressions.LambdaExpression).target'></a>

`target` [System\.Linq\.Expressions\.LambdaExpression](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.lambdaexpression 'System\.Linq\.Expressions\.LambdaExpression')

Picks the member to write\. Its body must be a member access\.

#### Exceptions

[System\.NotSupportedException](https://learn.microsoft.com/en-us/dotnet/api/system.notsupportedexception 'System\.NotSupportedException')  
The target is not a member access\.