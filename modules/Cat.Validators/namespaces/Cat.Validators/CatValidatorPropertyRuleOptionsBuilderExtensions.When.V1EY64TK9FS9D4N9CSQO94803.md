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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Extensions Namespace](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions') >> [CatValidatorPropertyRuleOptionsBuilderExtensions Class](CatValidatorPropertyRuleOptionsBuilderExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions')

## CatValidatorPropertyRuleOptionsBuilderExtensions\.When\<TModel,TProperty\>\(this ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, Expression\<Func\<TModel,bool\>\>\) Method

Runs the rule only when the condition returns `true`\.
Add several conditions and all of them must be `true`\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> When<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,TProperty> builder, System.Linq.Expressions.Expression<System.Func<TModel,bool>> condition)
    where TModel : class;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.When_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,bool__).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.When_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,bool__).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.When_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,bool__).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleOptionsBuilderExtensions.When.V1EY64TK9FS9D4N9CSQO94803.md#Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.When_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,bool__).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.When\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,bool\>\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleOptionsBuilderExtensions.When.V1EY64TK9FS9D4N9CSQO94803.md#Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.When_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,bool__).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.When\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,bool\>\>\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')

The options of the rule\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.When_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,bool__).condition'></a>

`condition` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorPropertyRuleOptionsBuilderExtensions.When.V1EY64TK9FS9D4N9CSQO94803.md#Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.When_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,bool__).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.When\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,bool\>\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

Decides whether the rule runs\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleOptionsBuilderExtensions.When.V1EY64TK9FS9D4N9CSQO94803.md#Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.When_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,bool__).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.When\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,bool\>\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TProperty](CatValidatorPropertyRuleOptionsBuilderExtensions.When.V1EY64TK9FS9D4N9CSQO94803.md#Cat.Validators.Extensions.CatValidatorPropertyRuleOptionsBuilderExtensions.When_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_,System.Linq.Expressions.Expression_System.Func_TModel,bool__).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleOptionsBuilderExtensions\.When\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\<TModel,TProperty\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,bool\>\>\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The same builder, so calls can be chained\.