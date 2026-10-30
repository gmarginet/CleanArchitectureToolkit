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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.EXTENSIONS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Object\.Extensions Assembly](index.md 'index')

## System\.Diagnostics\.CodeAnalysis Namespace

| Classes | |
| :--- | :--- |
| [AllowNullAttribute](AllowNullAttribute.md 'System\.Diagnostics\.CodeAnalysis\.AllowNullAttribute') | Specifies that [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') is allowed as an input even if the corresponding type disallows it\. |
| [DisallowNullAttribute](DisallowNullAttribute.md 'System\.Diagnostics\.CodeAnalysis\.DisallowNullAttribute') | Specifies that [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') is disallowed as an input even if the corresponding type allows it\. |
| [DoesNotReturnAttribute](DoesNotReturnAttribute.md 'System\.Diagnostics\.CodeAnalysis\.DoesNotReturnAttribute') | Specifies that a method that will never return under any circumstance\. |
| [DoesNotReturnIfAttribute](DoesNotReturnIfAttribute.md 'System\.Diagnostics\.CodeAnalysis\.DoesNotReturnIfAttribute') | Specifies that the method will not return if the associated [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean') parameter is passed the specified value\. |
| [MaybeNullAttribute](MaybeNullAttribute.md 'System\.Diagnostics\.CodeAnalysis\.MaybeNullAttribute') | Specifies that an output may be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') even if the corresponding type disallows it\. |
| [MaybeNullWhenAttribute](MaybeNullWhenAttribute.md 'System\.Diagnostics\.CodeAnalysis\.MaybeNullWhenAttribute') | Specifies that when a method returns [ReturnValue](MaybeNullWhenAttribute.ReturnValue.md 'System\.Diagnostics\.CodeAnalysis\.MaybeNullWhenAttribute\.ReturnValue'),  the parameter may be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') even if the corresponding type disallows it\. |
| [MemberNotNullAttribute](MemberNotNullAttribute.md 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullAttribute') | Specifies that the method or property will ensure that the listed field and property members have not\-[null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') values\. |
| [MemberNotNullWhenAttribute](MemberNotNullWhenAttribute.md 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullWhenAttribute') | Specifies that the method or property will ensure that the listed field and property members have non\-[null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') values when returning with the specified return value condition\. |
| [NotNullAttribute](NotNullAttribute.md 'System\.Diagnostics\.CodeAnalysis\.NotNullAttribute') | Specifies that an output is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') even if the corresponding type allows it\. |
| [NotNullIfNotNullAttribute](NotNullIfNotNullAttribute.md 'System\.Diagnostics\.CodeAnalysis\.NotNullIfNotNullAttribute') | Specifies that the output will be non\-[null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') if the named parameter is non\-[null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\. |
| [NotNullWhenAttribute](NotNullWhenAttribute.md 'System\.Diagnostics\.CodeAnalysis\.NotNullWhenAttribute') | Specifies that when a method returns [ReturnValue](NotNullWhenAttribute.ReturnValue.md 'System\.Diagnostics\.CodeAnalysis\.NotNullWhenAttribute\.ReturnValue'), the parameter will not be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') even if the corresponding type allows it\. |
