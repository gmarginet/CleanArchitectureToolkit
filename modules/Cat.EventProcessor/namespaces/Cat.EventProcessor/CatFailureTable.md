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
  
##### >> [Cat\.EventProcessor Assembly](index.md 'index') >> [Cat\.EventProcessor Namespace](Cat.EventProcessor.md 'Cat\.EventProcessor')

## CatFailureTable Class

Turns the response of a handler into an action on the message\.
A succeeded response completes the message\. `InternalServerError` abandons it, so the bus delivers it again\.
Every other failure dead letters it at once, because trying again gives the same answer\.
The settings of the message type can override the table per response type\.

```csharp
internal static class CatFailureTable
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatFailureTable

| Methods | |
| :--- | :--- |
| [DefaultFor\(CatResponseType\)](CatFailureTable.DefaultFor.18UN3XXOX96NR8A4VC7B9EO2C.md 'Cat\.EventProcessor\.CatFailureTable\.DefaultFor\(Cat\.Responses\.Abstractions\.CatResponseType\)') | |
| [Settle\(ICatResponse, CatReceiveOptions\)](CatFailureTable.Settle.L1B9M3KZE5XQ7WSABXXBA7NF2.md 'Cat\.EventProcessor\.CatFailureTable\.Settle\(Cat\.Responses\.Abstractions\.ICatResponse, Cat\.EventProcessor\.Abstractions\.CatReceiveOptions\)') | Decides what to do with the message\. |
