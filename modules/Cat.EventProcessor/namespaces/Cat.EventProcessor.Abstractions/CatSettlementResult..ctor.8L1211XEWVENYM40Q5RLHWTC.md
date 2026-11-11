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
  
##### >> [Cat\.EventProcessor\.Abstractions Assembly](index.md 'index') >> [Cat\.EventProcessor\.Abstractions Namespace](Cat.EventProcessor.Abstractions.md 'Cat\.EventProcessor\.Abstractions') >> [CatSettlementResult Class](CatSettlementResult.md 'Cat\.EventProcessor\.Abstractions\.CatSettlementResult')

## CatSettlementResult\(CatSettlement, string, string\) Constructor

Creates a result\.

```csharp
public CatSettlementResult(Cat.EventProcessor.Abstractions.CatSettlement settlement, string reason="", string description="");
```
#### Parameters

<a name='Cat.EventProcessor.Abstractions.CatSettlementResult.CatSettlementResult(Cat.EventProcessor.Abstractions.CatSettlement,string,string).settlement'></a>

`settlement` [CatSettlement](CatSettlement.md 'Cat\.EventProcessor\.Abstractions\.CatSettlement')

What to do with the message\.

<a name='Cat.EventProcessor.Abstractions.CatSettlementResult.CatSettlementResult(Cat.EventProcessor.Abstractions.CatSettlement,string,string).reason'></a>

`reason` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

A short reason, such as an error code\. Empty when the message is completed\.

<a name='Cat.EventProcessor.Abstractions.CatSettlementResult.CatSettlementResult(Cat.EventProcessor.Abstractions.CatSettlement,string,string).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

A longer explanation, such as the error messages\. Empty when the message is completed\.