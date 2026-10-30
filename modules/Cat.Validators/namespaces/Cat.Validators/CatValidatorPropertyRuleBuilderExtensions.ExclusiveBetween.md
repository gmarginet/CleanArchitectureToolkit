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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Extensions Namespace](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions') >> [CatValidatorPropertyRuleBuilderExtensions Class](CatValidatorPropertyRuleBuilderExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions')

## CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween Method

| Overloads | |
| :--- | :--- |
| [ExclusiveBetween&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;, Func&lt;TModel,TProperty&gt;, Func&lt;TModel,TProperty&gt;\)](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)') | The value must be between two bounds taken from the model, bounds excluded\. Code `CAT-VAL-1017`\. The lower bound must be less than the upper bound\. |
| [ExclusiveBetween&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;, Func&lt;TModel,TProperty&gt;, Func&lt;TModel,TProperty&gt;, IComparer&lt;TProperty&gt;\)](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)') | The value must be between two bounds taken from the model, bounds excluded, using your own comparer\. Code `CAT-VAL-1017`\. The lower bound must be less than the upper bound\. |
| [ExclusiveBetween&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;, TProperty, TProperty\)](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty\)') | The value must be between the bounds, bounds excluded\. Code `CAT-VAL-1017`\. The lower bound must be less than the upper bound\. |
| [ExclusiveBetween&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;, TProperty, TProperty, IComparer&lt;TProperty&gt;\)](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty, System\.Collections\.Generic\.IComparer\<TProperty\>\)') | The value must be between the bounds, bounds excluded, using your own comparer\. Code `CAT-VAL-1017`\. The lower bound must be less than the upper bound\. |

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, Func\<TModel,TProperty\>, Func\<TModel,TProperty\>\) Method

The value must be between two bounds taken from the model, bounds excluded\. Code `CAT-VAL-1017`\.
The lower bound must be less than the upper bound\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> ExclusiveBetween<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder, System.Func<TModel,TProperty> lowerBoundFunc, System.Func<TModel,TProperty> upperBoundFunc)
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).lowerBoundFunc'></a>

`lowerBoundFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the value the property must be greater than\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).upperBoundFunc'></a>

`upperBoundFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the value the property must be less than\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, Func\<TModel,TProperty\>, Func\<TModel,TProperty\>, IComparer\<TProperty\>\) Method

The value must be between two bounds taken from the model, bounds excluded, using your own comparer\.
Code `CAT-VAL-1017`\. The lower bound must be less than the upper bound\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> ExclusiveBetween<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder, System.Func<TModel,TProperty> lowerBoundFunc, System.Func<TModel,TProperty> upperBoundFunc, System.Collections.Generic.IComparer<TProperty> comparer)
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).lowerBoundFunc'></a>

`lowerBoundFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the value the property must be greater than\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).upperBoundFunc'></a>

`upperBoundFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the value the property must be less than\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[TProperty](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

Decides how values are ordered\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty\) Method

The value must be between the bounds, bounds excluded\. Code `CAT-VAL-1017`\.
The lower bound must be less than the upper bound\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> ExclusiveBetween<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder, TProperty lowerBound, TProperty upperBound)
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).lowerBound'></a>

`lowerBound` [TProperty](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty\)\.TProperty')

The value the property must be greater than\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).upperBound'></a>

`upperBound` [TProperty](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty\)\.TProperty')

The value the property must be less than\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty, IComparer\<TProperty\>\) Method

The value must be between the bounds, bounds excluded, using your own comparer\. Code `CAT-VAL-1017`\.
The lower bound must be less than the upper bound\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> ExclusiveBetween<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder, TProperty lowerBound, TProperty upperBound, System.Collections.Generic.IComparer<TProperty> comparer)
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).lowerBound'></a>

`lowerBound` [TProperty](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')

The value the property must be greater than\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).upperBound'></a>

`upperBound` [TProperty](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')

The value the property must be less than\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[TProperty](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

Decides how values are ordered\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.ExclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.ExclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.