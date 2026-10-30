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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators Namespace](Cat.Validators.md 'Cat\.Validators') >> [CatValidatorModelRuleBuilder&lt;TModel&gt; Class](CatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBuilder\<TModel\>')

## CatValidatorModelRuleBuilder\<TModel\>\.AddRule\<TRule\>\(TRule\) Method

Adds a rule to the validator\.

```csharp
public void AddRule<TRule>(TRule newRule)
    where TRule : class, Cat.Validators.Abstractions.ICatValidatorModelRule<TModel>;
```
#### Type parameters

<a name='Cat.Validators.CatValidatorModelRuleBuilder_TModel_.AddRule_TRule_(TRule).TRule'></a>

`TRule`

The type of the rule\.
#### Parameters

<a name='Cat.Validators.CatValidatorModelRuleBuilder_TModel_.AddRule_TRule_(TRule).newRule'></a>

`newRule` [TRule](CatValidatorModelRuleBuilder_TModel_.AddRule.PLYT02AZTLYKVXGLD1RU5XKVD.md#Cat.Validators.CatValidatorModelRuleBuilder_TModel_.AddRule_TRule_(TRule).TRule 'Cat\.Validators\.CatValidatorModelRuleBuilder\<TModel\>\.AddRule\<TRule\>\(TRule\)\.TRule')

The rule to add\. It must derive from [CatValidatorModelRuleAsyncBase&lt;TModel&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')\.

Implements [AddRule&lt;TRule&gt;\(TRule\)](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRuleBuilder_TModel_.AddRule.NTZUA8M66NHJI05PHAP0R47G7.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1\.AddRule\`\`1\(\`\`0\)')

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
The rule doesn't derive from [CatValidatorModelRuleAsyncBase&lt;TModel&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')\.