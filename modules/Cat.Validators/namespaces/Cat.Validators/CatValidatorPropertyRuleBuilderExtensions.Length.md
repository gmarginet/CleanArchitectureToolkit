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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Extensions Namespace](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions') >> [CatValidatorPropertyRuleBuilderExtensions Class](CatValidatorPropertyRuleBuilderExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions')

## CatValidatorPropertyRuleBuilderExtensions\.Length Method

| Overloads | |
| :--- | :--- |
| [Length&lt;TModel&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,string&gt;, int, int\)](CatValidatorPropertyRuleBuilderExtensions.Length.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Length_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,int,int) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.Length\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,string\>, int, int\)') | The text length must be between the minimum and the maximum\. Code `CAT-VAL-1005`\. A `null` string passes\. The minimum must be less than the maximum\. |
| [Length&lt;TModel&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,string&gt;, Func&lt;TModel,int&gt;, Func&lt;TModel,int&gt;\)](CatValidatorPropertyRuleBuilderExtensions.Length.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Length_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,System.Func_TModel,int_,System.Func_TModel,int_) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.Length\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,string\>, System\.Func\<TModel,int\>, System\.Func\<TModel,int\>\)') | The text length must be between a minimum and a maximum taken from the model\. Code `CAT-VAL-1005`\. A `null` string passes\. The minimum must be less than the maximum\. |

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Length_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,int,int)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.Length\<TModel\>\(this ICatValidatorPropertyRuleBuilder\<TModel,string\>, int, int\) Method

The text length must be between the minimum and the maximum\. Code `CAT-VAL-1005`\.
A `null` string passes\. The minimum must be less than the maximum\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,string> Length<TModel>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,string> builder, int min, int max)
    where TModel : class;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Length_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,int,int).TModel'></a>

`TModel`

The type being validated\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Length_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,int,int).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.Length.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Length_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,int,int).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.Length\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,string\>, int, int\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Length_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,int,int).min'></a>

`min` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The shortest allowed length\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Length_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,int,int).max'></a>

`max` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The longest allowed length\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.Length.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Length_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,int,int).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.Length\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,string\>, int, int\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Length_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,System.Func_TModel,int_,System.Func_TModel,int_)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.Length\<TModel\>\(this ICatValidatorPropertyRuleBuilder\<TModel,string\>, Func\<TModel,int\>, Func\<TModel,int\>\) Method

The text length must be between a minimum and a maximum taken from the model\. Code `CAT-VAL-1005`\.
A `null` string passes\. The minimum must be less than the maximum\.

```csharp
public static Cat.Validators.Abstractions.ICatValidatorPropertyRuleOptionsBuilder<TModel,string> Length<TModel>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,string> builder, System.Func<TModel,int> minFunc, System.Func<TModel,int> maxFunc)
    where TModel : class;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Length_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,System.Func_TModel,int_,System.Func_TModel,int_).TModel'></a>

`TModel`

The type being validated\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Length_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,System.Func_TModel,int_,System.Func_TModel,int_).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.Length.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Length_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,System.Func_TModel,int_,System.Func_TModel,int_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.Length\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,string\>, System\.Func\<TModel,int\>, System\.Func\<TModel,int\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Length_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,System.Func_TModel,int_,System.Func_TModel,int_).minFunc'></a>

`minFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.Length.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Length_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,System.Func_TModel,int_,System.Func_TModel,int_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.Length\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,string\>, System\.Func\<TModel,int\>, System\.Func\<TModel,int\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the shortest allowed length from the model\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Length_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,System.Func_TModel,int_,System.Func_TModel,int_).maxFunc'></a>

`maxFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.Length.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Length_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,System.Func_TModel,int_,System.Func_TModel,int_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.Length\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,string\>, System\.Func\<TModel,int\>, System\.Func\<TModel,int\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the longest allowed length from the model\.

#### Returns
[Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.Length.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.Length_TModel_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,string_,System.Func_TModel,int_,System.Func_TModel,int_).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.Length\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,string\>, System\.Func\<TModel,int\>, System\.Func\<TModel,int\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleOptionsBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleOptionsBuilder\`2')  
The options of the rule\.