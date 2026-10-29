<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions')

## ICatValidator\<TModel\> Interface

Describes the rules for one model type\.
Implement it once per model\. The module finds and registers it for you\.

```csharp
public interface ICatValidator<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Abstractions.ICatValidator_TModel_.TModel'></a>

`TModel`

The type being validated\.

| Methods | |
| :--- | :--- |
| [Build\(ICatValidatorBuilder&lt;TModel&gt;\)](ICatValidator_TModel_.Build.KH5JMOMCH87CLWU32S59B0UE1.md 'Cat\.Validators\.Abstractions\.ICatValidator\<TModel\>\.Build\(Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>\)') | Adds the rules for the model\. |
