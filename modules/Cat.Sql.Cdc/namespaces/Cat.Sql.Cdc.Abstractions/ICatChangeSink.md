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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SQL.CDC](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Sql\.Cdc\.Abstractions Assembly](index.md 'index') >> [Cat\.Sql\.Cdc\.Abstractions Namespace](Cat.Sql.Cdc.Abstractions.md 'Cat\.Sql\.Cdc\.Abstractions')

## ICatChangeSink Interface

Receives the changes the reader found\. Implement it to send a change anywhere\. `Cat.Sql.Cdc.Messaging` has one that sends through `Cat.Messaging`\.
The module delivers at least once\. After a crash the same change can arrive again, so the sink or the receiver must cope with a repeat\.

```csharp
public interface ICatChangeSink
```

| Methods | |
| :--- | :--- |
| [SendAsync\(CatChange, object, CancellationToken\)](ICatChangeSink.SendAsync.KY62MICCI5DHYOSMRH4EJVNFB.md 'Cat\.Sql\.Cdc\.Abstractions\.ICatChangeSink\.SendAsync\(Cat\.Sql\.Cdc\.Abstractions\.CatChange, object, System\.Threading\.CancellationToken\)') | Sends one change\. When it throws, the module does not move its position and tries the same change again\. |
