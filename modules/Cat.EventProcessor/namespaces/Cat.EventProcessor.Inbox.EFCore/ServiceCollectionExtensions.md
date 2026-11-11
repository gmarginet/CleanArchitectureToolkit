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
  
##### >> [Cat\.EventProcessor\.Inbox\.EFCore Assembly](index.md 'index') >> [Cat\.EventProcessor\.Inbox\.EFCore\.Extensions Namespace](Cat.EventProcessor.Inbox.EFCore.Extensions.md 'Cat\.EventProcessor\.Inbox\.EFCore\.Extensions')

## ServiceCollectionExtensions Class

Registration helpers for the EF Core inbox\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatEventProcessorInbox&lt;TDbContext&gt;\(this IServiceCollection\)](ServiceCollectionExtensions.AddCatEventProcessorInbox.F32HS6QJ7RHMBOH0NTSFNY6H4.md 'Cat\.EventProcessor\.Inbox\.EFCore\.Extensions\.ServiceCollectionExtensions\.AddCatEventProcessorInbox\<TDbContext\>\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)') | Registers the inbox store on the given context\. The context must call [AddCatInbox\(this ModelBuilder\)](ModelBuilderExtensions.AddCatInbox.E9EHKR34AM1DFIZQXF0V8XE9A.md 'Cat\.EventProcessor\.Inbox\.EFCore\.ModelBuilderExtensions\.AddCatInbox\(this Microsoft\.EntityFrameworkCore\.ModelBuilder\)') in `OnModelCreating`\. Call [UseCatEventProcessorInbox\(this IServiceProvider\)](ServiceCollectionExtensions.UseCatEventProcessorInbox.9O8PEZ49E818LW3Y72IIATU4F.md 'Cat\.EventProcessor\.Inbox\.EFCore\.Extensions\.ServiceCollectionExtensions\.UseCatEventProcessorInbox\(this System\.IServiceProvider\)') on the built service provider to switch the decorator on\. |
| [UseCatEventProcessorInbox\(this IServiceProvider\)](ServiceCollectionExtensions.UseCatEventProcessorInbox.9O8PEZ49E818LW3Y72IIATU4F.md 'Cat\.EventProcessor\.Inbox\.EFCore\.Extensions\.ServiceCollectionExtensions\.UseCatEventProcessorInbox\(this System\.IServiceProvider\)') | Adds the inbox decorator to the service request handlers\. Call it on the built service provider, after `Build()`\. |
