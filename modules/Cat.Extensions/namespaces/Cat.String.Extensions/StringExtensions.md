<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.String\.Extensions](index.md 'index') > [Cat\.String\.Extensions](Cat.String.Extensions.md 'Cat\.String\.Extensions')

## StringExtensions Class

Extension methods for [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')\.

```csharp
public static class StringExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; StringExtensions

| Methods | |
| :--- | :--- |
| [CreateRegex\(this string, RegexOptions\)](StringExtensions.CreateRegex.SG6E26717GKX12GNUTYBZKPBC.md 'Cat\.String\.Extensions\.StringExtensions\.CreateRegex\(this string, System\.Text\.RegularExpressions\.RegexOptions\)') | Compiles a regular expression with a two\-second matching timeout, so a pathological pattern can't hang the caller\. |
| [FindBraceIndex\(string, char, int, int\)](StringExtensions.FindBraceIndex.AYNNCTTLRLKMAMT9V0W5HDR0C.md 'Cat\.String\.Extensions\.StringExtensions\.FindBraceIndex\(string, char, int, int\)') | Finds the index of the next unescaped occurrence of [brace](StringExtensions.FindBraceIndex.AYNNCTTLRLKMAMT9V0W5HDR0C.md#Cat.String.Extensions.StringExtensions.FindBraceIndex(string,char,int,int).brace 'Cat\.String\.Extensions\.StringExtensions\.FindBraceIndex\(string, char, int, int\)\.brace'), treating a doubled brace as an escape\. |
| [NamedFormat\(this string, object\[\]\)](StringExtensions.NamedFormat.4YCGFV7T1TMWUZ1NXK09MDXVE.md 'Cat\.String\.Extensions\.StringExtensions\.NamedFormat\(this string, object\[\]\)') | Formats a named message template, for example `"User {UserId} logged in"`, by converting each named placeholder to a positional one and passing the result to [System\.String\.Format\(System\.String,System\.Object\[\]\)](https://learn.microsoft.com/en-us/dotnet/api/system.string.format#system-string-format(system-string-system-object[]) 'System\.String\.Format\(System\.String,System\.Object\[\]\)')\. |
