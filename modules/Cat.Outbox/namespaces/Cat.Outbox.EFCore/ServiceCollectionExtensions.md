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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.OUTBOX](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Outbox\.EFCore Assembly](index.md 'index') >> [Cat\.Outbox\.EFCore\.Extensions Namespace](Cat.Outbox.EFCore.Extensions.md 'Cat\.Outbox\.EFCore\.Extensions')

## ServiceCollectionExtensions Class

Registration helpers for the EF Core outbox\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatOutboxEfCore&lt;TDbContext&gt;\(this IServiceCollection\)](ServiceCollectionExtensions.AddCatOutboxEfCore.4KLZ0TAFRG4RLC55CG1CM8G44.md 'Cat\.Outbox\.EFCore\.Extensions\.ServiceCollectionExtensions\.AddCatOutboxEfCore\<TDbContext\>\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)') | Registers the EF Core outbox store on the given context\. The context must call [AddCatOutbox\(this ModelBuilder\)](ModelBuilderExtensions.AddCatOutbox.4MBVYQYL34QU6L00E6KOBZ401.md 'Cat\.Outbox\.EFCore\.ModelBuilderExtensions\.AddCatOutbox\(this Microsoft\.EntityFrameworkCore\.ModelBuilder\)') in `OnModelCreating`\. |
