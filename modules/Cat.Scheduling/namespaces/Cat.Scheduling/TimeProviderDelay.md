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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SCHEDULING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Scheduling Assembly](index.md 'index') >> [Cat\.Scheduling Namespace](Cat.Scheduling.md 'Cat\.Scheduling')

## TimeProviderDelay Class

Waits on a [System\.TimeProvider](https://learn.microsoft.com/en-us/dotnet/api/system.timeprovider 'System\.TimeProvider'), so a test with a fake clock can move time forward\.

```csharp
internal static class TimeProviderDelay
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → TimeProviderDelay

| Constructors | |
| :--- | :--- |
| [TimeProviderDelay\(\)](TimeProviderDelay.TimeProviderDelay().md 'Cat\.Scheduling\.TimeProviderDelay\.TimeProviderDelay\(\)') | |

| Fields | |
| :--- | :--- |
| [LongestWait](TimeProviderDelay.LongestWait.md 'Cat\.Scheduling\.TimeProviderDelay\.LongestWait') | |

| Methods | |
| :--- | :--- |
| [WaitAsync\(TimeProvider, TimeSpan, CancellationToken\)](TimeProviderDelay.WaitAsync.BHQ6M6M4H5X3DUSJDUID4SKLE.md 'Cat\.Scheduling\.TimeProviderDelay\.WaitAsync\(System\.TimeProvider, System\.TimeSpan, System\.Threading\.CancellationToken\)') | Waits for the given time\. It returns at once when the time is zero or negative\. |
| [WaitOnceAsync\(TimeProvider, TimeSpan, CancellationToken\)](TimeProviderDelay.WaitOnceAsync.PY5NM9GZ1YTDLU8ABROBS7TM9.md 'Cat\.Scheduling\.TimeProviderDelay\.WaitOnceAsync\(System\.TimeProvider, System\.TimeSpan, System\.Threading\.CancellationToken\)') | |
