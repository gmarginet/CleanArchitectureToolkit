<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Object\.Extensions](index.md 'index') > [System\.Diagnostics\.CodeAnalysis](System.Diagnostics.CodeAnalysis.md 'System\.Diagnostics\.CodeAnalysis') > [DoesNotReturnIfAttribute](DoesNotReturnIfAttribute.md 'System\.Diagnostics\.CodeAnalysis\.DoesNotReturnIfAttribute')

## DoesNotReturnIfAttribute\(bool\) Constructor

Initializes a new instance of the [DoesNotReturnIfAttribute](DoesNotReturnIfAttribute.md 'System\.Diagnostics\.CodeAnalysis\.DoesNotReturnIfAttribute')
class with the specified parameter value\.

```csharp
public DoesNotReturnIfAttribute(bool parameterValue);
```
#### Parameters

<a name='System.Diagnostics.CodeAnalysis.DoesNotReturnIfAttribute.DoesNotReturnIfAttribute(bool).parameterValue'></a>

`parameterValue` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The condition parameter value\.
Code after the method is considered unreachable by diagnostics if the argument
to the associated parameter matches this value\.