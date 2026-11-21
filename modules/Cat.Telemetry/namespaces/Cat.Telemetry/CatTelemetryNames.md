<link href="../../../../resources/styles/style.css" rel="stylesheet"/>
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../../../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.TELEMETRY](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Telemetry Assembly](index.md 'index') >> [Cat\.Telemetry Namespace](Cat.Telemetry.md 'Cat\.Telemetry')

## CatTelemetryNames Class

The names of the activity sources and the meters of the CAT modules\.
The name of a module is also the name of its source and its meter\.
A module does not depend on `Cat.Telemetry`, so these constants repeat what the modules publish\.

```csharp
public static class CatTelemetryNames
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatTelemetryNames

| Constructors | |
| :--- | :--- |
| [CatTelemetryNames\(\)](CatTelemetryNames.CatTelemetryNames().md 'Cat\.Telemetry\.CatTelemetryNames\.CatTelemetryNames\(\)') | |

| Fields | |
| :--- | :--- |
| [Caching](CatTelemetryNames.Caching.md 'Cat\.Telemetry\.CatTelemetryNames\.Caching') | The meter of `Cat.Caching`, with the number of hits and misses of the query cache\. |
| [CorrelationIdTag](CatTelemetryNames.CorrelationIdTag.md 'Cat\.Telemetry\.CatTelemetryNames\.CorrelationIdTag') | The tag of a span or a log scope that holds the correlation id of a request or a message\. |
| [EventProcessor](CatTelemetryNames.EventProcessor.md 'Cat\.Telemetry\.CatTelemetryNames\.EventProcessor') | The source of `Cat.EventProcessor`, with the handling of a message as a span in the trace of its sender\. |
| [FluentWorkflows](CatTelemetryNames.FluentWorkflows.md 'Cat\.Telemetry\.CatTelemetryNames\.FluentWorkflows') | The source of the workflow processor of `Cat.FluentWorkflows`\. |
| [Messaging](CatTelemetryNames.Messaging.md 'Cat\.Telemetry\.CatTelemetryNames\.Messaging') | The meter of `Cat.Messaging`, with the number of dead letter messages\. |
| [Polly](CatTelemetryNames.Polly.md 'Cat\.Telemetry\.CatTelemetryNames\.Polly') | The meter of Polly, which `Cat.Resilience` uses\. Its name is outside the naming scheme of the CAT modules, because the module has no meter of its own\. |
| [Scheduling](CatTelemetryNames.Scheduling.md 'Cat\.Telemetry\.CatTelemetryNames\.Scheduling') | The source and the meter of `Cat.Scheduling`\. |
| [ServiceRequests](CatTelemetryNames.ServiceRequests.md 'Cat\.Telemetry\.CatTelemetryNames\.ServiceRequests') | The source and the meter of the service request decorator of `Cat.ServiceRequests`\. |
| [SqlCdc](CatTelemetryNames.SqlCdc.md 'Cat\.Telemetry\.CatTelemetryNames\.SqlCdc') | The meter of `Cat.Sql.Cdc`\. |

| Properties | |
| :--- | :--- |
| [Modules](CatTelemetryNames.Modules.md 'Cat\.Telemetry\.CatTelemetryNames\.Modules') | Every source and meter above that belongs to a CAT module\. `AddCatTelemetry` adds them to the traces and to the metrics\. A name that a module does not use for one of the two is harmless there\. |
