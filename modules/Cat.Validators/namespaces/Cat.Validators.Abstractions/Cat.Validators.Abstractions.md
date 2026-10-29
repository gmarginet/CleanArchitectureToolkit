<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators\.Abstractions](index.md 'index')

## Cat\.Validators\.Abstractions Namespace

Defines the contracts for validation: validators, the builders you describe rules with,
the rules themselves, and the processor that runs them and returns an [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')\.

| Interfaces | |
| :--- | :--- |
| [ICatValidator&lt;TModel&gt;](ICatValidator_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidator\<TModel\>') | Describes the rules for one model type\. Implement it once per model\. The module finds and registers it for you\. |
| [ICatValidatorBuilder&lt;TModel&gt;](ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>') | Collects the rules of a validator\. You get one in [Build\(ICatValidatorBuilder&lt;TModel&gt;\)](ICatValidator_TModel_.Build.KH5JMOMCH87CLWU32S59B0UE1.md 'Cat\.Validators\.Abstractions\.ICatValidator\<TModel\>\.Build\(Cat\.Validators\.Abstractions\.ICatValidatorBuilder\<TModel\>\)')\. |
| [ICatValidatorError](ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError') | One validation failure\. |
| [ICatValidatorModelRule&lt;TModel&gt;](ICatValidatorModelRule_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\<TModel\>') | A rule that checks a model and returns the failures it finds\. |
| [ICatValidatorModelRuleBuilder&lt;TModel&gt;](ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>') | Adds rules that look at the whole model\. |
| [ICatValidatorProcessor](ICatValidatorProcessor.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor') | Single entry point for validating a model\. It finds the validator for the model, runs its rules and returns the outcome as a response\. |
| [ICatValidatorPropertyRule&lt;TModel,TProperty&gt;](ICatValidatorPropertyRule_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRule\<TModel,TProperty\>') | A rule that checks one property of a model\. |
| [ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;](ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>') | Adds rules for one property\. The built\-in rules are extension methods on this interface\. |
| [ICatValidatorPropertyRuleOptionsBuilder&lt;TModel,TProperty&gt;](ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>') | Sets options on the rule you just added, like a condition, a field name or a message\. |
