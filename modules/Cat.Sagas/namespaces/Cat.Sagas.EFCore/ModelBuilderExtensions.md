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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SAGAS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Sagas\.EFCore Assembly](index.md 'index') >> [Cat\.Sagas\.EFCore Namespace](Cat.Sagas.EFCore.md 'Cat\.Sagas\.EFCore')

## ModelBuilderExtensions Class

Adds the saga table to the model of a `DbContext`\.

```csharp
public static class ModelBuilderExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ModelBuilderExtensions

| Methods | |
| :--- | :--- |
| [AddCatSagas\(this ModelBuilder\)](ModelBuilderExtensions.AddCatSagas.ONPE2ELDHBFDVCG1E70SN9QN8.md 'Cat\.Sagas\.EFCore\.ModelBuilderExtensions\.AddCatSagas\(this Microsoft\.EntityFrameworkCore\.ModelBuilder\)') | Maps [CatSagaInstance](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/CatSagaInstance.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance') to the table `CatSagas`\. The version is the concurrency token\. Call it from `OnModelCreating`\. Add a migration afterwards, so the table exists\. |
