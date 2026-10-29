<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Object\.Extensions](index.md 'index') > [System\.Diagnostics\.CodeAnalysis](System.Diagnostics.CodeAnalysis.md 'System\.Diagnostics\.CodeAnalysis')

## MaybeNullWhenAttribute Class

Specifies that when a method returns [ReturnValue](MaybeNullWhenAttribute.ReturnValue.md 'System\.Diagnostics\.CodeAnalysis\.MaybeNullWhenAttribute\.ReturnValue'), 
the parameter may be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') even if the corresponding type disallows it\.

```csharp
internal sealed class MaybeNullWhenAttribute : System.Attribute
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.Attribute](https://learn.microsoft.com/en-us/dotnet/api/system.attribute 'System\.Attribute') &#129106; MaybeNullWhenAttribute

| Constructors | |
| :--- | :--- |
| [MaybeNullWhenAttribute\(bool\)](MaybeNullWhenAttribute..ctor.N8N78SEHT8ORVH68KBYX870IB.md 'System\.Diagnostics\.CodeAnalysis\.MaybeNullWhenAttribute\.MaybeNullWhenAttribute\(bool\)') | Initializes the attribute with the specified return value condition\. |

| Properties | |
| :--- | :--- |
| [ReturnValue](MaybeNullWhenAttribute.ReturnValue.md 'System\.Diagnostics\.CodeAnalysis\.MaybeNullWhenAttribute\.ReturnValue') | Gets the return value condition\. If the method returns this value, the associated parameter may be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\. |
