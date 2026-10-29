<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Object\.Extensions](index.md 'index')

## System\.Diagnostics\.CodeAnalysis Namespace

| Classes | |
| :--- | :--- |
| [AllowNullAttribute](AllowNullAttribute.md 'System\.Diagnostics\.CodeAnalysis\.AllowNullAttribute') | Specifies that [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') is allowed as an input even if the corresponding type disallows it\. |
| [DisallowNullAttribute](DisallowNullAttribute.md 'System\.Diagnostics\.CodeAnalysis\.DisallowNullAttribute') | Specifies that [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') is disallowed as an input even if the corresponding type allows it\. |
| [DoesNotReturnAttribute](DoesNotReturnAttribute.md 'System\.Diagnostics\.CodeAnalysis\.DoesNotReturnAttribute') | Specifies that a method that will never return under any circumstance\. |
| [DoesNotReturnIfAttribute](DoesNotReturnIfAttribute.md 'System\.Diagnostics\.CodeAnalysis\.DoesNotReturnIfAttribute') | Specifies that the method will not return if the associated [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean') parameter is passed the specified value\. |
| [MaybeNullAttribute](MaybeNullAttribute.md 'System\.Diagnostics\.CodeAnalysis\.MaybeNullAttribute') | Specifies that an output may be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') even if the corresponding type disallows it\. |
| [MaybeNullWhenAttribute](MaybeNullWhenAttribute.md 'System\.Diagnostics\.CodeAnalysis\.MaybeNullWhenAttribute') | Specifies that when a method returns [ReturnValue](MaybeNullWhenAttribute.ReturnValue.md 'System\.Diagnostics\.CodeAnalysis\.MaybeNullWhenAttribute\.ReturnValue'),  the parameter may be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') even if the corresponding type disallows it\. |
| [MemberNotNullAttribute](MemberNotNullAttribute.md 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullAttribute') | Specifies that the method or property will ensure that the listed field and property members have not\-[null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') values\. |
| [MemberNotNullWhenAttribute](MemberNotNullWhenAttribute.md 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullWhenAttribute') | Specifies that the method or property will ensure that the listed field and property members have non\-[null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') values when returning with the specified return value condition\. |
| [NotNullAttribute](NotNullAttribute.md 'System\.Diagnostics\.CodeAnalysis\.NotNullAttribute') | Specifies that an output is not [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') even if the corresponding type allows it\. |
| [NotNullIfNotNullAttribute](NotNullIfNotNullAttribute.md 'System\.Diagnostics\.CodeAnalysis\.NotNullIfNotNullAttribute') | Specifies that the output will be non\-[null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') if the named parameter is non\-[null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\. |
| [NotNullWhenAttribute](NotNullWhenAttribute.md 'System\.Diagnostics\.CodeAnalysis\.NotNullWhenAttribute') | Specifies that when a method returns [ReturnValue](NotNullWhenAttribute.ReturnValue.md 'System\.Diagnostics\.CodeAnalysis\.NotNullWhenAttribute\.ReturnValue'), the parameter will not be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') even if the corresponding type allows it\. |
