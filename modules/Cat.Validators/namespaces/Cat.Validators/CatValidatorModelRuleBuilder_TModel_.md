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
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators Namespace](Cat.Validators.md 'Cat\.Validators')

## CatValidatorModelRuleBuilder\<TModel\> Class

Default [ICatValidatorModelRuleBuilder&lt;TModel&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1')\.

```csharp
public class CatValidatorModelRuleBuilder<TModel> : Cat.Validators.Abstractions.ICatValidatorModelRuleBuilder<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.CatValidatorModelRuleBuilder_TModel_.TModel'></a>

`TModel`

The type being validated\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatValidatorModelRuleBuilder\<TModel\>

Implements [Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1')[TModel](CatValidatorModelRuleBuilder_TModel_.md#Cat.Validators.CatValidatorModelRuleBuilder_TModel_.TModel 'Cat\.Validators\.CatValidatorModelRuleBuilder\<TModel\>\.TModel')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1')

| Constructors | |
| :--- | :--- |
| [CatValidatorModelRuleBuilder\(ConcurrentQueue&lt;ICatValidatorModelRule&lt;TModel&gt;&gt;\)](CatValidatorModelRuleBuilder_TModel_..ctor.3674QXBRHOAWIEZDXKCT0JCQ.md 'Cat\.Validators\.CatValidatorModelRuleBuilder\<TModel\>\.CatValidatorModelRuleBuilder\(System\.Collections\.Concurrent\.ConcurrentQueue\<Cat\.Validators\.Abstractions\.ICatValidatorModelRule\<TModel\>\>\)') | Default [ICatValidatorModelRuleBuilder&lt;TModel&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1')\. |

| Methods | |
| :--- | :--- |
| [AddRule&lt;TRule&gt;\(TRule\)](CatValidatorModelRuleBuilder_TModel_.AddRule.PLYT02AZTLYKVXGLD1RU5XKVD.md 'Cat\.Validators\.CatValidatorModelRuleBuilder\<TModel\>\.AddRule\<TRule\>\(TRule\)') | Adds a rule to the validator\. |
