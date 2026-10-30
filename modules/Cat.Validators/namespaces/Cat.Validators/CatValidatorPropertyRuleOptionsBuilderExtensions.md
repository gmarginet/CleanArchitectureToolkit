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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Extensions Namespace](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions')

## CatValidatorPropertyRuleOptionsBuilderExtensions Class

Options you can chain after a property rule: conditions, a field name, a message and a code\.
Each option applies only to the rule right before it\.

```csharp
public static class CatValidatorPropertyRuleOptionsBuilderExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatValidatorPropertyRuleOptionsBuilderExtensions

| Methods | |
| :--- | :--- |
| [When&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleOptionsBuilder&lt;TModel,TProperty&gt;, Expression&lt;Func&lt;TModel,bool&gt;&gt;\)](CatValidatorPropertyRuleOptionsBuilderExtensions.When.V1EY64TK9FS9D4N9CSQO94803.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.When\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,bool\>\>\)') | Runs the rule only when the condition returns `true`\. Add several conditions and all of them must be `true`\. |
| [WhenAsync&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleOptionsBuilder&lt;TModel,TProperty&gt;, Expression&lt;Func&lt;TModel,CancellationToken,Task&lt;bool&gt;&gt;&gt;\)](CatValidatorPropertyRuleOptionsBuilderExtensions.WhenAsync.GM5EL2IPZQZPFMIWZ8SJAKF34.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.WhenAsync\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<bool\>\>\>\)') | Runs the rule only when the async condition returns `true`\. Add several conditions and all of them must be `true`\. |
| [WithCode&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleOptionsBuilder&lt;TModel,TProperty&gt;, string\)](CatValidatorPropertyRuleOptionsBuilderExtensions.WithCode.7Y5DVK7CTG2ZDYPAMFRVSBS8C.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.WithCode\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, string\)') | Replaces the code in the errors of the rule\. |
| [WithFieldName&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleOptionsBuilder&lt;TModel,TProperty&gt;, string\)](CatValidatorPropertyRuleOptionsBuilderExtensions.WithFieldName.I4JZVSI39JNZHWSH8NM9X1V76.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.WithFieldName\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, string\)') | Replaces the field name in the errors of the rule\. |
| [WithMessage&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleOptionsBuilder&lt;TModel,TProperty&gt;, string\)](CatValidatorPropertyRuleOptionsBuilderExtensions.WithMessage.8EVOMAEFKOBSAYJYWNF7VAW01.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.WithMessage\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, string\)') | Replaces the message in the errors of the rule\. The arguments of the rule still fill the placeholders, so you can reuse them\. |
