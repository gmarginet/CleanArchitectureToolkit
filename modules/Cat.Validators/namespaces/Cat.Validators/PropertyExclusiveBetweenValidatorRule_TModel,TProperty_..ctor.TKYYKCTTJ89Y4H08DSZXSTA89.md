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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Rules Namespace](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') >> [PropertyExclusiveBetweenValidatorRule&lt;TModel,TProperty&gt; Class](PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenValidatorRule\<TModel,TProperty\>')

## PropertyExclusiveBetweenValidatorRule\(TProperty, TProperty\) Constructor

Passes when the value is greater than the lower bound and less than the upper bound\.
Fails with [ExclusiveBetween](CatValidatorErrorDefinitions.ExclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExclusiveBetween') otherwise\.

```csharp
public PropertyExclusiveBetweenValidatorRule(TProperty lowerBound, TProperty upperBound);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.PropertyExclusiveBetweenValidatorRule(TProperty,TProperty).lowerBound'></a>

`lowerBound` [TProperty](PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenValidatorRule\<TModel,TProperty\>\.TProperty')

<a name='Cat.Validators.Rules.PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.PropertyExclusiveBetweenValidatorRule(TProperty,TProperty).upperBound'></a>

`upperBound` [TProperty](PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenValidatorRule\<TModel,TProperty\>\.TProperty')