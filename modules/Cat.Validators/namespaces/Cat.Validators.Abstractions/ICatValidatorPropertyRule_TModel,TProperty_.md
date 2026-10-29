<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index') > [Cat\.Validators\.Abstractions](Cat.Validators.Abstractions.md 'Cat\.Validators\.Abstractions')

## ICatValidatorPropertyRule\<TModel,TProperty\> Interface

A rule that checks one property of a model\.

```csharp
public interface ICatValidatorPropertyRule<TModel,TProperty> : Cat.Validators.Abstractions.ICatValidatorModelRule<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Abstractions.ICatValidatorPropertyRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Abstractions.ICatValidatorPropertyRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Implements [Cat\.Validators\.Abstractions\.ICatValidatorModelRule&lt;](ICatValidatorModelRule_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\<TModel\>')[TModel](ICatValidatorPropertyRule_TModel,TProperty_.md#Cat.Validators.Abstractions.ICatValidatorPropertyRule_TModel,TProperty_.TModel 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRule\<TModel,TProperty\>\.TModel')[&gt;](ICatValidatorModelRule_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\<TModel\>')

| Properties | |
| :--- | :--- |
| [ErrorCode](ICatValidatorPropertyRule_TModel,TProperty_.ErrorCode.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRule\<TModel,TProperty\>\.ErrorCode') | Replaces the error code\. Leave it `null` to use the code of the rule\. |
| [ErrorMessage](ICatValidatorPropertyRule_TModel,TProperty_.ErrorMessage.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRule\<TModel,TProperty\>\.ErrorMessage') | Replaces the error message\. Leave it `null` to use the message of the rule\. |
| [FieldName](ICatValidatorPropertyRule_TModel,TProperty_.FieldName.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRule\<TModel,TProperty\>\.FieldName') | Replaces the field name in the errors\. Leave it `null` to use the property name\. |
