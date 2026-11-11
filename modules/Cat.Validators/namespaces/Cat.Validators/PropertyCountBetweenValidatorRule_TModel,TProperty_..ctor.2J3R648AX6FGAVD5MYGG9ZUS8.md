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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Rules Namespace](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') >> [PropertyCountBetweenValidatorRule&lt;TModel,TProperty&gt; Class](PropertyCountBetweenValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyCountBetweenValidatorRule\<TModel,TProperty\>')

## PropertyCountBetweenValidatorRule\(Func\<TModel,int\>, Func\<TModel,int\>\) Constructor

Passes when the number of items is between the minimum and the maximum, both included\. A `null` collection passes\.
Throws when the minimum is greater than the maximum\.
Fails with [CountBetween](CatValidatorErrorDefinitions.CountBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.CountBetween') otherwise\.

```csharp
public PropertyCountBetweenValidatorRule(System.Func<TModel,int> minFunc, System.Func<TModel,int> maxFunc);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyCountBetweenValidatorRule_TModel,TProperty_.PropertyCountBetweenValidatorRule(System.Func_TModel,int_,System.Func_TModel,int_).minFunc'></a>

`minFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyCountBetweenValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyCountBetweenValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyCountBetweenValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

<a name='Cat.Validators.Rules.PropertyCountBetweenValidatorRule_TModel,TProperty_.PropertyCountBetweenValidatorRule(System.Func_TModel,int_,System.Func_TModel,int_).maxFunc'></a>

`maxFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyCountBetweenValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyCountBetweenValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyCountBetweenValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')