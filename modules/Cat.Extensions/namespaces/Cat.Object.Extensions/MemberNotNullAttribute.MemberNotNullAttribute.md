<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Object\.Extensions](index.md 'index') > [System\.Diagnostics\.CodeAnalysis](System.Diagnostics.CodeAnalysis.md 'System\.Diagnostics\.CodeAnalysis') > [MemberNotNullAttribute](MemberNotNullAttribute.md 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullAttribute')

## MemberNotNullAttribute Constructors

| Overloads | |
| :--- | :--- |
| [MemberNotNullAttribute\(string\)](MemberNotNullAttribute.MemberNotNullAttribute.md#System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.MemberNotNullAttribute(string) 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullAttribute\.MemberNotNullAttribute\(string\)') | Initializes the attribute with a field or property member\. |
| [MemberNotNullAttribute\(string\[\]\)](MemberNotNullAttribute.MemberNotNullAttribute.md#System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.MemberNotNullAttribute(string[]) 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullAttribute\.MemberNotNullAttribute\(string\[\]\)') | Initializes the attribute with the list of field and property members\. |

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.MemberNotNullAttribute(string)'></a>

## MemberNotNullAttribute\(string\) Constructor

Initializes the attribute with a field or property member\.

```csharp
public MemberNotNullAttribute(string member);
```
#### Parameters

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.MemberNotNullAttribute(string).member'></a>

`member` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The field or property member that is promised to be not\-null\.

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.MemberNotNullAttribute(string[])'></a>

## MemberNotNullAttribute\(string\[\]\) Constructor

Initializes the attribute with the list of field and property members\.

```csharp
public MemberNotNullAttribute(params string[] members);
```
#### Parameters

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.MemberNotNullAttribute(string[]).members'></a>

`members` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The list of field and property members that are promised to be not\-null\.