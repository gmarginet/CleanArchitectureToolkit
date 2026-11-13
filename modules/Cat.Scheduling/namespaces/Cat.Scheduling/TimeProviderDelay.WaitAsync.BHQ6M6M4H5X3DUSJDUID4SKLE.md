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
  
##### >> [Cat\.Scheduling Assembly](index.md 'index') >> [Cat\.Scheduling Namespace](Cat.Scheduling.md 'Cat\.Scheduling') >> [TimeProviderDelay Class](TimeProviderDelay.md 'Cat\.Scheduling\.TimeProviderDelay')

## TimeProviderDelay\.WaitAsync\(TimeProvider, TimeSpan, CancellationToken\) Method

Waits for the given time\. It returns at once when the time is zero or negative\.

```csharp
public static System.Threading.Tasks.Task WaitAsync(System.TimeProvider timeProvider, System.TimeSpan delay, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.Scheduling.TimeProviderDelay.WaitAsync(System.TimeProvider,System.TimeSpan,System.Threading.CancellationToken).timeProvider'></a>

`timeProvider` [System\.TimeProvider](https://learn.microsoft.com/en-us/dotnet/api/system.timeprovider 'System\.TimeProvider')

The clock to wait on\.

<a name='Cat.Scheduling.TimeProviderDelay.WaitAsync(System.TimeProvider,System.TimeSpan,System.Threading.CancellationToken).delay'></a>

`delay` [System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')

How long to wait\.

<a name='Cat.Scheduling.TimeProviderDelay.WaitAsync(System.TimeProvider,System.TimeSpan,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the wait\.

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A task that completes after the delay\.