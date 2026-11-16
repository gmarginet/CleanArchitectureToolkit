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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EXTENSIONS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Extensions\.Strings Assembly](index.md 'index') >> [Cat\.Extensions\.Strings Namespace](Cat.Extensions.Strings.md 'Cat\.Extensions\.Strings')

## StringExtensions Class

Extension methods for [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')\.

```csharp
public static class StringExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → StringExtensions

| Methods | |
| :--- | :--- |
| [CreateRegex\(this string, RegexOptions\)](StringExtensions.CreateRegex.IBOHJE7HXSYEX84EN4BXV2OD7.md 'Cat\.Extensions\.Strings\.StringExtensions\.CreateRegex\(this string, System\.Text\.RegularExpressions\.RegexOptions\)') | Compiles a regular expression with a two\-second matching timeout, so a pathological pattern can't hang the caller\. |
| [FindBraceIndex\(string, char, int, int\)](StringExtensions.FindBraceIndex.X7YFUFE5879U85T3OMS7967EB.md 'Cat\.Extensions\.Strings\.StringExtensions\.FindBraceIndex\(string, char, int, int\)') | Finds the index of the next unescaped occurrence of [brace](StringExtensions.FindBraceIndex.X7YFUFE5879U85T3OMS7967EB.md#Cat.Extensions.Strings.StringExtensions.FindBraceIndex(string,char,int,int).brace 'Cat\.Extensions\.Strings\.StringExtensions\.FindBraceIndex\(string, char, int, int\)\.brace'), treating a doubled brace as an escape\. |
| [NamedFormat\(this string, object\[\]\)](StringExtensions.NamedFormat.ZO86T5UAJ04JB4FNWGSUJLKNC.md 'Cat\.Extensions\.Strings\.StringExtensions\.NamedFormat\(this string, object\[\]\)') | Formats a named message template, for example `"User {UserId} logged in"`, by converting each named placeholder to a positional one and passing the result to [System\.String\.Format\(System\.String,System\.Object\[\]\)](https://learn.microsoft.com/en-us/dotnet/api/system.string.format#system-string-format(system-string-system-object[]) 'System\.String\.Format\(System\.String,System\.Object\[\]\)')\. |
