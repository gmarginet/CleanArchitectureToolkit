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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Extensions Namespace](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions') >> [CatValidatorModelRuleBuilderExtensions Class](CatValidatorModelRuleBuilderExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorModelRuleBuilderExtensions')

## CatValidatorModelRuleBuilderExtensions\.Must\<TModel\>\(this ICatValidatorModelRuleBuilder\<TModel\>, Func\<TModel,List\<ICatValidatorError\>\>\) Method

Adds a rule that checks the whole model with your own code\.

```csharp
public static void Must<TModel>(this Cat.Validators.Abstractions.ICatValidatorModelRuleBuilder<TModel> builder, System.Func<TModel,System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError>> predicate)
    where TModel : class;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorModelRuleBuilderExtensions.Must_TModel_(thisCat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel_,System.Func_TModel,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).TModel'></a>

`TModel`

The type being validated\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorModelRuleBuilderExtensions.Must_TModel_(thisCat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel_,System.Func_TModel,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1')[TModel](CatValidatorModelRuleBuilderExtensions.Must.CFKVAABMBJ3TSL95W39NB971.md#Cat.Validators.Extensions.CatValidatorModelRuleBuilderExtensions.Must_TModel_(thisCat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel_,System.Func_TModel,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).TModel 'Cat\.Validators\.Extensions\.CatValidatorModelRuleBuilderExtensions\.Must\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>, System\.Func\<TModel,System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\)\.TModel')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorModelRuleBuilderExtensions.Must_TModel_(thisCat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel_,System.Func_TModel,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).predicate'></a>

`predicate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorModelRuleBuilderExtensions.Must.CFKVAABMBJ3TSL95W39NB971.md#Cat.Validators.Extensions.CatValidatorModelRuleBuilderExtensions.Must_TModel_(thisCat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel_,System.Func_TModel,System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError__).TModel 'Cat\.Validators\.Extensions\.CatValidatorModelRuleBuilderExtensions\.Must\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>, System\.Func\<TModel,System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Returns the failures it finds, or an empty list when the model is valid\.