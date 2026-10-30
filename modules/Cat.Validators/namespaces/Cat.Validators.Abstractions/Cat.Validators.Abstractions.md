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
  
##### >> [Cat\.Validators\.Abstractions Assembly](index.md 'index')

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
