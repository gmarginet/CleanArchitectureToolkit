<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.ServiceRequests\.Decorators\.ActivitySource](index.md 'index') > [Cat\.ServiceRequests\.Decorators\.ActivitySource](Cat.ServiceRequests.Decorators.ActivitySource.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource') > [ActivitySourceDecorator](ActivitySourceDecorator.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator') > [ServiceRequestActivitySource](ActivitySourceDecorator.ServiceRequestActivitySource.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.ServiceRequestActivitySource')

## ActivitySourceDecorator\.ServiceRequestActivitySource\.CreateActivity\(string\) Method

Starts a client activity\.

```csharp
public static System.Diagnostics.Activity? CreateActivity(string name);
```
#### Parameters

<a name='Cat.ServiceRequests.Decorators.ActivitySource.ActivitySourceDecorator.ServiceRequestActivitySource.CreateActivity(string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The display name of the activity\.

#### Returns
[System\.Diagnostics\.Activity](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.activity 'System\.Diagnostics\.Activity')  
The activity, or `null` when nobody listens to the source\.