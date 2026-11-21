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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.INBOX](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Inbox\.EFCore Assembly](index.md 'index') >> [Cat\.Inbox\.EFCore Namespace](Cat.Inbox.EFCore.md 'Cat\.Inbox\.EFCore')

## ModelBuilderExtensions Class

Adds the inbox table to the model of a `DbContext`\.

```csharp
public static class ModelBuilderExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ModelBuilderExtensions

| Methods | |
| :--- | :--- |
| [AddCatInbox\(this ModelBuilder\)](ModelBuilderExtensions.AddCatInbox.63AAC2LQWDZDZ9K1VLGFR1HHB.md 'Cat\.Inbox\.EFCore\.ModelBuilderExtensions\.AddCatInbox\(this Microsoft\.EntityFrameworkCore\.ModelBuilder\)') | Maps [CatInboxMessage](CatInboxMessage.md 'Cat\.Inbox\.EFCore\.CatInboxMessage') to the table `CatInbox`\. Call it from `OnModelCreating`\. Add a migration afterwards, so the table exists\. |
