<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Object\.Extensions](index.md 'index') > [System\.Diagnostics\.CodeAnalysis](System.Diagnostics.CodeAnalysis.md 'System\.Diagnostics\.CodeAnalysis')

## DoesNotReturnIfAttribute Class

Specifies that the method will not return if the associated [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')
parameter is passed the specified value\.

```csharp
internal sealed class DoesNotReturnIfAttribute : System.Attribute
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [System\.Attribute](https://learn.microsoft.com/en-us/dotnet/api/system.attribute 'System\.Attribute') &#129106; DoesNotReturnIfAttribute

| Constructors | |
| :--- | :--- |
| [DoesNotReturnIfAttribute\(bool\)](DoesNotReturnIfAttribute..ctor.STT6CM3QMK941KXOUDQFJUVQE.md 'System\.Diagnostics\.CodeAnalysis\.DoesNotReturnIfAttribute\.DoesNotReturnIfAttribute\(bool\)') | Initializes a new instance of the [DoesNotReturnIfAttribute](DoesNotReturnIfAttribute.md 'System\.Diagnostics\.CodeAnalysis\.DoesNotReturnIfAttribute') class with the specified parameter value\. |

| Properties | |
| :--- | :--- |
| [ParameterValue](DoesNotReturnIfAttribute.ParameterValue.md 'System\.Diagnostics\.CodeAnalysis\.DoesNotReturnIfAttribute\.ParameterValue') | Gets the condition parameter value\. Code after the method is considered unreachable by diagnostics if the argument to the associated parameter matches this value\. |
