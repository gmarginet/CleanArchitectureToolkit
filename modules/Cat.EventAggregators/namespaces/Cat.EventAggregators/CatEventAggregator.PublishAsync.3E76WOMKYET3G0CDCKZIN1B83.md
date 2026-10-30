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
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.EVENTAGGREGATORS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EventAggregators Assembly](index.md 'index') >> [Cat\.EventAggregators Namespace](Cat.EventAggregators.md 'Cat\.EventAggregators') >> [CatEventAggregator Class](CatEventAggregator.md 'Cat\.EventAggregators\.CatEventAggregator')

## CatEventAggregator\.PublishAsync\(object, CancellationToken\) Method

Publishes an event to every live subscriber that handles its type, and waits for all handlers to complete\.

```csharp
public System.Threading.Tasks.Task PublishAsync(object @event, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.EventAggregators.CatEventAggregator.PublishAsync(object,System.Threading.CancellationToken).event'></a>

`event` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The event instance to publish\.

<a name='Cat.EventAggregators.CatEventAggregator.PublishAsync(object,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the publish operation\.

Implements [PublishAsync\(object, CancellationToken\)](../../../Cat.EventAggregators/namespaces/Cat.EventAggregators.Abstractions/ICatEventAggregator.PublishAsync.255NNT0CTQLR4IZT88LNX6BZ7.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator\.PublishAsync\(System\.Object,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')