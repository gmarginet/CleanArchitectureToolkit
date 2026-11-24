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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Extensions Namespace](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions') >> [CatValidatorPropertyRuleBuilderExtensions Class](CatValidatorPropertyRuleBuilderExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions')

## CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex Method

| Overloads | |
| :--- | :--- |
| [MatchesRegex&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;, string, RegexOptions\)](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,string,System.Text.RegularExpressions.RegexOptions) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, string, System\.Text\.RegularExpressions\.RegexOptions\)') | The text must match the regular expression pattern\. Code `CAT-VAL-1009`\. A `null` string passes\. |
| [MatchesRegex&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;, Func&lt;TModel,string&gt;, RegexOptions\)](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,string_,System.Text.RegularExpressions.RegexOptions) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,string\>, System\.Text\.RegularExpressions\.RegexOptions\)') | The text must match a regular expression pattern taken from the model\. Code `CAT-VAL-1009`\. A `null` string passes\. |
| [MatchesRegex&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;, Func&lt;TModel,Regex&gt;\)](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,System.Text.RegularExpressions.Regex_) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,System\.Text\.RegularExpressions\.Regex\>\)') | The text must match a regular expression taken from the model\. Code `CAT-VAL-1009`\. A `null` string passes\. |
| [MatchesRegex&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;, Regex\)](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Text.RegularExpressions.Regex) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Text\.RegularExpressions\.Regex\)') | The text must match the regular expression\. Code `CAT-VAL-1009`\. A `null` string passes\. |

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,string,System.Text.RegularExpressions.RegexOptions)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, string, RegexOptions\) Method

The text must match the regular expression pattern\. Code `CAT-VAL-1009`\.
A `null` string passes\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> MatchesRegex<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder, string regexPattern, System.Text.RegularExpressions.RegexOptions options=System.Text.RegularExpressions.RegexOptions.None)
    where TModel : class
    where TProperty : System.Collections.Generic.IEnumerable<char>?;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,string,System.Text.RegularExpressions.RegexOptions).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,string,System.Text.RegularExpressions.RegexOptions).TProperty'></a>

`TProperty`

The type of the property, `string` or `string?`\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,string,System.Text.RegularExpressions.RegexOptions).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,string,System.Text.RegularExpressions.RegexOptions).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, string, System\.Text\.RegularExpressions\.RegexOptions\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,string,System.Text.RegularExpressions.RegexOptions).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, string, System\.Text\.RegularExpressions\.RegexOptions\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,string,System.Text.RegularExpressions.RegexOptions).regexPattern'></a>

`regexPattern` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The regular expression pattern\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,string,System.Text.RegularExpressions.RegexOptions).options'></a>

`options` [System\.Text\.RegularExpressions\.RegexOptions](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regexoptions 'System\.Text\.RegularExpressions\.RegexOptions')

The options for the regular expression\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,string,System.Text.RegularExpressions.RegexOptions).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, string, System\.Text\.RegularExpressions\.RegexOptions\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,string,System.Text.RegularExpressions.RegexOptions).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, string, System\.Text\.RegularExpressions\.RegexOptions\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,string_,System.Text.RegularExpressions.RegexOptions)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, Func\<TModel,string\>, RegexOptions\) Method

The text must match a regular expression pattern taken from the model\. Code `CAT-VAL-1009`\.
A `null` string passes\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> MatchesRegex<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder, System.Func<TModel,string> regexPatternFunc, System.Text.RegularExpressions.RegexOptions options=System.Text.RegularExpressions.RegexOptions.None)
    where TModel : class
    where TProperty : System.Collections.Generic.IEnumerable<char>?;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,string_,System.Text.RegularExpressions.RegexOptions).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,string_,System.Text.RegularExpressions.RegexOptions).TProperty'></a>

`TProperty`

The type of the property, `string` or `string?`\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,string_,System.Text.RegularExpressions.RegexOptions).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,string_,System.Text.RegularExpressions.RegexOptions).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,string\>, System\.Text\.RegularExpressions\.RegexOptions\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,string_,System.Text.RegularExpressions.RegexOptions).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,string\>, System\.Text\.RegularExpressions\.RegexOptions\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,string_,System.Text.RegularExpressions.RegexOptions).regexPatternFunc'></a>

`regexPatternFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,string_,System.Text.RegularExpressions.RegexOptions).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,string\>, System\.Text\.RegularExpressions\.RegexOptions\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the regular expression pattern from the model\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,string_,System.Text.RegularExpressions.RegexOptions).options'></a>

`options` [System\.Text\.RegularExpressions\.RegexOptions](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regexoptions 'System\.Text\.RegularExpressions\.RegexOptions')

The options for the regular expression\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,string_,System.Text.RegularExpressions.RegexOptions).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,string\>, System\.Text\.RegularExpressions\.RegexOptions\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,string_,System.Text.RegularExpressions.RegexOptions).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,string\>, System\.Text\.RegularExpressions\.RegexOptions\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,System.Text.RegularExpressions.Regex_)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, Func\<TModel,Regex\>\) Method

The text must match a regular expression taken from the model\. Code `CAT-VAL-1009`\.
A `null` string passes\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> MatchesRegex<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder, System.Func<TModel,System.Text.RegularExpressions.Regex> regexFunc)
    where TModel : class
    where TProperty : System.Collections.Generic.IEnumerable<char>?;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,System.Text.RegularExpressions.Regex_).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,System.Text.RegularExpressions.Regex_).TProperty'></a>

`TProperty`

The type of the property, `string` or `string?`\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,System.Text.RegularExpressions.Regex_).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,System.Text.RegularExpressions.Regex_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,System\.Text\.RegularExpressions\.Regex\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,System.Text.RegularExpressions.Regex_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,System\.Text\.RegularExpressions\.Regex\>\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,System.Text.RegularExpressions.Regex_).regexFunc'></a>

`regexFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,System.Text.RegularExpressions.Regex_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,System\.Text\.RegularExpressions\.Regex\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Text\.RegularExpressions\.Regex](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex 'System\.Text\.RegularExpressions\.Regex')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the regular expression from the model\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,System.Text.RegularExpressions.Regex_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,System\.Text\.RegularExpressions\.Regex\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,System.Text.RegularExpressions.Regex_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,System\.Text\.RegularExpressions\.Regex\>\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Text.RegularExpressions.Regex)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, Regex\) Method

The text must match the regular expression\. Code `CAT-VAL-1009`\.
A `null` string passes\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> MatchesRegex<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder, System.Text.RegularExpressions.Regex regex)
    where TModel : class
    where TProperty : System.Collections.Generic.IEnumerable<char>?;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Text.RegularExpressions.Regex).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Text.RegularExpressions.Regex).TProperty'></a>

`TProperty`

The type of the property, `string` or `string?`\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Text.RegularExpressions.Regex).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Text.RegularExpressions.Regex).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Text\.RegularExpressions\.Regex\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Text.RegularExpressions.Regex).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Text\.RegularExpressions\.Regex\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Text.RegularExpressions.Regex).regex'></a>

`regex` [System\.Text\.RegularExpressions\.Regex](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex 'System\.Text\.RegularExpressions\.Regex')

The regular expression\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Text.RegularExpressions.Regex).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Text\.RegularExpressions\.Regex\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.MatchesRegex.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MatchesRegex_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Text.RegularExpressions.Regex).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MatchesRegex\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Text\.RegularExpressions\.Regex\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.