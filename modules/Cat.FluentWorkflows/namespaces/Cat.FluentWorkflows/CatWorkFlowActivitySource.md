<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Telemetry](Cat.FluentWorkflows.Telemetry.md 'Cat\.FluentWorkflows\.Telemetry')

## CatWorkFlowActivitySource Class

The activity source for tracing workflows\. Add [ActivitySourceName](CatWorkFlowActivitySource.ActivitySourceName.md 'Cat\.FluentWorkflows\.Telemetry\.CatWorkFlowActivitySource\.ActivitySourceName') to your OpenTelemetry setup to collect the traces\.

```csharp
public class CatWorkFlowActivitySource
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatWorkFlowActivitySource

| Fields | |
| :--- | :--- |
| [ActivitySourceName](CatWorkFlowActivitySource.ActivitySourceName.md 'Cat\.FluentWorkflows\.Telemetry\.CatWorkFlowActivitySource\.ActivitySourceName') | The name of the activity source\. |
| [Instance](CatWorkFlowActivitySource.Instance.md 'Cat\.FluentWorkflows\.Telemetry\.CatWorkFlowActivitySource\.Instance') | The shared activity source\. |

| Methods | |
| :--- | :--- |
| [CreateActivity\(string\)](CatWorkFlowActivitySource.CreateActivity.3D34RJ3L96YWHGLIPTB2LZRJ3.md 'Cat\.FluentWorkflows\.Telemetry\.CatWorkFlowActivitySource\.CreateActivity\(string\)') | Starts an activity\. |
