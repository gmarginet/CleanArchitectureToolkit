<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators') > [CatValidatorProcessor](CatValidatorProcessor.md 'Cat\.Validators\.CatValidatorProcessor')

## CatValidatorProcessor\.InternalValidateAsync\<T\>\(T, bool, CancellationToken\) Method

Runs the rules and returns the raw failures\. Nested validation uses this to get at the field names\.
The [validatorRequired](CatValidatorProcessor.InternalValidateAsync.MW5UEA8ND8VDCLPLEI3DJBJ38.md#Cat.Validators.CatValidatorProcessor.InternalValidateAsync_T_(T,bool,System.Threading.CancellationToken).validatorRequired 'Cat\.Validators\.CatValidatorProcessor\.InternalValidateAsync\<T\>\(T, bool, System\.Threading\.CancellationToken\)\.validatorRequired') flag also goes to the nested rules, so they follow the top level\.

```csharp
internal System.Threading.Tasks.Task<System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError>> InternalValidateAsync<T>(T model, bool validatorRequired=true, System.Threading.CancellationToken ct=default(System.Threading.CancellationToken))
    where T : class;
```
#### Type parameters

<a name='Cat.Validators.CatValidatorProcessor.InternalValidateAsync_T_(T,bool,System.Threading.CancellationToken).T'></a>

`T`
#### Parameters

<a name='Cat.Validators.CatValidatorProcessor.InternalValidateAsync_T_(T,bool,System.Threading.CancellationToken).model'></a>

`model` [T](CatValidatorProcessor.InternalValidateAsync.MW5UEA8ND8VDCLPLEI3DJBJ38.md#Cat.Validators.CatValidatorProcessor.InternalValidateAsync_T_(T,bool,System.Threading.CancellationToken).T 'Cat\.Validators\.CatValidatorProcessor\.InternalValidateAsync\<T\>\(T, bool, System\.Threading\.CancellationToken\)\.T')

<a name='Cat.Validators.CatValidatorProcessor.InternalValidateAsync_T_(T,bool,System.Threading.CancellationToken).validatorRequired'></a>

`validatorRequired` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='Cat.Validators.CatValidatorProcessor.InternalValidateAsync_T_(T,bool,System.Threading.CancellationToken).ct'></a>

`ct` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](../Cat.Validators.Abstractions/ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')