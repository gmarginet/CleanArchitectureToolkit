<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyInclusiveBetweenWithComparerValidatorRule&lt;TModel,TProperty&gt;](PropertyInclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>')

## PropertyInclusiveBetweenWithComparerValidatorRule\(TProperty, TProperty, IComparer\<TProperty\>\) Constructor

Passes when the value is between the bounds, bounds included, using your own comparer\.
Fails with [InclusiveBetween](CatValidatorErrorDefinitions.InclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.InclusiveBetween') otherwise\.

```csharp
public PropertyInclusiveBetweenWithComparerValidatorRule(TProperty lowerBound, TProperty upperBound, System.Collections.Generic.IComparer<TProperty> comparer);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyInclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.PropertyInclusiveBetweenWithComparerValidatorRule(TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).lowerBound'></a>

`lowerBound` [TProperty](PropertyInclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>\.TProperty')

<a name='Cat.Validators.Rules.PropertyInclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.PropertyInclusiveBetweenWithComparerValidatorRule(TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).upperBound'></a>

`upperBound` [TProperty](PropertyInclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>\.TProperty')

<a name='Cat.Validators.Rules.PropertyInclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.PropertyInclusiveBetweenWithComparerValidatorRule(TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[TProperty](PropertyInclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')