<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Object\.Extensions](index.md 'index') > [System\.Diagnostics\.CodeAnalysis](System.Diagnostics.CodeAnalysis.md 'System\.Diagnostics\.CodeAnalysis')

## NotNullIfNotNullAttribute Class

Specifies that the output will be non\-[null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') if the
named parameter is non\-[null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

```csharp
internal sealed class NotNullIfNotNullAttribute : System.Attribute
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.Attribute](https://learn.microsoft.com/en-us/dotnet/api/system.attribute 'System\.Attribute') &#129106; NotNullIfNotNullAttribute

| Constructors | |
| :--- | :--- |
| [NotNullIfNotNullAttribute\(string\)](NotNullIfNotNullAttribute..ctor.4ZAETD8WVEXTUJAAM549BCUY3.md 'System\.Diagnostics\.CodeAnalysis\.NotNullIfNotNullAttribute\.NotNullIfNotNullAttribute\(string\)') | Initializes the attribute with the associated parameter name\. |

| Properties | |
| :--- | :--- |
| [ParameterName](NotNullIfNotNullAttribute.ParameterName.md 'System\.Diagnostics\.CodeAnalysis\.NotNullIfNotNullAttribute\.ParameterName') | Gets the associated parameter name\. The output will be non\-[null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') if the argument to the parameter specified is non\-[null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\. |
