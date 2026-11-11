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
  
##### >> [Cat\.EventProcessor\.Abstractions Assembly](index.md 'index') >> [Cat\.EventProcessor\.Abstractions Namespace](Cat.EventProcessor.Abstractions.md 'Cat\.EventProcessor\.Abstractions')

## CatSettlementResult Class

The outcome of handling one message: what to do with it, and why\.

```csharp
public class CatSettlementResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatSettlementResult

| Constructors | |
| :--- | :--- |
| [CatSettlementResult\(CatSettlement, string, string\)](CatSettlementResult..ctor.8L1211XEWVENYM40Q5RLHWTC.md 'Cat\.EventProcessor\.Abstractions\.CatSettlementResult\.CatSettlementResult\(Cat\.EventProcessor\.Abstractions\.CatSettlement, string, string\)') | Creates a result\. |

| Properties | |
| :--- | :--- |
| [Description](CatSettlementResult.Description.md 'Cat\.EventProcessor\.Abstractions\.CatSettlementResult\.Description') | A longer explanation\. The broker copies it to the dead letter description\. |
| [Reason](CatSettlementResult.Reason.md 'Cat\.EventProcessor\.Abstractions\.CatSettlementResult\.Reason') | A short reason\. The broker copies it to the dead letter reason\. |
| [Settlement](CatSettlementResult.Settlement.md 'Cat\.EventProcessor\.Abstractions\.CatSettlementResult\.Settlement') | What to do with the message\. |
