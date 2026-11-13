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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EFCORE](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EFCore\.Entities Assembly](index.md 'index')

## Cat\.EFCore\.Entities Namespace

Provides the base classes for Entity Framework Core entities:
regular entities, temporal entities and entities that map tables owned by someone else\.

| Classes | |
| :--- | :--- |
| [CatEntityBase](CatEntityBase.md 'Cat\.EFCore\.Entities\.CatEntityBase') | Base class for entities that live in a regular table\. It gives every entity a unique id and a database generated sequence number\. |
| [CatReferenceEntityBase](CatReferenceEntityBase.md 'Cat\.EFCore\.Entities\.CatReferenceEntityBase') | Base class for entities that map a table owned by someone else\. Use it when the table belongs to another service, or to another part of the system, in a database you share\. Map the entity in your own `DbContext` so you can define foreign keys and navigations to it\. The table is excluded from migrations, so the owner keeps control of the schema\. Treat the entity as read\-only, and do not use it for your own tables\. Use [CatEntityBase](CatEntityBase.md 'Cat\.EFCore\.Entities\.CatEntityBase') for those\. |
