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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Rules Namespace](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## ModelMustAsyncValidatorRule\<TModel\> Class

Checks the whole model with your own async code\.

```csharp
internal class ModelMustAsyncValidatorRule<TModel> : Cat.Validators.CatValidatorModelRuleAsyncBase<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.ModelMustAsyncValidatorRule_TModel_.TModel'></a>

`TModel`

The type being validated\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](ModelMustAsyncValidatorRule_TModel_.md#Cat.Validators.Rules.ModelMustAsyncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.ModelMustAsyncValidatorRule\<TModel\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') → ModelMustAsyncValidatorRule\<TModel\>

| Constructors | |
| :--- | :--- |
| [ModelMustAsyncValidatorRule\(Func&lt;TModel,CancellationToken,Task&lt;List&lt;ICatValidatorError&gt;&gt;&gt;\)](ModelMustAsyncValidatorRule_TModel_..ctor.0QDR9YXMZA86BCQS78BWIH25B.md 'Cat\.Validators\.Rules\.ModelMustAsyncValidatorRule\<TModel\>\.ModelMustAsyncValidatorRule\(System\.Func\<TModel,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\>\)') | Checks the whole model with your own async code\. |

| Methods | |
| :--- | :--- |
| [ValidateAsync\(TModel, CancellationToken\)](ModelMustAsyncValidatorRule_TModel_.ValidateAsync.E4M9Z45B1WFUY7KVCLBBQ86P6.md 'Cat\.Validators\.Rules\.ModelMustAsyncValidatorRule\<TModel\>\.ValidateAsync\(TModel, System\.Threading\.CancellationToken\)') | |
