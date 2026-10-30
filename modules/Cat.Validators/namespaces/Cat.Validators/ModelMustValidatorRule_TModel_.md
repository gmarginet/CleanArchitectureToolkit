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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Rules Namespace](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## ModelMustValidatorRule\<TModel\> Class

Checks the whole model with your own code\.

```csharp
internal class ModelMustValidatorRule<TModel> : Cat.Validators.CatValidatorModelRuleBase<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.ModelMustValidatorRule_TModel_.TModel'></a>

`TModel`

The type being validated\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](ModelMustValidatorRule_TModel_.md#Cat.Validators.Rules.ModelMustValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.ModelMustValidatorRule\<TModel\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') → [Cat\.Validators\.CatValidatorModelRuleBase&lt;](CatValidatorModelRuleBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>')[TModel](ModelMustValidatorRule_TModel_.md#Cat.Validators.Rules.ModelMustValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.ModelMustValidatorRule\<TModel\>\.TModel')[&gt;](CatValidatorModelRuleBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>') → ModelMustValidatorRule\<TModel\>

| Constructors | |
| :--- | :--- |
| [ModelMustValidatorRule\(Func&lt;TModel,List&lt;ICatValidatorError&gt;&gt;\)](ModelMustValidatorRule_TModel_..ctor.14EHNGQVKXH6I2OCTJN78M598.md 'Cat\.Validators\.Rules\.ModelMustValidatorRule\<TModel\>\.ModelMustValidatorRule\(System\.Func\<TModel,System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\)') | Checks the whole model with your own code\. |

| Methods | |
| :--- | :--- |
| [Validate\(TModel\)](ModelMustValidatorRule_TModel_.Validate.NSP625J6MZTAJL5VES09QI7R.md 'Cat\.Validators\.Rules\.ModelMustValidatorRule\<TModel\>\.Validate\(TModel\)') | |
