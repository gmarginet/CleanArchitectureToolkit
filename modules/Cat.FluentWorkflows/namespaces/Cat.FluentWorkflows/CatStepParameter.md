<link href="../../../../resources/styles/style.css" rel="stylesheet"/>
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatStepParameter Class

Default [ICatStepParameter](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepParameter.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepParameter')\.
Reads a value with one expression and writes it with another\. A `null` value writes the default of the target type\.

```csharp
public class CatStepParameter : Cat.FluentWorkflows.Abstractions.ICatStepParameter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatStepParameter

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
