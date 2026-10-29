<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators') > [CatValidatorProcessor](CatValidatorProcessor.md 'Cat\.Validators\.CatValidatorProcessor')

## CatValidatorProcessor\(IServiceProvider\) Constructor

Default [ICatValidatorProcessor](../Cat.Validators.Abstractions/ICatValidatorProcessor.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor')\.
Gets the validator for a model, builds its rules and runs each one whose conditions allow it\.
Every rule runs, so one call reports all the failures\.

```csharp
public CatValidatorProcessor(System.IServiceProvider serviceProvider);
```
#### Parameters

<a name='Cat.Validators.CatValidatorProcessor.CatValidatorProcessor(System.IServiceProvider).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

Resolves validators and the expression cache\.