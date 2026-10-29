<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Extensions](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions') > [CatValidatorPropertyRuleBuilderExtensions](CatValidatorPropertyRuleBuilderExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions')

## CatValidatorPropertyRuleBuilderExtensions\.ExactLength Method

| Overloads | |
| :--- | :--- |
| [ExactLength&lt;TModel&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,string&gt;, int\)](CatValidatorPropertyRuleBuilderExtensions.ExactLength.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExactLength_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,int) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExactLength\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,string\>, int\)') | The text must have exactly the given length\. Code `CAT-VAL-1006`\. A `null` string passes\. |
| [ExactLength&lt;TModel&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,string&gt;, Func&lt;TModel,int&gt;\)](CatValidatorPropertyRuleBuilderExtensions.ExactLength.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExactLength_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,System.Func_TModel,int_) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExactLength\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,string\>, System\.Func\<TModel,int\>\)') | The text must have exactly the length taken from the model\. Code `CAT-VAL-1006`\. A `null` string passes\. |

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExactLength_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,int)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.ExactLength\<TModel\>\(this ICatValidatorPropertyRuleBuilder\<TModel,string\>, int\) Method

The text must have exactly the given length\. Code `CAT-VAL-1006`\.
A `null` string passes\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,string> ExactLength<TModel>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,string> builder, int exactLength)
    where TModel : class;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExactLength_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,int).TModel'></a>

`TModel`

The type being validated\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExactLength_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,int).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ExactLength.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExactLength_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,int).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExactLength\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,string\>, int\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExactLength_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,int).exactLength'></a>

`exactLength` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The required length\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ExactLength.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExactLength_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,int).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExactLength\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,string\>, int\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExactLength_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,System.Func_TModel,int_)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.ExactLength\<TModel\>\(this ICatValidatorPropertyRuleBuilder\<TModel,string\>, Func\<TModel,int\>\) Method

The text must have exactly the length taken from the model\. Code `CAT-VAL-1006`\.
A `null` string passes\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,string> ExactLength<TModel>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,string> builder, System.Func<TModel,int> exactLengthFunc)
    where TModel : class;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExactLength_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,System.Func_TModel,int_).TModel'></a>

`TModel`

The type being validated\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExactLength_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,System.Func_TModel,int_).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ExactLength.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExactLength_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,System.Func_TModel,int_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExactLength\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,string\>, System\.Func\<TModel,int\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExactLength_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,System.Func_TModel,int_).exactLengthFunc'></a>

`exactLengthFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ExactLength.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExactLength_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,System.Func_TModel,int_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExactLength\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,string\>, System\.Func\<TModel,int\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the required length from the model\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ExactLength.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExactLength_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,System.Func_TModel,int_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExactLength\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,string\>, System\.Func\<TModel,int\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.