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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Extensions Namespace](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions')

## CatValidatorModelRuleBuilderExtensions Class

Rules that look at the whole model\. Use them inside [AddRules\(Action&lt;ICatValidatorModelRuleBuilder&lt;TModel&gt;&gt;\)](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorBuilder_TModel_.AddRules.7LVEP6J7EA1YDLNO2MIA8L6N1.md 'Cat\.Validators\.Abstractions\.ICatValidatorBuilder\`1\.AddRules\(System\.Action\{Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\{\`0\}\}\)')\.

```csharp
public static class CatValidatorModelRuleBuilderExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatValidatorModelRuleBuilderExtensions

| Methods | |
| :--- | :--- |
| [Must&lt;TModel&gt;\(this ICatValidatorModelRuleBuilder&lt;TModel&gt;, Func&lt;TModel,List&lt;ICatValidatorError&gt;&gt;\)](CatValidatorModelRuleBuilderExtensions.Must.CFKVAABMBJ3TSL95W39NB971.md 'Cat\.Validators\.Extensions\.CatValidatorModelRuleBuilderExtensions\.Must\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>, System\.Func\<TModel,System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\)') | Adds a rule that checks the whole model with your own code\. |
| [MustAsync&lt;TModel&gt;\(this ICatValidatorModelRuleBuilder&lt;TModel&gt;, Func&lt;TModel,CancellationToken,Task&lt;List&lt;ICatValidatorError&gt;&gt;&gt;\)](CatValidatorModelRuleBuilderExtensions.MustAsync.KSZGXCJ7IYV0EP10K4VUN8J86.md 'Cat\.Validators\.Extensions\.CatValidatorModelRuleBuilderExtensions\.MustAsync\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>, System\.Func\<TModel,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\>\)') | Adds an async rule that checks the whole model with your own code\. |
