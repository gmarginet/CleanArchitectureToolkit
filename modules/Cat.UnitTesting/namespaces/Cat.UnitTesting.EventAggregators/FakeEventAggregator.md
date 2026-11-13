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

## FakeEventAggregator Class

An event aggregator for unit tests of code that publishes events\. It records what is published and who subscribes,
and it calls no subscriber\. To test the subscribers too, use the real aggregator with a [RecordingSubscriber&lt;TEvent&gt;](RecordingSubscriber_TEvent_.md 'Cat\.UnitTesting\.EventAggregators\.RecordingSubscriber\<TEvent\>')\.

```csharp
public class FakeEventAggregator : Cat.EventAggregators.Abstractions.ICatEventAggregator
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → FakeEventAggregator

Implements [ICatEventAggregator](../../../Cat.EventAggregators/namespaces/Cat.EventAggregators.Abstractions/ICatEventAggregator.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator')

| Properties | |
| :--- | :--- |
| [Published](FakeEventAggregator.Published.md 'Cat\.UnitTesting\.EventAggregators\.FakeEventAggregator\.Published') | Every event that was published, in order\. |
| [Subscribers](FakeEventAggregator.Subscribers.md 'Cat\.UnitTesting\.EventAggregators\.FakeEventAggregator\.Subscribers') | Every subscriber that is subscribed now, in the order of the calls\. |

| Methods | |
| :--- | :--- |
| [HasSubscribersForEvent\(Type\)](FakeEventAggregator.HasSubscribersForEvent.N22ADJWMD2EU1BCLCNUZZ6F59.md 'Cat\.UnitTesting\.EventAggregators\.FakeEventAggregator\.HasSubscribersForEvent\(System\.Type\)') | Checks whether any live subscriber currently handles the given event type\. |
| [Of&lt;T&gt;\(\)](FakeEventAggregator.Of_T_().md 'Cat\.UnitTesting\.EventAggregators\.FakeEventAggregator\.Of\<T\>\(\)') | Gives the published events of one type, in order\. |
| [PublishAsync\(object, CancellationToken\)](FakeEventAggregator.PublishAsync.84ZR24SCE60II16HZ8C9960R5.md 'Cat\.UnitTesting\.EventAggregators\.FakeEventAggregator\.PublishAsync\(object, System\.Threading\.CancellationToken\)') | Publishes an event to every live subscriber that handles its type, and waits for all handlers to complete\. |
| [Reset\(\)](FakeEventAggregator.Reset().md 'Cat\.UnitTesting\.EventAggregators\.FakeEventAggregator\.Reset\(\)') | Clears the published events and the subscribers\. |
| [Subscribe\(object\)](FakeEventAggregator.Subscribe.5E8A5U9KTYFWIA8X7BVJNPM9.md 'Cat\.UnitTesting\.EventAggregators\.FakeEventAggregator\.Subscribe\(object\)') | Registers a subscriber so it receives events for every [ICatHandleEvent&lt;TEvent&gt;](../../../Cat.EventAggregators/namespaces/Cat.EventAggregators.Abstractions/ICatHandleEvent_TEvent_.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\`1') it implements\. |
| [Unsubscribe\(object\)](FakeEventAggregator.Unsubscribe.6QOLROL3CQODWADJ6KPBEXLQA.md 'Cat\.UnitTesting\.EventAggregators\.FakeEventAggregator\.Unsubscribe\(object\)') | Removes a previously registered subscriber so it stops receiving events\. |
