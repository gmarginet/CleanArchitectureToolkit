<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Object\.Extensions](index.md 'index') > [System\.Diagnostics\.CodeAnalysis](System.Diagnostics.CodeAnalysis.md 'System\.Diagnostics\.CodeAnalysis')

## MemberNotNullWhenAttribute Class

Specifies that the method or property will ensure that the listed field and property members have
non\-[null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') values when returning with the specified return value condition\.

```csharp
internal sealed class MemberNotNullWhenAttribute : System.Attribute
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.Attribute](https://learn.microsoft.com/en-us/dotnet/api/system.attribute 'System\.Attribute') &#129106; MemberNotNullWhenAttribute

| Constructors | |
| :--- | :--- |
| [MemberNotNullWhenAttribute\(bool, string\)](MemberNotNullWhenAttribute.MemberNotNullWhenAttribute.md#System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute.MemberNotNullWhenAttribute(bool,string) 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullWhenAttribute\.MemberNotNullWhenAttribute\(bool, string\)') | Initializes the attribute with the specified return value condition and a field or property member\. |
| [MemberNotNullWhenAttribute\(bool, string\[\]\)](MemberNotNullWhenAttribute.MemberNotNullWhenAttribute.md#System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute.MemberNotNullWhenAttribute(bool,string[]) 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullWhenAttribute\.MemberNotNullWhenAttribute\(bool, string\[\]\)') | Initializes the attribute with the specified return value condition and list of field and property members\. |

| Properties | |
| :--- | :--- |
| [Members](MemberNotNullWhenAttribute.Members.md 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullWhenAttribute\.Members') | Gets field or property member names\. |
| [ReturnValue](MemberNotNullWhenAttribute.ReturnValue.md 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullWhenAttribute\.ReturnValue') | Gets the return value condition\. |
