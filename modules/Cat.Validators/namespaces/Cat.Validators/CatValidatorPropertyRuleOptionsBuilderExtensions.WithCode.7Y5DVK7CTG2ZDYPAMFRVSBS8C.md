<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Extensions](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions') > [CatValidatorPropertyRuleOptionsBuilderExtensions](CatValidatorPropertyRuleOptionsBuilderExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions')

## CatValidatorPropertyRuleOptionsBuilderExtensions\.WithCode\<TModel,TProperty\>\(this ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, string\) Method

Replaces the code in the errors of the rule\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> WithCode<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> builder, string code)
    where TModel : class;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.WithCode_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,string).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.WithCode_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,string).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.WithCode_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,string).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleOptionsBuilderExtensions.WithCode.7Y5DVK7CTG2ZDYPAMFRVSBS8C.md#Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.WithCode_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,string).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.WithCode\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, string\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleOptionsBuilderExtensions.WithCode.7Y5DVK7CTG2ZDYPAMFRVSBS8C.md#Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.WithCode_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,string).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.WithCode\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, string\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')

The options of the rule\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.WithCode_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,string).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error code to report\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleOptionsBuilderExtensions.WithCode.7Y5DVK7CTG2ZDYPAMFRVSBS8C.md#Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.WithCode_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,string).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.WithCode\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, string\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleOptionsBuilderExtensions.WithCode.7Y5DVK7CTG2ZDYPAMFRVSBS8C.md#Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.WithCode_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,string).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.WithCode\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, string\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The same builder, so calls can be chained\.