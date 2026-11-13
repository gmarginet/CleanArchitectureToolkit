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
  
##### >> [Cat\.Sql\.Cdc Assembly](index.md 'index') >> [Cat\.Sql\.Cdc Namespace](Cat.Sql.Cdc.md 'Cat\.Sql\.Cdc') >> [CatCdcTableBuilder&lt;TMessage&gt; Class](CatCdcTableBuilder_TMessage_.md 'Cat\.Sql\.Cdc\.CatCdcTableBuilder\<TMessage\>')

## CatCdcTableBuilder\<TMessage\>\.Map\(Func\<CatChange,TMessage\>\) Method

Says how a change becomes a message\. Use [MessageId](../../../Cat.Sql.Cdc/namespaces/Cat.Sql.Cdc.Abstractions/CatChange.MessageId.md 'Cat\.Sql\.Cdc\.Abstractions\.CatChange\.MessageId') as the id of the message\.

```csharp
public Cat.Sql.Cdc.CatCdcTableBuilder<TMessage> Map(System.Func<Cat.Sql.Cdc.Abstractions.CatChange,TMessage> map);
```
#### Parameters

<a name='Cat.Sql.Cdc.CatCdcTableBuilder_TMessage_.Map(System.Func_Cat.Sql.Cdc.Abstractions.CatChange,TMessage_).map'></a>

`map` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[CatChange](../../../Cat.Sql.Cdc/namespaces/Cat.Sql.Cdc.Abstractions/CatChange.md 'Cat\.Sql\.Cdc\.Abstractions\.CatChange')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TMessage](CatCdcTableBuilder_TMessage_.md#Cat.Sql.Cdc.CatCdcTableBuilder_TMessage_.TMessage 'Cat\.Sql\.Cdc\.CatCdcTableBuilder\<TMessage\>\.TMessage')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Makes the message\.

#### Returns
[Cat\.Sql\.Cdc\.CatCdcTableBuilder&lt;](CatCdcTableBuilder_TMessage_.md 'Cat\.Sql\.Cdc\.CatCdcTableBuilder\<TMessage\>')[TMessage](CatCdcTableBuilder_TMessage_.md#Cat.Sql.Cdc.CatCdcTableBuilder_TMessage_.TMessage 'Cat\.Sql\.Cdc\.CatCdcTableBuilder\<TMessage\>\.TMessage')[&gt;](CatCdcTableBuilder_TMessage_.md 'Cat\.Sql\.Cdc\.CatCdcTableBuilder\<TMessage\>')  
The same builder\.