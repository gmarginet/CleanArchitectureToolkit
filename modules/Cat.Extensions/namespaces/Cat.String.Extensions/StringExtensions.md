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
  
##### >> [Cat\.String\.Extensions Assembly](index.md 'index') >> [Cat\.String\.Extensions Namespace](Cat.String.Extensions.md 'Cat\.String\.Extensions')

## StringExtensions Class

Extension methods for [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')\.

```csharp
public static class StringExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → StringExtensions

| Methods | |
| :--- | :--- |
| [CreateRegex\(this string, RegexOptions\)](StringExtensions.CreateRegex.SG6E26717GKX12GNUTYBZKPBC.md 'Cat\.String\.Extensions\.StringExtensions\.CreateRegex\(this string, System\.Text\.RegularExpressions\.RegexOptions\)') | Compiles a regular expression with a two\-second matching timeout, so a pathological pattern can't hang the caller\. |
| [FindBraceIndex\(string, char, int, int\)](StringExtensions.FindBraceIndex.AYNNCTTLRLKMAMT9V0W5HDR0C.md 'Cat\.String\.Extensions\.StringExtensions\.FindBraceIndex\(string, char, int, int\)') | Finds the index of the next unescaped occurrence of [brace](StringExtensions.FindBraceIndex.AYNNCTTLRLKMAMT9V0W5HDR0C.md#Cat.String.Extensions.StringExtensions.FindBraceIndex(string,char,int,int).brace 'Cat\.String\.Extensions\.StringExtensions\.FindBraceIndex\(string, char, int, int\)\.brace'), treating a doubled brace as an escape\. |
| [NamedFormat\(this string, object\[\]\)](StringExtensions.NamedFormat.4YCGFV7T1TMWUZ1NXK09MDXVE.md 'Cat\.String\.Extensions\.StringExtensions\.NamedFormat\(this string, object\[\]\)') | Formats a named message template, for example `"User {UserId} logged in"`, by converting each named placeholder to a positional one and passing the result to [System\.String\.Format\(System\.String,System\.Object\[\]\)](https://learn.microsoft.com/en-us/dotnet/api/system.string.format#system-string-format(system-string-system-object[]) 'System\.String\.Format\(System\.String,System\.Object\[\]\)')\. |
