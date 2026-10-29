<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Extensions](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions') > [CatValidatorPropertyRuleBuilderExtensions](CatValidatorPropertyRuleBuilderExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions')

## CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween Method

| Overloads | |
| :--- | :--- |
| [InclusiveBetween&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;, Func&lt;TModel,TProperty&gt;, Func&lt;TModel,TProperty&gt;\)](CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)') | The value must be between two bounds taken from the model, bounds included\. Code `CAT-VAL-1016`\. The lower bound must be less than the upper bound\. |
| [InclusiveBetween&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;, Func&lt;TModel,TProperty&gt;, Func&lt;TModel,TProperty&gt;, IComparer&lt;TProperty&gt;\)](CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)') | The value must be between two bounds taken from the model, bounds included, using your own comparer\. Code `CAT-VAL-1016`\. The lower bound must be less than the upper bound\. |
| [InclusiveBetween&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;, TProperty, TProperty\)](CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty\)') | The value must be between the bounds, bounds included\. Code `CAT-VAL-1016`\. The lower bound must be less than the upper bound\. |
| [InclusiveBetween&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;, TProperty, TProperty, IComparer&lt;TProperty&gt;\)](CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty, System\.Collections\.Generic\.IComparer\<TProperty\>\)') | The value must be between the bounds, bounds included, using your own comparer\. Code `CAT-VAL-1016`\. The lower bound must be less than the upper bound\. |

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, Func\<TModel,TProperty\>, Func\<TModel,TProperty\>\) Method

The value must be between two bounds taken from the model, bounds included\. Code `CAT-VAL-1016`\.
The lower bound must be less than the upper bound\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> InclusiveBetween<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder, System.Func<TModel,TProperty> lowerBoundFunc, System.Func<TModel,TProperty> upperBoundFunc)
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)\.TModel')[,](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)\.TProperty')[&gt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).lowerBoundFunc'></a>

`lowerBoundFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the lowest allowed value from the model\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).upperBoundFunc'></a>

`upperBoundFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the highest allowed value from the model\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)\.TModel')[,](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>\)\.TProperty')[&gt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, Func\<TModel,TProperty\>, Func\<TModel,TProperty\>, IComparer\<TProperty\>\) Method

The value must be between two bounds taken from the model, bounds included, using your own comparer\.
Code `CAT-VAL-1016`\. The lower bound must be less than the upper bound\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> InclusiveBetween<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder, System.Func<TModel,TProperty> lowerBoundFunc, System.Func<TModel,TProperty> upperBoundFunc, System.Collections.Generic.IComparer<TProperty> comparer)
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TModel')[,](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')[&gt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).lowerBoundFunc'></a>

`lowerBoundFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the lowest allowed value from the model\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).upperBoundFunc'></a>

`upperBoundFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the highest allowed value from the model\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

Decides how values are ordered\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TModel')[,](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')[&gt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty\) Method

The value must be between the bounds, bounds included\. Code `CAT-VAL-1016`\.
The lower bound must be less than the upper bound\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> InclusiveBetween<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder, TProperty lowerBound, TProperty upperBound)
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty\)\.TModel')[,](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty\)\.TProperty')[&gt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).lowerBound'></a>

`lowerBound` [TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty\)\.TProperty')

The lowest allowed value\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).upperBound'></a>

`upperBound` [TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty\)\.TProperty')

The highest allowed value\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty\)\.TModel')[,](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty\)\.TProperty')[&gt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty, IComparer\<TProperty\>\) Method

The value must be between the bounds, bounds included, using your own comparer\. Code `CAT-VAL-1016`\.
The lower bound must be less than the upper bound\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> InclusiveBetween<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder, TProperty lowerBound, TProperty upperBound, System.Collections.Generic.IComparer<TProperty> comparer)
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TModel')[,](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')[&gt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).lowerBound'></a>

`lowerBound` [TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')

The lowest allowed value\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).upperBound'></a>

`upperBound` [TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')

The highest allowed value\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')

Decides how values are ordered\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TModel')[,](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.InclusiveBetween_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.InclusiveBetween\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, TProperty, TProperty, System\.Collections\.Generic\.IComparer\<TProperty\>\)\.TProperty')[&gt;](../Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.