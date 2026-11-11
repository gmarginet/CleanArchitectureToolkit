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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EVENTPROCESSOR](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EventProcessor Assembly](index.md 'index') >> [Cat\.EventProcessor Namespace](Cat.EventProcessor.md 'Cat\.EventProcessor') >> [CatFailureTable Class](CatFailureTable.md 'Cat\.EventProcessor\.CatFailureTable')

## CatFailureTable\.Settle\(ICatResponse, CatReceiveOptions\) Method

Decides what to do with the message\.

```csharp
public static Cat.EventProcessor.Abstractions.CatSettlementResult Settle(Cat.Responses.Abstractions.ICatResponse response, Cat.EventProcessor.Abstractions.CatReceiveOptions options);
```
#### Parameters

<a name='Cat.EventProcessor.CatFailureTable.Settle(Cat.Responses.Abstractions.ICatResponse,Cat.EventProcessor.Abstractions.CatReceiveOptions).response'></a>

`response` [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

The response of the handler\.

<a name='Cat.EventProcessor.CatFailureTable.Settle(Cat.Responses.Abstractions.ICatResponse,Cat.EventProcessor.Abstractions.CatReceiveOptions).options'></a>

`options` [CatReceiveOptions](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/CatReceiveOptions.md 'Cat\.EventProcessor\.Abstractions\.CatReceiveOptions')

The settings of the message type, with the overrides\.

#### Returns
[CatSettlementResult](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/CatSettlementResult.md 'Cat\.EventProcessor\.Abstractions\.CatSettlementResult')  
What to do with the message, and why\.