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
  
##### >> [Cat\.EventAggregators Assembly](index.md 'index') >> [Cat\.EventAggregators Namespace](Cat.EventAggregators.md 'Cat\.EventAggregators') >> [CatEventAggregator Class](CatEventAggregator.md 'Cat\.EventAggregators\.CatEventAggregator')

## CatEventAggregator\.Subscribe\(object\) Method

Registers a subscriber so it receives events for every [ICatHandleEvent&lt;TEvent&gt;](../../../Cat.EventAggregators/namespaces/Cat.EventAggregators.Abstractions/ICatHandleEvent_TEvent_.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\`1') it implements\.

```csharp
public void Subscribe(object subscriber);
```
#### Parameters

<a name='Cat.EventAggregators.CatEventAggregator.Subscribe(object).subscriber'></a>

`subscriber` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The subscriber instance to register\. It's held by a weak reference, so it won't be kept alive by the aggregator\.

Implements [Subscribe\(object\)](../../../Cat.EventAggregators/namespaces/Cat.EventAggregators.Abstractions/ICatEventAggregator.Subscribe.UAP61SE4Y7K8NH7WZG3YYJWP7.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator\.Subscribe\(System\.Object\)')