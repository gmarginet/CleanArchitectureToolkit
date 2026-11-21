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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SERVICEREQUESTS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.ServiceRequests\.Decorators\.ActivitySource Assembly](index.md 'index') >> [Cat\.ServiceRequests\.Decorators\.ActivitySource Namespace](Cat.ServiceRequests.Decorators.ActivitySource.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource')

## CatServiceRequestsTelemetry Class

The names and the metrics of the service request decorator\.
Add [SourceName](CatServiceRequestsTelemetry.SourceName.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.CatServiceRequestsTelemetry\.SourceName') to your OpenTelemetry setup, for traces and for metrics, to see the calls\.

```csharp
public static class CatServiceRequestsTelemetry
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatServiceRequestsTelemetry

| Constructors | |
| :--- | :--- |
| [CatServiceRequestsTelemetry\(\)](CatServiceRequestsTelemetry.CatServiceRequestsTelemetry().md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.CatServiceRequestsTelemetry\.CatServiceRequestsTelemetry\(\)') | |

| Fields | |
| :--- | :--- |
| [Calls](CatServiceRequestsTelemetry.Calls.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.CatServiceRequestsTelemetry\.Calls') | |
| [Duration](CatServiceRequestsTelemetry.Duration.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.CatServiceRequestsTelemetry\.Duration') | |
| [ExceptionOutcome](CatServiceRequestsTelemetry.ExceptionOutcome.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.CatServiceRequestsTelemetry\.ExceptionOutcome') | |
| [Meter](CatServiceRequestsTelemetry.Meter.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.CatServiceRequestsTelemetry\.Meter') | |
| [SourceName](CatServiceRequestsTelemetry.SourceName.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.CatServiceRequestsTelemetry\.SourceName') | The name of the trace source and the meter\. |
| [TypeTag](CatServiceRequestsTelemetry.TypeTag.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.CatServiceRequestsTelemetry\.TypeTag') | The tag of a span that holds the name of the service request type\. |

| Methods | |
| :--- | :--- |
| [OutcomeOf\(ICatResponse\)](CatServiceRequestsTelemetry.OutcomeOf.IW2IGUBMUXOPW8GMWVEGJLUQ5.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.CatServiceRequestsTelemetry\.OutcomeOf\(Cat\.Responses\.Abstractions\.ICatResponse\)') | |
| [Record\(string, string, long\)](CatServiceRequestsTelemetry.Record.P3LI81UZKB1C04J2W96OJKGBC.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.CatServiceRequestsTelemetry\.Record\(string, string, long\)') | |
