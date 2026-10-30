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
            <img src='../../../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') >> [CatStepParameter Class](CatStepParameter.md 'Cat\.FluentWorkflows\.CatStepParameter')

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