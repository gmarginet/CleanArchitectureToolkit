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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.MESSAGING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Messaging\.Outbox\.EFCore Assembly](index.md 'index')

## Cat\.Messaging\.Outbox\.EFCore Namespace

The outbox table for EF Core\. A message is added to the same `DbContext` as the entities,
so one `SaveChanges` saves both\.

| Classes | |
| :--- | :--- |
| [CatOutboxMessage](CatOutboxMessage.md 'Cat\.Messaging\.Outbox\.EFCore\.CatOutboxMessage') | One row of the outbox table\. |
| [EfCoreOutboxStore&lt;TDbContext&gt;](EfCoreOutboxStore_TDbContext_.md 'Cat\.Messaging\.Outbox\.EFCore\.EfCoreOutboxStore\<TDbContext\>') | [ICatOutboxStore](../../../Cat.Messaging/namespaces/Cat.Messaging.Outbox/ICatOutboxStore.md 'Cat\.Messaging\.Outbox\.ICatOutboxStore') on a `DbContext` of the service\. |
| [ModelBuilderExtensions](ModelBuilderExtensions.md 'Cat\.Messaging\.Outbox\.EFCore\.ModelBuilderExtensions') | Adds the outbox table to the model of a `DbContext`\. |
