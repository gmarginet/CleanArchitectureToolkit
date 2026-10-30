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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Extensions Namespace](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions') >> [CatValidatorPropertyRuleOptionsBuilderExtensions Class](CatValidatorPropertyRuleOptionsBuilderExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions')

## CatValidatorPropertyRuleOptionsBuilderExtensions\.WithMessage\<TModel,TProperty\>\(this ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, string\) Method

Replaces the message in the errors of the rule\.
The arguments of the rule still fill the placeholders, so you can reuse them\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> WithMessage<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> builder, string errorMessage)
    where TModel : class;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.WithMessage_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,string).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.WithMessage_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,string).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.WithMessage_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,string).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleOptionsBuilderExtensions.WithMessage.8EVOMAEFKOBSAYJYWNF7VAW01.md#Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.WithMessage_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,string).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.WithMessage\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, string\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleOptionsBuilderExtensions.WithMessage.8EVOMAEFKOBSAYJYWNF7VAW01.md#Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.WithMessage_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,string).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.WithMessage\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, string\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')

The options of the rule\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.WithMessage_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,string).errorMessage'></a>

`errorMessage` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The message template to report\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleOptionsBuilderExtensions.WithMessage.8EVOMAEFKOBSAYJYWNF7VAW01.md#Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.WithMessage_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,string).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.WithMessage\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, string\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleOptionsBuilderExtensions.WithMessage.8EVOMAEFKOBSAYJYWNF7VAW01.md#Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.WithMessage_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,string).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.WithMessage\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, string\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The same builder, so calls can be chained\.