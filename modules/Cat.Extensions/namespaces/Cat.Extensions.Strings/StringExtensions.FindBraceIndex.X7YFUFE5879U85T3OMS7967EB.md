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
  
##### >> [Cat\.Extensions\.Strings Assembly](index.md 'index') >> [Cat\.Extensions\.Strings Namespace](Cat.Extensions.Strings.md 'Cat\.Extensions\.Strings') >> [StringExtensions Class](StringExtensions.md 'Cat\.Extensions\.Strings\.StringExtensions')

## StringExtensions\.FindBraceIndex\(string, char, int, int\) Method

Finds the index of the next unescaped occurrence of [brace](StringExtensions.FindBraceIndex.X7YFUFE5879U85T3OMS7967EB.md#Cat.Extensions.Strings.StringExtensions.FindBraceIndex(string,char,int,int).brace 'Cat\.Extensions\.Strings\.StringExtensions\.FindBraceIndex\(string, char, int, int\)\.brace'), treating a doubled brace as an escape\.

```csharp
private static int FindBraceIndex(string format, char brace, int startIndex, int endIndex);
```
#### Parameters

<a name='Cat.Extensions.Strings.StringExtensions.FindBraceIndex(string,char,int,int).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The format string to scan\.

<a name='Cat.Extensions.Strings.StringExtensions.FindBraceIndex(string,char,int,int).brace'></a>

`brace` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The brace character to find, either `'{'` or `'}'`\.

<a name='Cat.Extensions.Strings.StringExtensions.FindBraceIndex(string,char,int,int).startIndex'></a>

`startIndex` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index to start scanning from\.

<a name='Cat.Extensions.Strings.StringExtensions.FindBraceIndex(string,char,int,int).endIndex'></a>

`endIndex` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index to stop scanning at\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The index of the brace, or [endIndex](StringExtensions.FindBraceIndex.X7YFUFE5879U85T3OMS7967EB.md#Cat.Extensions.Strings.StringExtensions.FindBraceIndex(string,char,int,int).endIndex 'Cat\.Extensions\.Strings\.StringExtensions\.FindBraceIndex\(string, char, int, int\)\.endIndex') if none was found\.