<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Object\.Extensions](index.md 'index') > [System\.Diagnostics\.CodeAnalysis](System.Diagnostics.CodeAnalysis.md 'System\.Diagnostics\.CodeAnalysis') > [MemberNotNullWhenAttribute](MemberNotNullWhenAttribute.md 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullWhenAttribute')

## MemberNotNullWhenAttribute Constructors

| Overloads | |
| :--- | :--- |
| [MemberNotNullWhenAttribute\(bool, string\)](MemberNotNullWhenAttribute.MemberNotNullWhenAttribute.md#System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute.MemberNotNullWhenAttribute(bool,string) 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullWhenAttribute\.MemberNotNullWhenAttribute\(bool, string\)') | Initializes the attribute with the specified return value condition and a field or property member\. |
| [MemberNotNullWhenAttribute\(bool, string\[\]\)](MemberNotNullWhenAttribute.MemberNotNullWhenAttribute.md#System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute.MemberNotNullWhenAttribute(bool,string[]) 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullWhenAttribute\.MemberNotNullWhenAttribute\(bool, string\[\]\)') | Initializes the attribute with the specified return value condition and list of field and property members\. |

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute.MemberNotNullWhenAttribute(bool,string)'></a>

## MemberNotNullWhenAttribute\(bool, string\) Constructor

Initializes the attribute with the specified return value condition and a field or property member\.

```csharp
public MemberNotNullWhenAttribute(bool returnValue, string member);
```
#### Parameters

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute.MemberNotNullWhenAttribute(bool,string).returnValue'></a>

`returnValue` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The return value condition\. If the method returns this value,
the associated parameter will not be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute.MemberNotNullWhenAttribute(bool,string).member'></a>

`member` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The field or property member that is promised to be not\-[null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute.MemberNotNullWhenAttribute(bool,string[])'></a>

## MemberNotNullWhenAttribute\(bool, string\[\]\) Constructor

Initializes the attribute with the specified return value condition and list
of field and property members\.

```csharp
public MemberNotNullWhenAttribute(bool returnValue, params string[] members);
```
#### Parameters

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute.MemberNotNullWhenAttribute(bool,string[]).returnValue'></a>

`returnValue` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The return value condition\. If the method returns this value,
the associated parameter will not be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute.MemberNotNullWhenAttribute(bool,string[]).members'></a>

`members` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The list of field and property members that are promised to be not\-null\.