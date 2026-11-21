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
  
##### >> [Cat\.Telemetry Assembly](index.md 'index') >> [Cat\.Telemetry\.Extensions Namespace](Cat.Telemetry.Extensions.md 'Cat\.Telemetry\.Extensions') >> [HostApplicationBuilderExtensions Class](HostApplicationBuilderExtensions.md 'Cat\.Telemetry\.Extensions\.HostApplicationBuilderExtensions')

## HostApplicationBuilderExtensions\.AddCatTelemetry\<TBuilder\>\(this TBuilder, Action\<CatTelemetryOptions\>, Action\<TracerProviderBuilder\>, Action\<MeterProviderBuilder\>\) Method

Sets up logs, metrics and traces with OpenTelemetry\. It works with or without Aspire\.

```csharp
public static TBuilder AddCatTelemetry<TBuilder>(this TBuilder builder, System.Action<Cat.Telemetry.CatTelemetryOptions>? configure=null, System.Action<OpenTelemetry.Trace.TracerProviderBuilder>? tracing=null, System.Action<OpenTelemetry.Metrics.MeterProviderBuilder>? metrics=null)
    where TBuilder : Microsoft.Extensions.Hosting.IHostApplicationBuilder;
```
#### Type parameters

<a name='Cat.Telemetry.Extensions.HostApplicationBuilderExtensions.AddCatTelemetry_TBuilder_(thisTBuilder,System.Action_Cat.Telemetry.CatTelemetryOptions_,System.Action_OpenTelemetry.Trace.TracerProviderBuilder_,System.Action_OpenTelemetry.Metrics.MeterProviderBuilder_).TBuilder'></a>

`TBuilder`

The type of the builder\.
#### Parameters

<a name='Cat.Telemetry.Extensions.HostApplicationBuilderExtensions.AddCatTelemetry_TBuilder_(thisTBuilder,System.Action_Cat.Telemetry.CatTelemetryOptions_,System.Action_OpenTelemetry.Trace.TracerProviderBuilder_,System.Action_OpenTelemetry.Metrics.MeterProviderBuilder_).builder'></a>

`builder` [TBuilder](HostApplicationBuilderExtensions.AddCatTelemetry.46CDPRVK3D06FNYWGAIGNOLE5.md#Cat.Telemetry.Extensions.HostApplicationBuilderExtensions.AddCatTelemetry_TBuilder_(thisTBuilder,System.Action_Cat.Telemetry.CatTelemetryOptions_,System.Action_OpenTelemetry.Trace.TracerProviderBuilder_,System.Action_OpenTelemetry.Metrics.MeterProviderBuilder_).TBuilder 'Cat\.Telemetry\.Extensions\.HostApplicationBuilderExtensions\.AddCatTelemetry\<TBuilder\>\(this TBuilder, System\.Action\<Cat\.Telemetry\.CatTelemetryOptions\>, System\.Action\<OpenTelemetry\.Trace\.TracerProviderBuilder\>, System\.Action\<OpenTelemetry\.Metrics\.MeterProviderBuilder\>\)\.TBuilder')

The builder of the host or the web application\.

<a name='Cat.Telemetry.Extensions.HostApplicationBuilderExtensions.AddCatTelemetry_TBuilder_(thisTBuilder,System.Action_Cat.Telemetry.CatTelemetryOptions_,System.Action_OpenTelemetry.Trace.TracerProviderBuilder_,System.Action_OpenTelemetry.Metrics.MeterProviderBuilder_).configure'></a>

`configure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[CatTelemetryOptions](CatTelemetryOptions.md 'Cat\.Telemetry\.CatTelemetryOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Changes the settings\. The configuration section `Cat:Telemetry` is read first\.

<a name='Cat.Telemetry.Extensions.HostApplicationBuilderExtensions.AddCatTelemetry_TBuilder_(thisTBuilder,System.Action_Cat.Telemetry.CatTelemetryOptions_,System.Action_OpenTelemetry.Trace.TracerProviderBuilder_,System.Action_OpenTelemetry.Metrics.MeterProviderBuilder_).tracing'></a>

`tracing` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[OpenTelemetry\.Trace\.TracerProviderBuilder](https://learn.microsoft.com/en-us/dotnet/api/opentelemetry.trace.tracerproviderbuilder 'OpenTelemetry\.Trace\.TracerProviderBuilder')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Adds to the traces, for example another source or exporter\.

<a name='Cat.Telemetry.Extensions.HostApplicationBuilderExtensions.AddCatTelemetry_TBuilder_(thisTBuilder,System.Action_Cat.Telemetry.CatTelemetryOptions_,System.Action_OpenTelemetry.Trace.TracerProviderBuilder_,System.Action_OpenTelemetry.Metrics.MeterProviderBuilder_).metrics'></a>

`metrics` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[OpenTelemetry\.Metrics\.MeterProviderBuilder](https://learn.microsoft.com/en-us/dotnet/api/opentelemetry.metrics.meterproviderbuilder 'OpenTelemetry\.Metrics\.MeterProviderBuilder')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Adds to the metrics, for example another meter or exporter\.

#### Returns
[TBuilder](HostApplicationBuilderExtensions.AddCatTelemetry.46CDPRVK3D06FNYWGAIGNOLE5.md#Cat.Telemetry.Extensions.HostApplicationBuilderExtensions.AddCatTelemetry_TBuilder_(thisTBuilder,System.Action_Cat.Telemetry.CatTelemetryOptions_,System.Action_OpenTelemetry.Trace.TracerProviderBuilder_,System.Action_OpenTelemetry.Metrics.MeterProviderBuilder_).TBuilder 'Cat\.Telemetry\.Extensions\.HostApplicationBuilderExtensions\.AddCatTelemetry\<TBuilder\>\(this TBuilder, System\.Action\<Cat\.Telemetry\.CatTelemetryOptions\>, System\.Action\<OpenTelemetry\.Trace\.TracerProviderBuilder\>, System\.Action\<OpenTelemetry\.Metrics\.MeterProviderBuilder\>\)\.TBuilder')  
The same builder, for chaining\.

### Remarks
The traces hold the sources of the CAT modules, ASP\.NET Core and `HttpClient`, and leave out the health paths of
[IgnoredPaths](CatTelemetryOptions.IgnoredPaths.md 'Cat\.Telemetry\.CatTelemetryOptions\.IgnoredPaths')\. The metrics hold the meters of the CAT modules, Polly, ASP\.NET Core,
`HttpClient` and the runtime\. The logs carry the trace and the span that run when the record is written\.
The data goes to an OTLP endpoint when `OTEL_EXPORTER_OTLP_ENDPOINT` is set\. Any other exporter, source or meter
goes in the callbacks\. The sampler follows the standard variables `OTEL_TRACES_SAMPLER` and `OTEL_TRACES_SAMPLER_ARG`\.