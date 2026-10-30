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

## CatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\> Class

Default [ICatValidatorPropertyRuleOptionsBuilder&lt;TModel,TProperty&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')\.

```csharp
public class CatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> : Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.CatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.CatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>

Implements [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.TModel 'Cat\.Validators\.CatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.TProperty 'Cat\.Validators\.CatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')

| Constructors | |
| :--- | :--- |
| [CatValidatorPropertyRuleOptionsBuilder\(ICatValidatorPropertyRule&lt;TModel,TProperty&gt;\)](CatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_..ctor.QA3G0SY8KPADG1NMV3FDFH1JC.md 'Cat\.Validators\.CatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>\.CatValidatorPropertyRuleOptionsBuilder\(Cat\.Validators\.Abstractions\.ICatValidatorPropertyRule\<TModel,TProperty\>\)') | Default [ICatValidatorPropertyRuleOptionsBuilder&lt;TModel,TProperty&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')\. |

| Properties | |
| :--- | :--- |
| [Rule](CatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.Rule.md 'Cat\.Validators\.CatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>\.Rule') | The rule the options apply to\. |
