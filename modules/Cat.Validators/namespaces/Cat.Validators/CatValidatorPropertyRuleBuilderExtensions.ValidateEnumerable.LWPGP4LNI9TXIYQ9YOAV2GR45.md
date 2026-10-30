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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Extensions Namespace](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions') >> [CatValidatorPropertyRuleBuilderExtensions Class](CatValidatorPropertyRuleBuilderExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions')

## CatValidatorPropertyRuleBuilderExtensions\.ValidateEnumerable\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\) Method

Validates each item of the collection with its own validator\.
Errors get the property name and the item index as a prefix, like `Items[0].Title`\.
A `null` collection passes\. A `null` item is skipped but still counts for the index\.
An item without a registered validator is skipped only when the top level call
has `validatorRequired` set to `false`\. Otherwise it throws\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> ValidateEnumerable<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder)
    where TModel : class
    where TProperty : System.Collections.IEnumerable?;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ValidateEnumerable_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ValidateEnumerable_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_).TProperty'></a>

`TProperty`

The type of the collection\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ValidateEnumerable_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ValidateEnumerable.LWPGP4LNI9TXIYQ9YOAV2GR45.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ValidateEnumerable_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ValidateEnumerable\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.ValidateEnumerable.LWPGP4LNI9TXIYQ9YOAV2GR45.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ValidateEnumerable_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ValidateEnumerable\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ValidateEnumerable.LWPGP4LNI9TXIYQ9YOAV2GR45.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ValidateEnumerable_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ValidateEnumerable\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.ValidateEnumerable.LWPGP4LNI9TXIYQ9YOAV2GR45.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ValidateEnumerable_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ValidateEnumerable\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.