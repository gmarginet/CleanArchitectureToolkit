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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EVENTPROCESSOR](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EventProcessor Assembly](index.md 'index') >> [Cat\.EventProcessor Namespace](Cat.EventProcessor.md 'Cat\.EventProcessor')

## CatEventProcessorTelemetry Class

The trace source of the event processor\.

```csharp
public static class CatEventProcessorTelemetry
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatEventProcessorTelemetry

| Constructors | |
| :--- | :--- |
| [CatEventProcessorTelemetry\(\)](CatEventProcessorTelemetry.CatEventProcessorTelemetry().md 'Cat\.EventProcessor\.CatEventProcessorTelemetry\.CatEventProcessorTelemetry\(\)') | |

| Fields | |
| :--- | :--- |
| [ActivitySource](CatEventProcessorTelemetry.ActivitySource.md 'Cat\.EventProcessor\.CatEventProcessorTelemetry\.ActivitySource') | |
| [DiagnosticIdProperty](CatEventProcessorTelemetry.DiagnosticIdProperty.md 'Cat\.EventProcessor\.CatEventProcessorTelemetry\.DiagnosticIdProperty') | The property of a message that holds the W3C `traceparent` of the code that sent it\. |
| [SourceName](CatEventProcessorTelemetry.SourceName.md 'Cat\.EventProcessor\.CatEventProcessorTelemetry\.SourceName') | The name of the trace source\. Add it to your OpenTelemetry setup to see the handling of a message as a span in the trace of the service that sent it\. |

| Methods | |
| :--- | :--- |
| [StartReceive\(string, CatIncomingMessage\)](CatEventProcessorTelemetry.StartReceive.CTYLQVWTMA214YDW1ZH23L8E1.md 'Cat\.EventProcessor\.CatEventProcessorTelemetry\.StartReceive\(string, Cat\.EventProcessor\.Abstractions\.CatIncomingMessage\)') | Starts the activity of the handling of a message, with the activity of the sender as its parent\. Returns null when nobody listens to the source, or when the current activity already belongs to the trace of the sender, for example because the SDK of the broker started it\. |
