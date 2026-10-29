<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators')

## CatValidatorProcessor Class

Default [ICatValidatorProcessor](..\Cat.Validators.Abstractions\ICatValidatorProcessor.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor')\.
Gets the validator for a model, builds its rules and runs each one whose conditions allow it\.
Every rule runs, so one call reports all the failures\.

```csharp
public class CatValidatorProcessor : Cat.Validators.Abstractions.ICatValidatorProcessor
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatValidatorProcessor

Implements [ICatValidatorProcessor](..\Cat.Validators.Abstractions\ICatValidatorProcessor.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor')

| Constructors | |
| :--- | :--- |
| [CatValidatorProcessor\(IServiceProvider\)](CatValidatorProcessor..ctor.43C8DSYDHUK4I0O708NO4UYBD.md 'Cat\.Validators\.CatValidatorProcessor\.CatValidatorProcessor\(System\.IServiceProvider\)') | Default [ICatValidatorProcessor](..\Cat.Validators.Abstractions\ICatValidatorProcessor.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor')\. Gets the validator for a model, builds its rules and runs each one whose conditions allow it\. Every rule runs, so one call reports all the failures\. |

| Methods | |
| :--- | :--- |
| [InternalValidateAsync&lt;T&gt;\(T, bool, CancellationToken\)](CatValidatorProcessor.InternalValidateAsync.MW5UEA8ND8VDCLPLEI3DJBJ38.md 'Cat\.Validators\.CatValidatorProcessor\.InternalValidateAsync\<T\>\(T, bool, System\.Threading\.CancellationToken\)') | Runs the rules and returns the raw failures\. Nested validation uses this to get at the field names\. The [validatorRequired](CatValidatorProcessor.InternalValidateAsync.MW5UEA8ND8VDCLPLEI3DJBJ38.md#Cat.Validators.CatValidatorProcessor.InternalValidateAsync_T_(T,bool,System.Threading.CancellationToken).validatorRequired 'Cat\.Validators\.CatValidatorProcessor\.InternalValidateAsync\<T\>\(T, bool, System\.Threading\.CancellationToken\)\.validatorRequired') flag also goes to the nested rules, so they follow the top level\. |
| [Validate&lt;T&gt;\(T, bool\)](CatValidatorProcessor.Validate.2H7PED1DKKQ4EEVWCZ5CLKUK8.md 'Cat\.Validators\.CatValidatorProcessor\.Validate\<T\>\(T, bool\)') | Validates a model and blocks until it finishes\. Prefer [ValidateAsync&lt;TModel&gt;\(TModel, bool, CancellationToken\)](..\Cat.Validators.Abstractions\ICatValidatorProcessor.ValidateAsync.YX1OQX8RMH8LA0B43AUVR45T5.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor\.ValidateAsync\`\`1\(\`\`0,System\.Boolean,System\.Threading\.CancellationToken\)') when you can\. |
| [ValidateAsync&lt;T&gt;\(T, bool, CancellationToken\)](CatValidatorProcessor.ValidateAsync.9TMCP2XJPJ3T7VARXR8W30BP3.md 'Cat\.Validators\.CatValidatorProcessor\.ValidateAsync\<T\>\(T, bool, System\.Threading\.CancellationToken\)') | Validates a model\. |
