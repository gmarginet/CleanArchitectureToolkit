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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.CACHING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Caching Assembly](index.md 'index') >> [Cat\.Caching Namespace](Cat.Caching.md 'Cat\.Caching')

## CatCachingTelemetry Class

The metrics of the query cache\. The tag `query` holds the short name of the query type\.
The key of an entry never goes into a tag, because a key can hold personal data\.

```csharp
public static class CatCachingTelemetry
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCachingTelemetry

| Constructors | |
| :--- | :--- |
| [CatCachingTelemetry\(\)](CatCachingTelemetry.CatCachingTelemetry().md 'Cat\.Caching\.CatCachingTelemetry\.CatCachingTelemetry\(\)') | |

| Fields | |
| :--- | :--- |
| [Hits](CatCachingTelemetry.Hits.md 'Cat\.Caching\.CatCachingTelemetry\.Hits') | |
| [Meter](CatCachingTelemetry.Meter.md 'Cat\.Caching\.CatCachingTelemetry\.Meter') | |
| [MeterName](CatCachingTelemetry.MeterName.md 'Cat\.Caching\.CatCachingTelemetry\.MeterName') | The name of the meter\. `AddCatTelemetry` of `Cat.Telemetry` exports it\. |
| [Misses](CatCachingTelemetry.Misses.md 'Cat\.Caching\.CatCachingTelemetry\.Misses') | |

| Methods | |
| :--- | :--- |
| [Record\(string, bool\)](CatCachingTelemetry.Record.A7110CICYMJPJBSU5D8TUXNXA.md 'Cat\.Caching\.CatCachingTelemetry\.Record\(string, bool\)') | |
