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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Rules Namespace](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') >> [PropertyMinimumCountValidatorRule&lt;TModel,TProperty&gt; Class](PropertyMinimumCountValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyMinimumCountValidatorRule\<TModel,TProperty\>')

## PropertyMinimumCountValidatorRule\(Func\<TModel,int\>\) Constructor

Passes when the collection has at least the minimum number of items\. A `null` collection passes\.
Fails with [MinimumCount](CatValidatorErrorDefinitions.MinimumCount.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MinimumCount') otherwise\.

```csharp
public PropertyMinimumCountValidatorRule(System.Func<TModel,int> minimumCountFunc);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyMinimumCountValidatorRule_TModel,TProperty_.PropertyMinimumCountValidatorRule(System.Func_TModel,int_).minimumCountFunc'></a>

`minimumCountFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyMinimumCountValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyMinimumCountValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyMinimumCountValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')