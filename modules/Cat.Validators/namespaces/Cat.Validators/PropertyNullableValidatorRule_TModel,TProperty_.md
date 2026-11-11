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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Rules Namespace](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyNullableValidatorRule\<TModel,TProperty\> Class

Runs a check on a nullable value type, like `decimal?`\.
A `null` value passes\. Otherwise the check decides\.

```csharp
internal class PropertyNullableValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, System.Nullable<TProperty>>
    where TModel : class
    where TProperty : struct
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyNullableValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyNullableValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The value type behind the nullable property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyNullableValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNullableValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyNullableValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') → [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyNullableValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNullableValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyNullableValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[TProperty](PropertyNullableValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNullableValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyNullableValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') → [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyNullableValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNullableValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyNullableValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[TProperty](PropertyNullableValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNullableValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyNullableValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') → PropertyNullableValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyNullableValidatorRule\(string, string, Func&lt;TProperty,TModel,ICatCompiledMemberExpressionCache&lt;TModel&gt;,object\[\]&gt;\)](PropertyNullableValidatorRule_TModel,TProperty_..ctor.CXV9GKPRXI2UPUR3TKD0X21HE.md 'Cat\.Validators\.Rules\.PropertyNullableValidatorRule\<TModel,TProperty\>\.PropertyNullableValidatorRule\(string, string, System\.Func\<TProperty,TModel,Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\<TModel\>,object\[\]\>\)') | Runs a check on a nullable value type, like `decimal?`\. A `null` value passes\. Otherwise the check decides\. |

| Methods | |
| :--- | :--- |
| [Validate\(Nullable&lt;TProperty&gt;, string, TModel\)](PropertyNullableValidatorRule_TModel,TProperty_.Validate.OT4DUDVXU2W5MWTG423L67YQ9.md 'Cat\.Validators\.Rules\.PropertyNullableValidatorRule\<TModel,TProperty\>\.Validate\(System\.Nullable\<TProperty\>, string, TModel\)') | |
