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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.EXTENSIONS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Object\.Extensions Assembly](index.md 'index') >> [System\.Diagnostics\.CodeAnalysis Namespace](System.Diagnostics.CodeAnalysis.md 'System\.Diagnostics\.CodeAnalysis')

## NotNullWhenAttribute Class

Specifies that when a method returns [ReturnValue](NotNullWhenAttribute.ReturnValue.md 'System\.Diagnostics\.CodeAnalysis\.NotNullWhenAttribute\.ReturnValue'),
the parameter will not be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') even if the corresponding type allows it\.

```csharp
internal sealed class NotNullWhenAttribute : System.Attribute
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Attribute](https://learn.microsoft.com/en-us/dotnet/api/system.attribute 'System\.Attribute') → NotNullWhenAttribute

| Constructors | |
| :--- | :--- |
| [NotNullWhenAttribute\(bool\)](NotNullWhenAttribute..ctor.NO02ZHAF7MM27QU6WH7RDQR31.md 'System\.Diagnostics\.CodeAnalysis\.NotNullWhenAttribute\.NotNullWhenAttribute\(bool\)') | Initializes the attribute with the specified return value condition\. |

| Properties | |
| :--- | :--- |
| [ReturnValue](NotNullWhenAttribute.ReturnValue.md 'System\.Diagnostics\.CodeAnalysis\.NotNullWhenAttribute\.ReturnValue') | Gets the return value condition\. If the method returns this value, the associated parameter will not be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\. |
