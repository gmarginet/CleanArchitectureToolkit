<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Extensions](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions')

## CatValidatorModelRuleBuilderExtensions Class

Rules that look at the whole model\. Use them inside [AddRules\(Action&lt;ICatValidatorModelRuleBuilder&lt;TModel&gt;&gt;\)](..\Cat.Validators.Abstractions\ICatValidatorBuilder_TModel_.AddRules.7LVEP6J7EA1YDLNO2MIA8L6N1.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1\.AddRules\(System\.Action\{Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\{\`0\}\}\)')\.

```csharp
public static class CatValidatorModelRuleBuilderExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatValidatorModelRuleBuilderExtensions

| Methods | |
| :--- | :--- |
| [Must&lt;TModel&gt;\(this ICatValidatorModelRuleBuilder&lt;TModel&gt;, Func&lt;TModel,List&lt;ICatValidatorError&gt;&gt;\)](CatValidatorModelRuleBuilderExtensions.Must.CFKVAABMBJ3TSL95W39NB971.md 'Cat\.Validators\.Extensions\.CatValidatorModelRuleBuilderExtensions\.Must\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>, System\.Func\<TModel,System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\)') | Adds a rule that checks the whole model with your own code\. |
| [MustAsync&lt;TModel&gt;\(this ICatValidatorModelRuleBuilder&lt;TModel&gt;, Func&lt;TModel,CancellationToken,Task&lt;List&lt;ICatValidatorError&gt;&gt;&gt;\)](CatValidatorModelRuleBuilderExtensions.MustAsync.KSZGXCJ7IYV0EP10K4VUN8J86.md 'Cat\.Validators\.Extensions\.CatValidatorModelRuleBuilderExtensions\.MustAsync\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>, System\.Func\<TModel,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\>\)') | Adds an async rule that checks the whole model with your own code\. |
