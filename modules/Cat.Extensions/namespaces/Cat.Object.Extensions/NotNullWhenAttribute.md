<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Object\.Extensions](index.md 'index') > [System\.Diagnostics\.CodeAnalysis](System.Diagnostics.CodeAnalysis.md 'System\.Diagnostics\.CodeAnalysis')

## NotNullWhenAttribute Class

Specifies that when a method returns [ReturnValue](NotNullWhenAttribute.ReturnValue.md 'System\.Diagnostics\.CodeAnalysis\.NotNullWhenAttribute\.ReturnValue'),
the parameter will not be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') even if the corresponding type allows it\.

```csharp
internal sealed class NotNullWhenAttribute : System.Attribute
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.Attribute](https://learn.microsoft.com/en-us/dotnet/api/system.attribute 'System\.Attribute') &#129106; NotNullWhenAttribute

| Constructors | |
| :--- | :--- |
| [NotNullWhenAttribute\(bool\)](NotNullWhenAttribute..ctor.NO02ZHAF7MM27QU6WH7RDQR31.md 'System\.Diagnostics\.CodeAnalysis\.NotNullWhenAttribute\.NotNullWhenAttribute\(bool\)') | Initializes the attribute with the specified return value condition\. |

| Properties | |
| :--- | :--- |
| [ReturnValue](NotNullWhenAttribute.ReturnValue.md 'System\.Diagnostics\.CodeAnalysis\.NotNullWhenAttribute\.ReturnValue') | Gets the return value condition\. If the method returns this value, the associated parameter will not be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\. |
