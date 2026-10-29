<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyEqualValidatorRule&lt;TModel,TProperty&gt;](PropertyEqualValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyEqualValidatorRule\<TModel,TProperty\>')

## PropertyEqualValidatorRule\(TProperty, IEqualityComparer\<TProperty\>\) Constructor

Passes when the value equals the given value\.
Fails with [Equal](CatValidatorErrorDefinitions.Equal.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.Equal') otherwise\.

```csharp
public PropertyEqualValidatorRule(TProperty valueToCompare, System.Collections.Generic.IEqualityComparer<TProperty?>? comparer=null);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyEqualValidatorRule_TModel,TProperty_.PropertyEqualValidatorRule(TProperty,System.Collections.Generic.IEqualityComparer_TProperty_).valueToCompare'></a>

`valueToCompare` [TProperty](PropertyEqualValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEqualValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyEqualValidatorRule\<TModel,TProperty\>\.TProperty')

<a name='Cat.Validators.Rules.PropertyEqualValidatorRule_TModel,TProperty_.PropertyEqualValidatorRule(TProperty,System.Collections.Generic.IEqualityComparer_TProperty_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IEqualityComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1 'System\.Collections\.Generic\.IEqualityComparer\`1')[TProperty](PropertyEqualValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEqualValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyEqualValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1 'System\.Collections\.Generic\.IEqualityComparer\`1')