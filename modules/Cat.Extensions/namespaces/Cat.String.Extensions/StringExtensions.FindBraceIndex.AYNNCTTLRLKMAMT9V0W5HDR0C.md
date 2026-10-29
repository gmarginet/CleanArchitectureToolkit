<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.String\.Extensions](index.md 'index') > [Cat\.String\.Extensions](Cat.String.Extensions.md 'Cat\.String\.Extensions') > [StringExtensions](StringExtensions.md 'Cat\.String\.Extensions\.StringExtensions')

## StringExtensions\.FindBraceIndex\(string, char, int, int\) Method

Finds the index of the next unescaped occurrence of [brace](StringExtensions.FindBraceIndex.AYNNCTTLRLKMAMT9V0W5HDR0C.md#Cat.String.Extensions.StringExtensions.FindBraceIndex(string,char,int,int).brace 'Cat\.String\.Extensions\.StringExtensions\.FindBraceIndex\(string, char, int, int\)\.brace'), treating a doubled brace as an escape\.

```csharp
private static int FindBraceIndex(string format, char brace, int startIndex, int endIndex);
```
#### Parameters

<a name='Cat.String.Extensions.StringExtensions.FindBraceIndex(string,char,int,int).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The format string to scan\.

<a name='Cat.String.Extensions.StringExtensions.FindBraceIndex(string,char,int,int).brace'></a>

`brace` [System\.Char](https://learn.microsoft.com/en-us/dotnet/api/system.char 'System\.Char')

The brace character to find, either `'{'` or `'}'`\.

<a name='Cat.String.Extensions.StringExtensions.FindBraceIndex(string,char,int,int).startIndex'></a>

`startIndex` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index to start scanning from\.

<a name='Cat.String.Extensions.StringExtensions.FindBraceIndex(string,char,int,int).endIndex'></a>

`endIndex` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The index to stop scanning at\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
The index of the brace, or [endIndex](StringExtensions.FindBraceIndex.AYNNCTTLRLKMAMT9V0W5HDR0C.md#Cat.String.Extensions.StringExtensions.FindBraceIndex(string,char,int,int).endIndex 'Cat\.String\.Extensions\.StringExtensions\.FindBraceIndex\(string, char, int, int\)\.endIndex') if none was found\.