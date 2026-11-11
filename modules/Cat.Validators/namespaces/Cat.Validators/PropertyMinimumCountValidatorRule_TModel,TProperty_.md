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

## PropertyMinimumCountValidatorRule\<TModel,TProperty\> Class

Passes when the collection has at least the minimum number of items\. A `null` collection passes\.
Fails with [MinimumCount](CatValidatorErrorDefinitions.MinimumCount.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MinimumCount') otherwise\.

```csharp
internal class PropertyMinimumCountValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : System.Collections.IEnumerable?
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyMinimumCountValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyMinimumCountValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the collection\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyMinimumCountValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyMinimumCountValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyMinimumCountValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') → [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyMinimumCountValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyMinimumCountValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyMinimumCountValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyMinimumCountValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyMinimumCountValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyMinimumCountValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') → [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyMinimumCountValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyMinimumCountValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyMinimumCountValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyMinimumCountValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyMinimumCountValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyMinimumCountValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') → PropertyMinimumCountValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyMinimumCountValidatorRule\(Func&lt;TModel,int&gt;\)](PropertyMinimumCountValidatorRule_TModel,TProperty_..ctor.8G8AY8W0Z9UXUGYRTEK4698Z5.md 'Cat\.Validators\.Rules\.PropertyMinimumCountValidatorRule\<TModel,TProperty\>\.PropertyMinimumCountValidatorRule\(System\.Func\<TModel,int\>\)') | Passes when the collection has at least the minimum number of items\. A `null` collection passes\. Fails with [MinimumCount](CatValidatorErrorDefinitions.MinimumCount.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MinimumCount') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyMinimumCountValidatorRule_TModel,TProperty_.Validate.VSZLGXMLUIJCU73YQJ8KOLQMA.md 'Cat\.Validators\.Rules\.PropertyMinimumCountValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
