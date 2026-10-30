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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators Namespace](Cat.Validators.md 'Cat\.Validators')

## CatValidatorModelRuleBase\<TModel\> Class

Base class for a model rule that works synchronously\.
Derive from it when you write your own rule and implement [Validate\(TModel\)](CatValidatorModelRuleBase_TModel_.Validate.EDFM9C738YN95FGOSBK6X26O4.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>\.Validate\(TModel\)')\.

```csharp
public abstract class CatValidatorModelRuleBase<TModel> : Cat.Validators.CatValidatorModelRuleAsyncBase<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.CatValidatorModelRuleBase_TModel_.TModel'></a>

`TModel`

The type being validated\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](CatValidatorModelRuleBase_TModel_.md#Cat.Validators.CatValidatorModelRuleBase_TModel_.TModel 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') → CatValidatorModelRuleBase\<TModel\>

Derived  
↳ [ModelMustValidatorRule&lt;TModel&gt;](ModelMustValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.ModelMustValidatorRule\<TModel\>')

| Methods | |
| :--- | :--- |
| [Validate\(TModel\)](CatValidatorModelRuleBase_TModel_.Validate.EDFM9C738YN95FGOSBK6X26O4.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>\.Validate\(TModel\)') | Runs the rule\. |
| [ValidateAsync\(TModel, CancellationToken\)](CatValidatorModelRuleBase_TModel_.ValidateAsync.ZOFUXL5PEI6F097RSRSC7PZOC.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>\.ValidateAsync\(TModel, System\.Threading\.CancellationToken\)') | Runs the rule\. |
