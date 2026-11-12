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
  
##### >> [Cat\.EventProcessor\.Inbox\.EFCore Assembly](index.md 'index') >> [Cat\.EventProcessor\.Inbox\.EFCore Namespace](Cat.EventProcessor.Inbox.EFCore.md 'Cat\.EventProcessor\.Inbox\.EFCore') >> [EfCoreInboxStore&lt;TDbContext&gt; Class](EfCoreInboxStore_TDbContext_.md 'Cat\.EventProcessor\.Inbox\.EFCore\.EfCoreInboxStore\<TDbContext\>')

## EfCoreInboxStore\<TDbContext\>\.Add\(string, string\) Method

Adds the message to the inbox\. It does not save by itself\. The `SaveChanges` of the handler saves it with the work\.

```csharp
public void Add(string messageId, string messageType);
```
#### Parameters

<a name='Cat.EventProcessor.Inbox.EFCore.EfCoreInboxStore_TDbContext_.Add(string,string).messageId'></a>

`messageId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The ID of the message\.

<a name='Cat.EventProcessor.Inbox.EFCore.EfCoreInboxStore_TDbContext_.Add(string,string).messageType'></a>

`messageType` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the message type\.

Implements [Add\(string, string\)](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/ICatInboxStore.Add.UU452UCKDNFMMBAMI19088PP6.md 'Cat\.EventProcessor\.Abstractions\.ICatInboxStore\.Add\(System\.String,System\.String\)')