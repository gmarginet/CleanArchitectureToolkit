<link href="../../../../resources/styles/style.css" rel="stylesheet"/>
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../../../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators Assembly](index.md 'index')

## Cat\.Validators Namespace

Provides the default validator processor, the error and error definitions,
and the base classes you derive from to write your own rules\.

| Classes | |
| :--- | :--- |
| [CatValidatorBuilder&lt;TModel&gt;](CatValidatorBuilder_TModel_.md 'Cat\.Validators\.CatValidatorBuilder\<TModel\>') | Default [ICatValidatorBuilder&lt;TModel&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1')\. Gathers the rules of one validator run\. |
| [CatValidatorError](CatValidatorError.md 'Cat\.Validators\.CatValidatorError') | Default [ICatValidatorError](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')\. |
| [CatValidatorErrorDefinitions](CatValidatorErrorDefinitions.md 'Cat\.Validators\.CatValidatorErrorDefinitions') | The codes and message templates of the built\-in rules\. A message template has named placeholders\. The values come in order, with the field name always first\. |
| [CatValidatorModelRuleAsyncBase&lt;TModel&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') | Base class for a model rule that needs async work\. Derive from it when you write your own rule\. Use [CatValidatorModelRuleBase&lt;TModel&gt;](CatValidatorModelRuleBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>') for sync work\. |
| [CatValidatorModelRuleBase&lt;TModel&gt;](CatValidatorModelRuleBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>') | Base class for a model rule that works synchronously\. Derive from it when you write your own rule and implement [Validate\(TModel\)](CatValidatorModelRuleBase_TModel_.Validate.EDFM9C738YN95FGOSBK6X26O4.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>\.Validate\(TModel\)')\. |
| [CatValidatorModelRuleBuilder&lt;TModel&gt;](CatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBuilder\<TModel\>') | Default [ICatValidatorModelRuleBuilder&lt;TModel&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1')\. |
| [CatValidatorProcessor](CatValidatorProcessor.md 'Cat\.Validators\.CatValidatorProcessor') | Default [ICatValidatorProcessor](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorProcessor.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor')\. Gets the validator for a model, builds its rules and runs each one whose conditions allow it\. Every rule runs, so one call reports all the failures\. |
| [CatValidatorPropertyRuleAsyncBase&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') | Base class for a property rule that needs async work\. Derive from it when you write your own rule\. Use [CatValidatorPropertyRuleBase&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') for sync work\. The builder fills in the property expression, the cache and the processor when you add the rule\. |
| [CatValidatorPropertyRuleBase&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') | Base class for a property rule that works synchronously\. Derive from it when you write your own rule and implement [Validate\(TProperty, string, TModel\)](CatValidatorPropertyRuleBase_TModel,TProperty_.Validate.RSZE6ZDT1113PI6TY7Y29ECGE.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)')\. |
| [CatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBuilder\<TModel,TProperty\>') | Default [ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')\. Hands each new rule the property expression, the expression cache and the processor\. |
| [CatValidatorPropertyRuleOptionsBuilder&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>') | Default [ICatValidatorPropertyRuleOptionsBuilder&lt;TModel,TProperty&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')\. |
| [CatValidatorResult](CatValidatorResult.md 'Cat\.Validators\.CatValidatorResult') | Helpers for returning the outcome of a rule\. |
