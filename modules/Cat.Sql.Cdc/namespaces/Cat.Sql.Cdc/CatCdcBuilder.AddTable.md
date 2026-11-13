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
  
##### >> [Cat\.Sql\.Cdc Assembly](index.md 'index') >> [Cat\.Sql\.Cdc Namespace](Cat.Sql.Cdc.md 'Cat\.Sql\.Cdc') >> [CatCdcBuilder Class](CatCdcBuilder.md 'Cat\.Sql\.Cdc\.CatCdcBuilder')

## CatCdcBuilder\.AddTable Method

| Overloads | |
| :--- | :--- |
| [AddTable\(string\)](CatCdcBuilder.AddTable.md#Cat.Sql.Cdc.CatCdcBuilder.AddTable(string) 'Cat\.Sql\.Cdc\.CatCdcBuilder\.AddTable\(string\)') | Captures a table and sends every change as it is\. The sink gets the [CatChange](../../../Cat.Sql.Cdc/namespaces/Cat.Sql.Cdc.Abstractions/CatChange.md 'Cat\.Sql\.Cdc\.Abstractions\.CatChange') as the message\. |
| [AddTable&lt;TMessage&gt;\(string, Action&lt;CatCdcTableBuilder&lt;TMessage&gt;&gt;\)](CatCdcBuilder.AddTable.md#Cat.Sql.Cdc.CatCdcBuilder.AddTable_TMessage_(string,System.Action_Cat.Sql.Cdc.CatCdcTableBuilder_TMessage__) 'Cat\.Sql\.Cdc\.CatCdcBuilder\.AddTable\<TMessage\>\(string, System\.Action\<Cat\.Sql\.Cdc\.CatCdcTableBuilder\<TMessage\>\>\)') | Captures a table and turns every change into a message of your own type\. |

<a name='Cat.Sql.Cdc.CatCdcBuilder.AddTable(string)'></a>

## CatCdcBuilder\.AddTable\(string\) Method

Captures a table and sends every change as it is\. The sink gets the [CatChange](../../../Cat.Sql.Cdc/namespaces/Cat.Sql.Cdc.Abstractions/CatChange.md 'Cat\.Sql\.Cdc\.Abstractions\.CatChange') as the message\.

```csharp
public Cat.Sql.Cdc.CatCdcBuilder AddTable(string captureInstance);
```
#### Parameters

<a name='Cat.Sql.Cdc.CatCdcBuilder.AddTable(string).captureInstance'></a>

`captureInstance` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The capture instance, such as `dbo_BookPrice`\. Only letters, digits and underscores\.

#### Returns
[CatCdcBuilder](CatCdcBuilder.md 'Cat\.Sql\.Cdc\.CatCdcBuilder')  
The same builder\.

<a name='Cat.Sql.Cdc.CatCdcBuilder.AddTable_TMessage_(string,System.Action_Cat.Sql.Cdc.CatCdcTableBuilder_TMessage__)'></a>

## CatCdcBuilder\.AddTable\<TMessage\>\(string, Action\<CatCdcTableBuilder\<TMessage\>\>\) Method

Captures a table and turns every change into a message of your own type\.

```csharp
public Cat.Sql.Cdc.CatCdcBuilder AddTable<TMessage>(string captureInstance, System.Action<Cat.Sql.Cdc.CatCdcTableBuilder<TMessage>> configure)
    where TMessage : class;
```
#### Type parameters

<a name='Cat.Sql.Cdc.CatCdcBuilder.AddTable_TMessage_(string,System.Action_Cat.Sql.Cdc.CatCdcTableBuilder_TMessage__).TMessage'></a>

`TMessage`

The message type\.
#### Parameters

<a name='Cat.Sql.Cdc.CatCdcBuilder.AddTable_TMessage_(string,System.Action_Cat.Sql.Cdc.CatCdcTableBuilder_TMessage__).captureInstance'></a>

`captureInstance` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The capture instance, such as `dbo_BookPrice`\. Only letters, digits and underscores\.

<a name='Cat.Sql.Cdc.CatCdcBuilder.AddTable_TMessage_(string,System.Action_Cat.Sql.Cdc.CatCdcTableBuilder_TMessage__).configure'></a>

`configure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.Sql\.Cdc\.CatCdcTableBuilder&lt;](CatCdcTableBuilder_TMessage_.md 'Cat\.Sql\.Cdc\.CatCdcTableBuilder\<TMessage\>')[TMessage](CatCdcBuilder.AddTable.md#Cat.Sql.Cdc.CatCdcBuilder.AddTable_TMessage_(string,System.Action_Cat.Sql.Cdc.CatCdcTableBuilder_TMessage__).TMessage 'Cat\.Sql\.Cdc\.CatCdcBuilder\.AddTable\<TMessage\>\(string, System\.Action\<Cat\.Sql\.Cdc\.CatCdcTableBuilder\<TMessage\>\>\)\.TMessage')[&gt;](CatCdcTableBuilder_TMessage_.md 'Cat\.Sql\.Cdc\.CatCdcTableBuilder\<TMessage\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Sets the mapping with `t.Map(change => ...)`\.

#### Returns
[CatCdcBuilder](CatCdcBuilder.md 'Cat\.Sql\.Cdc\.CatCdcBuilder')  
The same builder\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
The configuration gives no mapping\.