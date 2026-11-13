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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.UNITTESTING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.UnitTesting\.EventAggregators Assembly](index.md 'index') >> [Cat\.UnitTesting\.EventAggregators Namespace](Cat.UnitTesting.EventAggregators.md 'Cat\.UnitTesting\.EventAggregators')

## RecordingSubscriber\<TEvent\> Class

A subscriber that collects every event it gets\. Subscribe it to the aggregator that the test uses\.
Keep a reference to it while it must receive events, because the aggregator holds a subscriber weakly\.

```csharp
public class RecordingSubscriber<TEvent> : Cat.EventAggregators.Abstractions.ICatHandleEvent<TEvent>
```
#### Type parameters

<a name='Cat.UnitTesting.EventAggregators.RecordingSubscriber_TEvent_.TEvent'></a>

`TEvent`

The event type to collect\. Use an interface or a base type to collect several event types\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → RecordingSubscriber\<TEvent\>

Implements [Cat\.EventAggregators\.Abstractions\.ICatHandleEvent&lt;](../../../Cat.EventAggregators/namespaces/Cat.EventAggregators.Abstractions/ICatHandleEvent_TEvent_.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\`1')[TEvent](RecordingSubscriber_TEvent_.md#Cat.UnitTesting.EventAggregators.RecordingSubscriber_TEvent_.TEvent 'Cat\.UnitTesting\.EventAggregators\.RecordingSubscriber\<TEvent\>\.TEvent')[&gt;](../../../Cat.EventAggregators/namespaces/Cat.EventAggregators.Abstractions/ICatHandleEvent_TEvent_.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\`1')

| Properties | |
| :--- | :--- |
| [Events](RecordingSubscriber_TEvent_.Events.md 'Cat\.UnitTesting\.EventAggregators\.RecordingSubscriber\<TEvent\>\.Events') | Every event that was handled, in order\. |

| Methods | |
| :--- | :--- |
| [HandleEventAsync\(TEvent, CancellationToken\)](RecordingSubscriber_TEvent_.HandleEventAsync.PMAB3DRJA9YC7QDH9FJJZQTAA.md 'Cat\.UnitTesting\.EventAggregators\.RecordingSubscriber\<TEvent\>\.HandleEventAsync\(TEvent, System\.Threading\.CancellationToken\)') | Handles a published event\. |
