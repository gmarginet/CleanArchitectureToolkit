<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index')

## Cat\.Validators Namespace

Provides the default validator processor, the error and error definitions,
and the base classes you derive from to write your own rules\.

| Classes | |
| :--- | :--- |
| [CatValidatorBuilder&lt;TModel&gt;](CatValidatorBuilder_TModel_.md 'Cat\.Validators\.CatValidatorBuilder\<TModel\>') | Default [ICatValidatorBuilder&lt;TModel&gt;](..\Cat.Validators.Abstractions\ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1')\. Gathers the rules of one validator run\. |
| [CatValidatorError](CatValidatorError.md 'Cat\.Validators\.CatValidatorError') | Default [ICatValidatorError](..\Cat.Validators.Abstractions\ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')\. |
| [CatValidatorErrorDefinitions](CatValidatorErrorDefinitions.md 'Cat\.Validators\.CatValidatorErrorDefinitions') | The codes and message templates of the built\-in rules\. A message template has named placeholders\. The values come in order, with the field name always first\. |
| [CatValidatorModelRuleAsyncBase&lt;TModel&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') | Base class for a model rule that needs async work\. Derive from it when you write your own rule\. Use [CatValidatorModelRuleBase&lt;TModel&gt;](CatValidatorModelRuleBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>') for sync work\. |
| [CatValidatorModelRuleBase&lt;TModel&gt;](CatValidatorModelRuleBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>') | Base class for a model rule that works synchronously\. Derive from it when you write your own rule and implement [Validate\(TModel\)](CatValidatorModelRuleBase_TModel_.Validate.EDFM9C738YN95FGOSBK6X26O4.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>\.Validate\(TModel\)')\. |
| [CatValidatorModelRuleBuilder&lt;TModel&gt;](CatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBuilder\<TModel\>') | Default [ICatValidatorModelRuleBuilder&lt;TModel&gt;](..\Cat.Validators.Abstractions\ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1')\. |
| [CatValidatorProcessor](CatValidatorProcessor.md 'Cat\.Validators\.CatValidatorProcessor') | Default [ICatValidatorProcessor](..\Cat.Validators.Abstractions\ICatValidatorProcessor.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor')\. Gets the validator for a model, builds its rules and runs each one whose conditions allow it\. Every rule runs, so one call reports all the failures\. |
| [CatValidatorPropertyRuleAsyncBase&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') | Base class for a property rule that needs async work\. Derive from it when you write your own rule\. Use [CatValidatorPropertyRuleBase&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') for sync work\. The builder fills in the property expression, the cache and the processor when you add the rule\. |
| [CatValidatorPropertyRuleBase&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') | Base class for a property rule that works synchronously\. Derive from it when you write your own rule and implement [Validate\(TProperty, string, TModel\)](CatValidatorPropertyRuleBase_TModel,TProperty_.Validate.RSZE6ZDT1113PI6TY7Y29ECGE.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)')\. |
| [CatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>') | Default [ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;](..\Cat.Validators.Abstractions\ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')\. Hands each new rule the property expression, the expression cache and the processor\. |
| [CatValidatorPropertyRuleOptionsBuilder&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>') | Default [ICatValidatorPropertyRuleOptionsBuilder&lt;TModel,TProperty&gt;](..\Cat.Validators.Abstractions\ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')\. |
| [CatValidatorResult](CatValidatorResult.md 'Cat\.Validators\.CatValidatorResult') | Helpers for returning the outcome of a rule\. |
