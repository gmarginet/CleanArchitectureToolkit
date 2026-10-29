<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyExclusiveBetweenWithComparerValidatorRule&lt;TModel,TProperty&gt;](PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>')

## PropertyExclusiveBetweenWithComparerValidatorRule\(TProperty, TProperty, IComparer\<TProperty\>\) Constructor

Passes when the value is greater than the lower bound and less than the upper bound, using your own comparer\.
Fails with [ExclusiveBetween](CatValidatorErrorDefinitions.ExclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExclusiveBetween') otherwise\.

```csharp
public PropertyExclusiveBetweenWithComparerValidatorRule(TProperty lowerBound, TProperty upperBound, System.Collections.Generic.IComparer<TProperty> comparer);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.PropertyExclusiveBetweenWithComparerValidatorRule(TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).lowerBound'></a>

`lowerBound` [TProperty](PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>\.TProperty')

<a name='Cat.Validators.Rules.PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.PropertyExclusiveBetweenWithComparerValidatorRule(TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).upperBound'></a>

`upperBound` [TProperty](PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>\.TProperty')

<a name='Cat.Validators.Rules.PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.PropertyExclusiveBetweenWithComparerValidatorRule(TProperty,TProperty,System.Collections.Generic.IComparer_TProperty_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[TProperty](PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')