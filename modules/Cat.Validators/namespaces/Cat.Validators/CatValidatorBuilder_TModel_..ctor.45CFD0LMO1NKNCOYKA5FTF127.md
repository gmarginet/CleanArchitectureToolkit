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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators Namespace](Cat.Validators.md 'Cat\.Validators') >> [CatValidatorBuilder&lt;TModel&gt; Class](CatValidatorBuilder_TModel_.md 'Cat\.Validators\.CatValidatorBuilder\<TModel\>')

## CatValidatorBuilder\(ICatCompiledMemberExpressionCache\<TModel\>, CatValidatorProcessor, bool\) Constructor

Default [ICatValidatorBuilder&lt;TModel&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1')\.
Gathers the rules of one validator run\.

```csharp
public CatValidatorBuilder(Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache<TModel> compiledMemberExpressionCache, Cat.Validators.CatValidatorProcessor validatorProcessor, bool validatorRequired=true);
```
#### Parameters

<a name='Cat.Validators.CatValidatorBuilder_TModel_.CatValidatorBuilder(Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache_TModel_,Cat.Validators.CatValidatorProcessor,bool).compiledMemberExpressionCache'></a>

`compiledMemberExpressionCache` [Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache&lt;](../../../Cat.Expressions/namespaces/Cat.Expressions.Abstractions/ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1')[TModel](CatValidatorBuilder_TModel_.md#Cat.Validators.CatValidatorBuilder_TModel_.TModel 'Cat\.Validators\.CatValidatorBuilder\<TModel\>\.TModel')[&gt;](../../../Cat.Expressions/namespaces/Cat.Expressions.Abstractions/ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1')

<a name='Cat.Validators.CatValidatorBuilder_TModel_.CatValidatorBuilder(Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache_TModel_,Cat.Validators.CatValidatorProcessor,bool).validatorProcessor'></a>

`validatorProcessor` [CatValidatorProcessor](CatValidatorProcessor.md 'Cat\.Validators\.CatValidatorProcessor')

<a name='Cat.Validators.CatValidatorBuilder_TModel_.CatValidatorBuilder(Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache_TModel_,Cat.Validators.CatValidatorProcessor,bool).validatorRequired'></a>

`validatorRequired` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')