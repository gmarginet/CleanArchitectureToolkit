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
  
##### >> [Cat\.Sql\.Cdc\.Messaging Assembly](index.md 'index') >> [Cat\.Sql\.Cdc\.Messaging Namespace](Cat.Sql.Cdc.Messaging.md 'Cat\.Sql\.Cdc\.Messaging') >> [CatMessagingChangeSink Class](CatMessagingChangeSink.md 'Cat\.Sql\.Cdc\.Messaging\.CatMessagingChangeSink')

## CatMessagingChangeSink\.Convert\(CatChange\) Method

```csharp
private static Cat.Sql.Cdc.Messaging.CatCdcChangeMessage Convert(Cat.Sql.Cdc.Abstractions.CatChange change);
```
#### Parameters

<a name='Cat.Sql.Cdc.Messaging.CatMessagingChangeSink.Convert(Cat.Sql.Cdc.Abstractions.CatChange).change'></a>

`change` [CatChange](../../../Cat.Sql.Cdc/namespaces/Cat.Sql.Cdc.Abstractions/CatChange.md 'Cat\.Sql\.Cdc\.Abstractions\.CatChange')

#### Returns
[CatCdcChangeMessage](CatCdcChangeMessage.md 'Cat\.Sql\.Cdc\.Messaging\.CatCdcChangeMessage')