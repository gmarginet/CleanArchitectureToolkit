<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatStepParameter Class

Default [ICatStepParameter](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepParameter.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepParameter')\.
Reads a value with one expression and writes it with another\. A `null` value writes the default of the target type\.

```csharp
public class CatStepParameter : Cat.FluentWorkflows.Abstractions.ICatStepParameter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatStepParameter

Implements [ICatStepParameter](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepParameter.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepParameter')

| Constructors | |
| :--- | :--- |
| [CatStepParameter\(LambdaExpression, LambdaExpression\)](CatStepParameter..ctor.P3WPCZG2B70JCMU5VWXNH7WL4.md 'Cat\.FluentWorkflows\.CatStepParameter\.CatStepParameter\(System\.Linq\.Expressions\.LambdaExpression, System\.Linq\.Expressions\.LambdaExpression\)') | Creates the parameter\. |

| Fields | |
| :--- | :--- |
| [\_sourceExp](CatStepParameter._sourceExp.md 'Cat\.FluentWorkflows\.CatStepParameter\.\_sourceExp') | |
| [\_targetExp](CatStepParameter._targetExp.md 'Cat\.FluentWorkflows\.CatStepParameter\.\_targetExp') | |

| Methods | |
| :--- | :--- |
| [Assign\(object, object\)](CatStepParameter.Assign.Q40QATFCU97LS7ZEJKBA838CB.md 'Cat\.FluentWorkflows\.CatStepParameter\.Assign\(object, object\)') | Reads the value from the source and writes it to the target\. |
