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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Rules Namespace](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') >> [PropertyStringMatchesRegexWithPatternFuncValidatorRule&lt;TModel&gt; Class](PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternFuncValidatorRule\<TModel\>')

## PropertyStringMatchesRegexWithPatternFuncValidatorRule\(Func\<TModel,string\>, RegexOptions\) Constructor

Passes when the text matches a regular expression pattern taken from the model\. A `null` string passes\.
Fails with [MatchesRegex](CatValidatorErrorDefinitions.MatchesRegex.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MatchesRegex') otherwise\.

```csharp
public PropertyStringMatchesRegexWithPatternFuncValidatorRule(System.Func<TModel,string> regexPatternFunc, System.Text.RegularExpressions.RegexOptions options=System.Text.RegularExpressions.RegexOptions.None);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.PropertyStringMatchesRegexWithPatternFuncValidatorRule(System.Func_TModel,string_,System.Text.RegularExpressions.RegexOptions).regexPatternFunc'></a>

`regexPatternFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringMatchesRegexWithPatternFuncValidatorRule\<TModel\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

<a name='Cat.Validators.Rules.PropertyStringMatchesRegexWithPatternFuncValidatorRule_TModel_.PropertyStringMatchesRegexWithPatternFuncValidatorRule(System.Func_TModel,string_,System.Text.RegularExpressions.RegexOptions).options'></a>

`options` [System\.Text\.RegularExpressions\.RegexOptions](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regexoptions 'System\.Text\.RegularExpressions\.RegexOptions')