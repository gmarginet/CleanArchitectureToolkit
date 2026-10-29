<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.String\.Extensions](index.md 'index') > [Cat\.String\.Extensions](Cat.String.Extensions.md 'Cat\.String\.Extensions') > [StringExtensions](StringExtensions.md 'Cat\.String\.Extensions\.StringExtensions')

## StringExtensions\.CreateRegex\(this string, RegexOptions\) Method

Compiles a regular expression with a two\-second matching timeout, so a pathological pattern can't hang the caller\.

```csharp
public static System.Text.RegularExpressions.Regex CreateRegex(this string regexPattern, System.Text.RegularExpressions.RegexOptions options=System.Text.RegularExpressions.RegexOptions.None);
```
#### Parameters

<a name='Cat.String.Extensions.StringExtensions.CreateRegex(thisstring,System.Text.RegularExpressions.RegexOptions).regexPattern'></a>

`regexPattern` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The regex pattern to compile\.

<a name='Cat.String.Extensions.StringExtensions.CreateRegex(thisstring,System.Text.RegularExpressions.RegexOptions).options'></a>

`options` [System\.Text\.RegularExpressions\.RegexOptions](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regexoptions 'System\.Text\.RegularExpressions\.RegexOptions')

The options to compile the regex with\.

#### Returns
[System\.Text\.RegularExpressions\.Regex](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex 'System\.Text\.RegularExpressions\.Regex')  
The compiled [System\.Text\.RegularExpressions\.Regex](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex 'System\.Text\.RegularExpressions\.Regex')\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
Thrown when [regexPattern](StringExtensions.CreateRegex.SG6E26717GKX12GNUTYBZKPBC.md#Cat.String.Extensions.StringExtensions.CreateRegex(thisstring,System.Text.RegularExpressions.RegexOptions).regexPattern 'Cat\.String\.Extensions\.StringExtensions\.CreateRegex\(this string, System\.Text\.RegularExpressions\.RegexOptions\)\.regexPattern') isn't a valid regex pattern\.