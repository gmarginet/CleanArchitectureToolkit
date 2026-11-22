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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.LOCALIZATIONS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Localizations\.Abstractions Assembly](index.md 'index') >> [Cat\.Localizations\.Abstractions Namespace](Cat.Localizations.Abstractions.md 'Cat\.Localizations\.Abstractions')

## CatTranslation Class

One translated text: one entity, one field and one language\. The table holds one row for each combination\.
There is no foreign key to the entity, so one table serves every translatable entity\.

```csharp
public class CatTranslation
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatTranslation

| Properties | |
| :--- | :--- |
| [Culture](CatTranslation.Culture.md 'Cat\.Localizations\.Abstractions\.CatTranslation\.Culture') | Gets or sets the culture name, such as `nl` or `nl-BE`\. |
| [EntityId](CatTranslation.EntityId.md 'Cat\.Localizations\.Abstractions\.CatTranslation\.EntityId') | Gets or sets the id of the translated entity\. |
| [EntityType](CatTranslation.EntityType.md 'Cat\.Localizations\.Abstractions\.CatTranslation\.EntityType') | Gets or sets the type name of the entity, such as `Category`\. |
| [Field](CatTranslation.Field.md 'Cat\.Localizations\.Abstractions\.CatTranslation\.Field') | Gets or sets the name of the translated field, such as `Name`\. |
| [Id](CatTranslation.Id.md 'Cat\.Localizations\.Abstractions\.CatTranslation\.Id') | Gets or sets the unique id of the translation\. It is the key\. |
| [Text](CatTranslation.Text.md 'Cat\.Localizations\.Abstractions\.CatTranslation\.Text') | Gets or sets the translated text\. |
