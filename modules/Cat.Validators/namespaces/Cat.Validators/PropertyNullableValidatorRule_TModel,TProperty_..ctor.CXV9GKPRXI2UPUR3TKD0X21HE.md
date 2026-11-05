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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Rules Namespace](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') >> [PropertyNullableValidatorRule&lt;TModel,TProperty&gt; Class](PropertyNullableValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyNullableValidatorRule\<TModel,TProperty\>')

## PropertyNullableValidatorRule\(string, string, Func\<TProperty,TModel,ICatCompiledMemberExpressionCache\<TModel\>,object\[\]\>\) Constructor

Runs a check on a nullable value type, like `decimal?`\.
A `null` value passes\. Otherwise the check decides\.

```csharp
public PropertyNullableValidatorRule(string code, string message, System.Func<TProperty,TModel,Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache<TModel>,object?[]?> check);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyNullableValidatorRule_TModel,TProperty_.PropertyNullableValidatorRule(string,string,System.Func_TProperty,TModel,Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache_TModel_,object[]_).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error code when the check fails\.

<a name='Cat.Validators.Rules.PropertyNullableValidatorRule_TModel,TProperty_.PropertyNullableValidatorRule(string,string,System.Func_TProperty,TModel,Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache_TModel_,object[]_).message'></a>

`message` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error message when the check fails\.

<a name='Cat.Validators.Rules.PropertyNullableValidatorRule_TModel,TProperty_.PropertyNullableValidatorRule(string,string,System.Func_TProperty,TModel,Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache_TModel_,object[]_).check'></a>

`check` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[TProperty](PropertyNullableValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNullableValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyNullableValidatorRule\<TModel,TProperty\>\.TProperty')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[TModel](PropertyNullableValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNullableValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyNullableValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache&lt;](../../../Cat.Expressions/namespaces/Cat.Expressions.Abstractions/ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1')[TModel](PropertyNullableValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNullableValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyNullableValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](../../../Cat.Expressions/namespaces/Cat.Expressions.Abstractions/ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')

Gets the value, the model and the expression cache\. Returns `null` when the value is valid, or the error arguments when it is not\.