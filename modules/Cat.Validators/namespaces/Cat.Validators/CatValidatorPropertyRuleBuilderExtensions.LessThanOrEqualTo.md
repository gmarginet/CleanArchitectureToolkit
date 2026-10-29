<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Extensions](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions') > [CatValidatorPropertyRuleBuilderExtensions](CatValidatorPropertyRuleBuilderExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions')

## CatValidatorPropertyRuleBuilderExtensions\.LessThanOrEqualTo Method

| Overloads | |
| :--- | :--- |
| [LessThanOrEqualTo&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;, Expression&lt;Func&lt;TModel,TProperty&gt;&gt;\)](CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,TProperty__) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>\)') | The value must be less than or equal to another property of the model\. Code `CAT-VAL-1013`\. |
| [LessThanOrEqualTo&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;, TProperty\)](CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty\)') | The value must be less than or equal to the given value\. Code `CAT-VAL-1013`\. |

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,TProperty__)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, Expression\<Func\<TModel,TProperty\>\>\) Method

The value must be less than or equal to another property of the model\. Code `CAT-VAL-1013`\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> LessThanOrEqualTo<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder, System.Linq.Expressions.Expression<System.Func<TModel,TProperty>> expression)
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,TProperty__).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,TProperty__).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,TProperty__).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](..\Cat.Validators.Abstractions\ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,TProperty__).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>\)\.TModel')[,](..\Cat.Validators.Abstractions\ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,TProperty__).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>\)\.TProperty')[&gt;](..\Cat.Validators.Abstractions\ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,TProperty__).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,TProperty__).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,TProperty__).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

Picks the value to compare with, like `m => m.MaxAge`\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](..\Cat.Validators.Abstractions\ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,TProperty__).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>\)\.TModel')[,](..\Cat.Validators.Abstractions\ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,TProperty__).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>\)\.TProperty')[&gt;](..\Cat.Validators.Abstractions\ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty\) Method

The value must be less than or equal to the given value\. Code `CAT-VAL-1013`\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> LessThanOrEqualTo<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder, TProperty valueToCompare)
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](..\Cat.Validators.Abstractions\ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty\)\.TModel')[,](..\Cat.Validators.Abstractions\ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty\)\.TProperty')[&gt;](..\Cat.Validators.Abstractions\ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty).valueToCompare'></a>

`valueToCompare` [TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty\)\.TProperty')

The value to compare with\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](..\Cat.Validators.Abstractions\ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty\)\.TModel')[,](..\Cat.Validators.Abstractions\ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty\)\.TProperty')[&gt;](..\Cat.Validators.Abstractions\ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.