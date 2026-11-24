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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Rules Namespace](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') >> [PropertyTextExtensions Class](PropertyTextExtensions.md 'Cat\.Validators\.Rules\.PropertyTextExtensions')

## PropertyTextExtensions\.AsText\<TProperty\>\(this TProperty\) Method

Returns the property as a string\. A `null` property gives `null`\.

```csharp
public static string? AsText<TProperty>(this TProperty property)
    where TProperty : System.Collections.Generic.IEnumerable<char>?;
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyTextExtensions.AsText_TProperty_(thisTProperty).TProperty'></a>

`TProperty`

The type of the property, a string or a sequence of characters\.
#### Parameters

<a name='Cat.Validators.Rules.PropertyTextExtensions.AsText_TProperty_(thisTProperty).property'></a>

`property` [TProperty](PropertyTextExtensions.AsText.PJ4SV3V7RU9HBHG14ZT4CTGV4.md#Cat.Validators.Rules.PropertyTextExtensions.AsText_TProperty_(thisTProperty).TProperty 'Cat\.Validators\.Rules\.PropertyTextExtensions\.AsText\<TProperty\>\(this TProperty\)\.TProperty')

The property value\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The text, or `null` when the property is `null`\.