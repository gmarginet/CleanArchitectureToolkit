<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators')

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

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](CatValidatorPropertyRuleBase_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleBase_TModel,TProperty_.TModel 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](CatValidatorPropertyRuleBase_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleBase_TModel,TProperty_.TModel 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](CatValidatorPropertyRuleBase_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleBase_TModel,TProperty_.TProperty 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; CatValidatorPropertyRuleBase\<TModel,TProperty\>

Derived  
&#8627; [PropertyEmptyValidatorRule&lt;TModel,TProperty&gt;](PropertyEmptyValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyEmptyValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyEqualValidatorRule&lt;TModel,TProperty&gt;](PropertyEqualValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyEqualValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyEqualWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyEqualWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyEqualWithFuncValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyExclusiveBetweenValidatorRule&lt;TModel,TProperty&gt;](PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyExclusiveBetweenWithComparerValidatorRule&lt;TModel,TProperty&gt;](PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyExclusiveBetweenWithFuncAndComparerValidatorRule&lt;TModel,TProperty&gt;](PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyExclusiveBetweenWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyExclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyGreaterThanOrEqualToValidatorRule&lt;TModel,TProperty&gt;](PropertyGreaterThanOrEqualToValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyGreaterThanOrEqualToValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyGreaterThanOrEqualToWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyGreaterThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyGreaterThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyGreaterThanValidatorRule&lt;TModel,TProperty&gt;](PropertyGreaterThanValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyGreaterThanValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyGreaterThanWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyGreaterThanWithFuncValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyInclusiveBetweenValidatorRule&lt;TModel,TProperty&gt;](PropertyInclusiveBetweenValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyInclusiveBetweenWithComparerValidatorRule&lt;TModel,TProperty&gt;](PropertyInclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyInclusiveBetweenWithFuncAndComparerValidatorRule&lt;TModel,TProperty&gt;](PropertyInclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyInclusiveBetweenWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyLessThanOrEqualToValidatorRule&lt;TModel,TProperty&gt;](PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyLessThanOrEqualToWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyLessThanValidatorRule&lt;TModel,TProperty&gt;](PropertyLessThanValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyLessThanValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyLessThanWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyLessThanWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyLessThanWithFuncValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyModelMustValidatorRule&lt;TModel,TProperty&gt;](PropertyModelMustValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyModelMustValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyMustValidatorRule&lt;TModel,TProperty&gt;](PropertyMustValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyMustValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyNotEmptyValidatorRule&lt;TModel,TProperty&gt;](PropertyNotEmptyValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyNotEmptyValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyNotEqualValidatorRule&lt;TModel,TProperty&gt;](PropertyNotEqualValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyNotEqualValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyNotEqualWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyNotNullValidatorRule&lt;TModel,TProperty&gt;](PropertyNotNullValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyNotNullValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyNullValidatorRule&lt;TModel,TProperty&gt;](PropertyNullValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyNullValidatorRule\<TModel,TProperty\>')  
&#8627; [PropertyStringExactLengthValidatorRule&lt;TModel&gt;](PropertyStringExactLengthValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringExactLengthValidatorRule\<TModel\>')  
&#8627; [PropertyStringExactLengthWithFuncValidatorRule&lt;TModel&gt;](PropertyStringExactLengthWithFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringExactLengthWithFuncValidatorRule\<TModel\>')  
&#8627; [PropertyStringLengthValidatorRule&lt;TModel&gt;](PropertyStringLengthValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringLengthValidatorRule\<TModel\>')  
&#8627; [PropertyStringLengthWithFuncValidatorRule&lt;TModel&gt;](PropertyStringLengthWithFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringLengthWithFuncValidatorRule\<TModel\>')  
&#8627; [PropertyStringMatchesRegexValidatorRule&lt;TModel&gt;](PropertyStringMatchesRegexValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexValidatorRule\<TModel\>')  
&#8627; [PropertyStringMatchesRegexWithFuncValidatorRule&lt;TModel&gt;](PropertyStringMatchesRegexWithFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithFuncValidatorRule\<TModel\>')  
&#8627; [PropertyStringMatchesRegexWithPatternFuncValidatorRule&lt;TModel&gt;](PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternFuncValidatorRule\<TModel\>')  
&#8627; [PropertyStringMatchesRegexWithPatternValidatorRule&lt;TModel&gt;](PropertyStringMatchesRegexWithPatternValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternValidatorRule\<TModel\>')  
&#8627; [PropertyStringMaximumLengthValidatorRule&lt;TModel&gt;](PropertyStringMaximumLengthValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMaximumLengthValidatorRule\<TModel\>')  
&#8627; [PropertyStringMaximumLengthWithFuncValidatorRule&lt;TModel&gt;](PropertyStringMaximumLengthWithFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMaximumLengthWithFuncValidatorRule\<TModel\>')  
&#8627; [PropertyStringMinimumLengthValidatorRule&lt;TModel&gt;](PropertyStringMinimumLengthValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMinimumLengthValidatorRule\<TModel\>')  
&#8627; [PropertyStringMinimumLengthWithFuncValidatorRule&lt;TModel&gt;](PropertyStringMinimumLengthWithFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMinimumLengthWithFuncValidatorRule\<TModel\>')

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](CatValidatorPropertyRuleBase_TModel,TProperty_.Validate.RSZE6ZDT1113PI6TY7Y29ECGE.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | Runs the rule against the property value\. |
| [ValidateAsync\(TProperty, string, TModel, CancellationToken\)](CatValidatorPropertyRuleBase_TModel,TProperty_.ValidateAsync.KR7WDVAKVE7QLBPGL1E0EWRF5.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>\.ValidateAsync\(TProperty, string, TModel, System\.Threading\.CancellationToken\)') | Runs the rule against the property value\. |
