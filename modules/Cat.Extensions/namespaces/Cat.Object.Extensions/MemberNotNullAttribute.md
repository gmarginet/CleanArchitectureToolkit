<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Object\.Extensions](index.md 'index') > [System\.Diagnostics\.CodeAnalysis](System.Diagnostics.CodeAnalysis.md 'System\.Diagnostics\.CodeAnalysis')

## MemberNotNullAttribute Class

Specifies that the method or property will ensure that the listed field and property members have
not\-[null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') values\.

```csharp
internal sealed class MemberNotNullAttribute : System.Attribute
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.Attribute](https://learn.microsoft.com/en-us/dotnet/api/system.attribute 'System\.Attribute') &#129106; MemberNotNullAttribute

| Constructors | |
| :--- | :--- |
| [MemberNotNullAttribute\(string\)](MemberNotNullAttribute.MemberNotNullAttribute.md#System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.MemberNotNullAttribute(string) 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullAttribute\.MemberNotNullAttribute\(string\)') | Initializes the attribute with a field or property member\. |
| [MemberNotNullAttribute\(string\[\]\)](MemberNotNullAttribute.MemberNotNullAttribute.md#System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.MemberNotNullAttribute(string[]) 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullAttribute\.MemberNotNullAttribute\(string\[\]\)') | Initializes the attribute with the list of field and property members\. |

| Properties | |
| :--- | :--- |
| [Members](MemberNotNullAttribute.Members.md 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullAttribute\.Members') | Gets field or property member names\. |
