<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.String\.Extensions](index.md 'index') > [Cat\.String\.Extensions](Cat.String.Extensions.md 'Cat\.String\.Extensions') > [StringExtensions](StringExtensions.md 'Cat\.String\.Extensions\.StringExtensions')

## StringExtensions\.NamedFormat\(this string, object\[\]\) Method

Formats a named message template, for example `"User {UserId} logged in"`, by converting each named
placeholder to a positional one and passing the result to [System\.String\.Format\(System\.String,System\.Object\[\]\)](https://learn.microsoft.com/en-us/dotnet/api/system.string.format#system-string-format(system-string-system-object[]) 'System\.String\.Format\(System\.String,System\.Object\[\]\)')\.

```csharp
public static string NamedFormat(this string format, params object?[] args);
```
#### Parameters

<a name='Cat.String.Extensions.StringExtensions.NamedFormat(thisstring,object[]).format'></a>

`format` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The named format string\. Placeholder names are only there for readability; values are matched by position\.

<a name='Cat.String.Extensions.StringExtensions.NamedFormat(thisstring,object[]).args'></a>

`args` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The values to substitute into the placeholders, in order\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The formatted string\.