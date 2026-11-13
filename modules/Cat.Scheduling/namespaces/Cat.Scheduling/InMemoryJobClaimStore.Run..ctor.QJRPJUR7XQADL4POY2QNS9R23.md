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
  
##### >> [Cat\.Scheduling Assembly](index.md 'index') >> [Cat\.Scheduling Namespace](Cat.Scheduling.md 'Cat\.Scheduling') >> [InMemoryJobClaimStore Class](InMemoryJobClaimStore.md 'Cat\.Scheduling\.InMemoryJobClaimStore') >> [Run Class](InMemoryJobClaimStore.Run.md 'Cat\.Scheduling\.InMemoryJobClaimStore\.Run')

## Run\(string, DateTimeOffset, DateTimeOffset\) Constructor

```csharp
public Run(string jobName, System.DateTimeOffset dueTime, System.DateTimeOffset startedAt);
```
#### Parameters

<a name='Cat.Scheduling.InMemoryJobClaimStore.Run.Run(string,System.DateTimeOffset,System.DateTimeOffset).jobName'></a>

`jobName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Scheduling.InMemoryJobClaimStore.Run.Run(string,System.DateTimeOffset,System.DateTimeOffset).dueTime'></a>

`dueTime` [System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')

<a name='Cat.Scheduling.InMemoryJobClaimStore.Run.Run(string,System.DateTimeOffset,System.DateTimeOffset).startedAt'></a>

`startedAt` [System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')