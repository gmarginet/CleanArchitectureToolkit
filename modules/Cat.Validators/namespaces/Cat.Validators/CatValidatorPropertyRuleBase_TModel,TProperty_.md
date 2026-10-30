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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators Namespace](Cat.Validators.md 'Cat\.Validators')

## CatValidatorPropertyRuleBase\<TModel,TProperty\> Class

Base class for a property rule that works synchronously\.
Derive from it when you write your own rule and implement [Validate\(TProperty, string, TModel\)](CatValidatorPropertyRuleBase_TModel,TProperty_.Validate.RSZE6ZDT1113PI6TY7Y29ECGE.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)')\.

```csharp
public abstract class CatValidatorPropertyRuleBase<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleAsyncBase<TModel, TProperty>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.CatValidatorPropertyRuleBase_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.CatValidatorPropertyRuleBase_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](CatValidatorPropertyRuleBase_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleBase_TModel,TProperty_.TModel 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') → [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](CatValidatorPropertyRuleBase_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleBase_TModel,TProperty_.TModel 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](CatValidatorPropertyRuleBase_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleBase_TModel,TProperty_.TProperty 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') → CatValidatorPropertyRuleBase\<TModel,TProperty\>

Derived  
↳ [PropertyEmptyValidatorRule&lt;TModel,TProperty&gt;](PropertyEmptyValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyEmptyValidatorRule\<TModel,TProperty\>')  
↳ [PropertyEqualValidatorRule&lt;TModel,TProperty&gt;](PropertyEqualValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyEqualValidatorRule\<TModel,TProperty\>')  
↳ [PropertyEqualWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyEqualWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyEqualWithFuncValidatorRule\<TModel,TProperty\>')  
↳ [PropertyExclusiveBetweenValidatorRule&lt;TModel,TProperty&gt;](PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenValidatorRule\<TModel,TProperty\>')  
↳ [PropertyExclusiveBetweenWithComparerValidatorRule&lt;TModel,TProperty&gt;](PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>')  
↳ [PropertyExclusiveBetweenWithFuncAndComparerValidatorRule&lt;TModel,TProperty&gt;](PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>')  
↳ [PropertyExclusiveBetweenWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyExclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>')  
↳ [PropertyGreaterThanOrEqualToValidatorRule&lt;TModel,TProperty&gt;](PropertyGreaterThanOrEqualToValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyGreaterThanOrEqualToValidatorRule\<TModel,TProperty\>')  
↳ [PropertyGreaterThanOrEqualToWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyGreaterThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyGreaterThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>')  
↳ [PropertyGreaterThanValidatorRule&lt;TModel,TProperty&gt;](PropertyGreaterThanValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyGreaterThanValidatorRule\<TModel,TProperty\>')  
↳ [PropertyGreaterThanWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyGreaterThanWithFuncValidatorRule\<TModel,TProperty\>')  
↳ [PropertyInclusiveBetweenValidatorRule&lt;TModel,TProperty&gt;](PropertyInclusiveBetweenValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenValidatorRule\<TModel,TProperty\>')  
↳ [PropertyInclusiveBetweenWithComparerValidatorRule&lt;TModel,TProperty&gt;](PropertyInclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>')  
↳ [PropertyInclusiveBetweenWithFuncAndComparerValidatorRule&lt;TModel,TProperty&gt;](PropertyInclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>')  
↳ [PropertyInclusiveBetweenWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>')  
↳ [PropertyLessThanOrEqualToValidatorRule&lt;TModel,TProperty&gt;](PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToValidatorRule\<TModel,TProperty\>')  
↳ [PropertyLessThanOrEqualToWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>')  
↳ [PropertyLessThanValidatorRule&lt;TModel,TProperty&gt;](PropertyLessThanValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyLessThanValidatorRule\<TModel,TProperty\>')  
↳ [PropertyLessThanWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyLessThanWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyLessThanWithFuncValidatorRule\<TModel,TProperty\>')  
↳ [PropertyModelMustValidatorRule&lt;TModel,TProperty&gt;](PropertyModelMustValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyModelMustValidatorRule\<TModel,TProperty\>')  
↳ [PropertyMustValidatorRule&lt;TModel,TProperty&gt;](PropertyMustValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyMustValidatorRule\<TModel,TProperty\>')  
↳ [PropertyNotEmptyValidatorRule&lt;TModel,TProperty&gt;](PropertyNotEmptyValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyNotEmptyValidatorRule\<TModel,TProperty\>')  
↳ [PropertyNotEqualValidatorRule&lt;TModel,TProperty&gt;](PropertyNotEqualValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyNotEqualValidatorRule\<TModel,TProperty\>')  
↳ [PropertyNotEqualWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>')  
↳ [PropertyNotNullValidatorRule&lt;TModel,TProperty&gt;](PropertyNotNullValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyNotNullValidatorRule\<TModel,TProperty\>')  
↳ [PropertyNullValidatorRule&lt;TModel,TProperty&gt;](PropertyNullValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyNullValidatorRule\<TModel,TProperty\>')  
↳ [PropertyStringExactLengthValidatorRule&lt;TModel&gt;](PropertyStringExactLengthValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringExactLengthValidatorRule\<TModel\>')  
↳ [PropertyStringExactLengthWithFuncValidatorRule&lt;TModel&gt;](PropertyStringExactLengthWithFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringExactLengthWithFuncValidatorRule\<TModel\>')  
↳ [PropertyStringLengthValidatorRule&lt;TModel&gt;](PropertyStringLengthValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringLengthValidatorRule\<TModel\>')  
↳ [PropertyStringLengthWithFuncValidatorRule&lt;TModel&gt;](PropertyStringLengthWithFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringLengthWithFuncValidatorRule\<TModel\>')  
↳ [PropertyStringMatchesRegexValidatorRule&lt;TModel&gt;](PropertyStringMatchesRegexValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexValidatorRule\<TModel\>')  
↳ [PropertyStringMatchesRegexWithFuncValidatorRule&lt;TModel&gt;](PropertyStringMatchesRegexWithFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithFuncValidatorRule\<TModel\>')  
↳ [PropertyStringMatchesRegexWithPatternFuncValidatorRule&lt;TModel&gt;](PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternFuncValidatorRule\<TModel\>')  
↳ [PropertyStringMatchesRegexWithPatternValidatorRule&lt;TModel&gt;](PropertyStringMatchesRegexWithPatternValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternValidatorRule\<TModel\>')  
↳ [PropertyStringMaximumLengthValidatorRule&lt;TModel&gt;](PropertyStringMaximumLengthValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMaximumLengthValidatorRule\<TModel\>')  
↳ [PropertyStringMaximumLengthWithFuncValidatorRule&lt;TModel&gt;](PropertyStringMaximumLengthWithFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMaximumLengthWithFuncValidatorRule\<TModel\>')  
↳ [PropertyStringMinimumLengthValidatorRule&lt;TModel&gt;](PropertyStringMinimumLengthValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMinimumLengthValidatorRule\<TModel\>')  
↳ [PropertyStringMinimumLengthWithFuncValidatorRule&lt;TModel&gt;](PropertyStringMinimumLengthWithFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMinimumLengthWithFuncValidatorRule\<TModel\>')

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](CatValidatorPropertyRuleBase_TModel,TProperty_.Validate.RSZE6ZDT1113PI6TY7Y29ECGE.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | Runs the rule against the property value\. |
| [ValidateAsync\(TProperty, string, TModel, CancellationToken\)](CatValidatorPropertyRuleBase_TModel,TProperty_.ValidateAsync.KR7WDVAKVE7QLBPGL1E0EWRF5.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>\.ValidateAsync\(TProperty, string, TModel, System\.Threading\.CancellationToken\)') | Runs the rule against the property value\. |
