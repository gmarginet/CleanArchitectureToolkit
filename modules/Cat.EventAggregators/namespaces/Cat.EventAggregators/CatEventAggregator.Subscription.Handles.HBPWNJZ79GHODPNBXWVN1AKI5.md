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
  
##### >> [Cat\.EventAggregators Assembly](index.md 'index') >> [Cat\.EventAggregators Namespace](Cat.EventAggregators.md 'Cat\.EventAggregators') >> [CatEventAggregator Class](CatEventAggregator.md 'Cat\.EventAggregators\.CatEventAggregator') >> [Subscription Class](CatEventAggregator.Subscription.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscription')

## CatEventAggregator\.Subscription\.Handles\(Type\) Method

Checks whether the subscriber handles the given event type\.

```csharp
public bool Handles(System.Type eventType);
```
#### Parameters

<a name='Cat.EventAggregators.CatEventAggregator.Subscription.Handles(System.Type).eventType'></a>

`eventType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The event type to check for\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if the subscriber has a handler assignable from [eventType](CatEventAggregator.Subscription.Handles.HBPWNJZ79GHODPNBXWVN1AKI5.md#Cat.EventAggregators.CatEventAggregator.Subscription.Handles(System.Type).eventType 'Cat\.EventAggregators\.CatEventAggregator\.Subscription\.Handles\(System\.Type\)\.eventType')\.