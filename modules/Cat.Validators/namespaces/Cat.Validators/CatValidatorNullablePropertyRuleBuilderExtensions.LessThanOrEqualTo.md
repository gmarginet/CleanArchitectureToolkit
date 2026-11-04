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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Extensions Namespace](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions') >> [CatValidatorNullablePropertyRuleBuilderExtensions Class](CatValidatorNullablePropertyRuleBuilderExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorNullablePropertyRuleBuilderExtensions')

## CatValidatorNullablePropertyRuleBuilderExtensions\.LessThanOrEqualTo Method

| Overloads | |
| :--- | :--- |
| [LessThanOrEqualTo&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,Nullable&lt;TProperty&gt;&gt;, Expression&lt;Func&lt;TModel,Nullable&lt;TProperty&gt;&gt;&gt;\)](CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo.md#Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,System.Linq.Expressions.Expression_System.Func_TModel,System.Nullable_TProperty___) 'Cat\.Validators\.Extensions\.CatValidatorNullablePropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,System\.Nullable\<TProperty\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,System\.Nullable\<TProperty\>\>\>\)') | The value must be less than or equal to another property of the model\. Code `CAT-VAL-1013`\. A `null` property passes\. So does a `null` value in the other property\. |
| [LessThanOrEqualTo&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,Nullable&lt;TProperty&gt;&gt;, TProperty\)](CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo.md#Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,TProperty) 'Cat\.Validators\.Extensions\.CatValidatorNullablePropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,System\.Nullable\<TProperty\>\>, TProperty\)') | The value must be less than or equal to the given value\. Code `CAT-VAL-1013`\. A `null` property passes\. |

<a name='Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,System.Linq.Expressions.Expression_System.Func_TModel,System.Nullable_TProperty___)'></a>

## CatValidatorNullablePropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,Nullable\<TProperty\>\>, Expression\<Func\<TModel,Nullable\<TProperty\>\>\>\) Method

The value must be less than or equal to another property of the model\. Code `CAT-VAL-1013`\.
A `null` property passes\. So does a `null` value in the other property\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,System.Nullable<TProperty>> LessThanOrEqualTo<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,System.Nullable<TProperty>> builder, System.Linq.Expressions.Expression<System.Func<TModel,System.Nullable<TProperty>>> expression)
    where TModel : class
    where TProperty : struct, System.IComparable<TProperty>, System.IComparable;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,System.Linq.Expressions.Expression_System.Func_TModel,System.Nullable_TProperty___).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,System.Linq.Expressions.Expression_System.Func_TModel,System.Nullable_TProperty___).TProperty'></a>

`TProperty`

The value type behind the nullable property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,System.Linq.Expressions.Expression_System.Func_TModel,System.Nullable_TProperty___).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo.md#Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,System.Linq.Expressions.Expression_System.Func_TModel,System.Nullable_TProperty___).TModel 'Cat\.Validators\.Extensions\.CatValidatorNullablePropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,System\.Nullable\<TProperty\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,System\.Nullable\<TProperty\>\>\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[TProperty](CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo.md#Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,System.Linq.Expressions.Expression_System.Func_TModel,System.Nullable_TProperty___).TProperty 'Cat\.Validators\.Extensions\.CatValidatorNullablePropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,System\.Nullable\<TProperty\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,System\.Nullable\<TProperty\>\>\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,System.Linq.Expressions.Expression_System.Func_TModel,System.Nullable_TProperty___).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo.md#Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,System.Linq.Expressions.Expression_System.Func_TModel,System.Nullable_TProperty___).TModel 'Cat\.Validators\.Extensions\.CatValidatorNullablePropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,System\.Nullable\<TProperty\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,System\.Nullable\<TProperty\>\>\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[TProperty](CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo.md#Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,System.Linq.Expressions.Expression_System.Func_TModel,System.Nullable_TProperty___).TProperty 'Cat\.Validators\.Extensions\.CatValidatorNullablePropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,System\.Nullable\<TProperty\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,System\.Nullable\<TProperty\>\>\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

Picks the value to compare with, like `m => m.MaxPrice`\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo.md#Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,System.Linq.Expressions.Expression_System.Func_TModel,System.Nullable_TProperty___).TModel 'Cat\.Validators\.Extensions\.CatValidatorNullablePropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,System\.Nullable\<TProperty\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,System\.Nullable\<TProperty\>\>\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[TProperty](CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo.md#Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,System.Linq.Expressions.Expression_System.Func_TModel,System.Nullable_TProperty___).TProperty 'Cat\.Validators\.Extensions\.CatValidatorNullablePropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,System\.Nullable\<TProperty\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,System\.Nullable\<TProperty\>\>\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.

<a name='Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,TProperty)'></a>

## CatValidatorNullablePropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,Nullable\<TProperty\>\>, TProperty\) Method

The value must be less than or equal to the given value\. Code `CAT-VAL-1013`\.
A `null` property passes\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,System.Nullable<TProperty>> LessThanOrEqualTo<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,System.Nullable<TProperty>> builder, TProperty valueToCompare)
    where TModel : class
    where TProperty : struct, System.IComparable<TProperty>, System.IComparable;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,TProperty).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,TProperty).TProperty'></a>

`TProperty`

The value type behind the nullable property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,TProperty).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo.md#Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,TProperty).TModel 'Cat\.Validators\.Extensions\.CatValidatorNullablePropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,System\.Nullable\<TProperty\>\>, TProperty\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[TProperty](CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo.md#Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,TProperty).TProperty 'Cat\.Validators\.Extensions\.CatValidatorNullablePropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,System\.Nullable\<TProperty\>\>, TProperty\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,TProperty).valueToCompare'></a>

`valueToCompare` [TProperty](CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo.md#Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,TProperty).TProperty 'Cat\.Validators\.Extensions\.CatValidatorNullablePropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,System\.Nullable\<TProperty\>\>, TProperty\)\.TProperty')

The value to compare with\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo.md#Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,TProperty).TModel 'Cat\.Validators\.Extensions\.CatValidatorNullablePropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,System\.Nullable\<TProperty\>\>, TProperty\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[TProperty](CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo.md#Cat.Validators.Extensions.CatValidatorNullablePropertyRuleBuilderExtensions.LessThanOrEqualTo_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,System.Nullable_TProperty__,TProperty).TProperty 'Cat\.Validators\.Extensions\.CatValidatorNullablePropertyRuleBuilderExtensions\.LessThanOrEqualTo\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,System\.Nullable\<TProperty\>\>, TProperty\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.