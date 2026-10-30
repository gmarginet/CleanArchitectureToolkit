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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators Namespace](Cat.Validators.md 'Cat\.Validators')

## CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\> Class

Base class for a property rule that needs async work\.
Derive from it when you write your own rule\. Use [CatValidatorPropertyRuleBase&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') for sync work\.
The builder fills in the property expression, the cache and the processor when you add the rule\.

```csharp
public abstract class CatValidatorPropertyRuleAsyncBase<TModel,TProperty> : Cat.Validators.CatValidatorModelRuleAsyncBase<TModel>, Cat.Validators.Abstractions.ICatValidatorPropertyRule<TModel, TProperty>, Cat.Validators.Abstractions.ICatValidatorModelRule<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.TModel 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') → CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>

Derived  
↳ [CatValidatorPropertyRuleBase&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')  
↳ [EnumerablePropertyValidateValidatorRule&lt;TModel,TProperty&gt;](EnumerablePropertyValidateValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.EnumerablePropertyValidateValidatorRule\<TModel,TProperty\>')  
↳ [PropertyModelMustAsyncValidatorRule&lt;TModel,TProperty&gt;](PropertyModelMustAsyncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyModelMustAsyncValidatorRule\<TModel,TProperty\>')  
↳ [PropertyMustAsyncValidatorRule&lt;TModel,TProperty&gt;](PropertyMustAsyncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyMustAsyncValidatorRule\<TModel,TProperty\>')  
↳ [PropertyValidateValidatorRule&lt;TModel,TProperty&gt;](PropertyValidateValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyValidateValidatorRule\<TModel,TProperty\>')

Implements [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRule&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRule_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRule\`2')[TModel](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.TModel 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRule_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRule\`2')[TProperty](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.TProperty 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRule_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRule\`2'), [Cat\.Validators\.Abstractions\.ICatValidatorModelRule&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRule_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\`1')[TModel](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.TModel 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.TModel')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRule_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\`1')

| Properties | |
| :--- | :--- |
| [CompiledMemberExpressionCache](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.CompiledMemberExpressionCache.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.CompiledMemberExpressionCache') | Reads the property value from the model\. |
| [ErrorCode](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ErrorCode.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.ErrorCode') | Replaces the error code\. Leave it `null` to use the code of the rule\. |
| [ErrorMessage](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ErrorMessage.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.ErrorMessage') | Replaces the error message\. Leave it `null` to use the message of the rule\. |
| [FieldName](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.FieldName.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.FieldName') | Replaces the field name in the errors\. Leave it `null` to use the property name\. |
| [PropertyExpression](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.PropertyExpression.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.PropertyExpression') | Picks the property the rule checks\. |
| [ValidatorProcessor](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ValidatorProcessor.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.ValidatorProcessor') | The processor that runs nested validators\. |
| [ValidatorRequired](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ValidatorRequired.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.ValidatorRequired') | Whether nested validators must exist\. It follows the `validatorRequired` flag of the top level call\. |

| Methods | |
| :--- | :--- |
| [ValidateAsync\(TModel, CancellationToken\)](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ValidateAsync.md#Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ValidateAsync(TModel,System.Threading.CancellationToken) 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.ValidateAsync\(TModel, System\.Threading\.CancellationToken\)') | Runs the rule\. |
| [ValidateAsync\(TProperty, string, TModel, CancellationToken\)](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ValidateAsync.md#Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ValidateAsync(TProperty,string,TModel,System.Threading.CancellationToken) 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.ValidateAsync\(TProperty, string, TModel, System\.Threading\.CancellationToken\)') | Runs the rule against the property value\. |
