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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.EVENTAGGREGATORS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EventAggregators\.Abstractions Assembly](index.md 'index') >> [Cat\.EventAggregators\.Abstractions Namespace](Cat.EventAggregators.Abstractions.md 'Cat\.EventAggregators\.Abstractions') >> [ICatEventAggregator Interface](ICatEventAggregator.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator')

## ICatEventAggregator\.PublishAsync\(object, CancellationToken\) Method

Publishes an event to every live subscriber that handles its type, and waits for all handlers to complete\.

```csharp
System.Threading.Tasks.Task PublishAsync(object @event, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.EventAggregators.Abstractions.ICatEventAggregator.PublishAsync(object,System.Threading.CancellationToken).event'></a>

`event` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The event instance to publish\.

<a name='Cat.EventAggregators.Abstractions.ICatEventAggregator.PublishAsync(object,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the publish operation\.

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')