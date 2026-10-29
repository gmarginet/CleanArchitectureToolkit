<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Telemetry](Cat.FluentWorkflows.Telemetry.md 'Cat\.FluentWorkflows\.Telemetry') > [CatWorkFlowActivitySource](CatWorkFlowActivitySource.md 'Cat\.FluentWorkflows\.Telemetry\.CatWorkFlowActivitySource')

## CatWorkFlowActivitySource\.CreateActivity\(string\) Method

Starts an activity\.

```csharp
public static System.Diagnostics.Activity? CreateActivity(string name);
```
#### Parameters

<a name='Cat.FluentWorkflows.Telemetry.CatWorkFlowActivitySource.CreateActivity(string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The display name of the activity\.

#### Returns
[System\.Diagnostics\.Activity](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.activity 'System\.Diagnostics\.Activity')  
The activity, or `null` when nobody listens to the source\.