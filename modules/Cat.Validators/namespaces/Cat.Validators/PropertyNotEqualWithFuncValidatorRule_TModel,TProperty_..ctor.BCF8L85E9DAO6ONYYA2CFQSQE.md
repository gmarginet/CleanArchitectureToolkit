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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Rules Namespace](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') >> [PropertyNotEqualWithFuncValidatorRule&lt;TModel,TProperty&gt; Class](PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>')

## PropertyNotEqualWithFuncValidatorRule\(Expression\<Func\<TModel,TProperty\>\>, IEqualityComparer\<TProperty\>\) Constructor

Passes when the value doesn't equal another property of the model\.
Fails with [NotEqual](CatValidatorErrorDefinitions.NotEqual.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.NotEqual') otherwise\.

```csharp
public PropertyNotEqualWithFuncValidatorRule(System.Linq.Expressions.Expression<System.Func<TModel,TProperty>> expression, System.Collections.Generic.IEqualityComparer<TProperty?>? comparer=null);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.PropertyNotEqualWithFuncValidatorRule(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,System.Collections.Generic.IEqualityComparer_TProperty_).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

<a name='Cat.Validators.Rules.PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.PropertyNotEqualWithFuncValidatorRule(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,System.Collections.Generic.IEqualityComparer_TProperty_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IEqualityComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1 'System\.Collections\.Generic\.IEqualityComparer\`1')[TProperty](PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1 'System\.Collections\.Generic\.IEqualityComparer\`1')