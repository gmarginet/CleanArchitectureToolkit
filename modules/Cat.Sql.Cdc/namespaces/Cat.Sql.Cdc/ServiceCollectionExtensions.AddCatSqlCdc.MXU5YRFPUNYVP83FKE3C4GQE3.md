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
  
##### >> [Cat\.Sql\.Cdc Assembly](index.md 'index') >> [Cat\.Sql\.Cdc\.Extensions Namespace](Cat.Sql.Cdc.Extensions.md 'Cat\.Sql\.Cdc\.Extensions') >> [ServiceCollectionExtensions Class](ServiceCollectionExtensions.md 'Cat\.Sql\.Cdc\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatSqlCdc\(this IServiceCollection, IConfiguration, Action\<CatCdcBuilder\>\) Method

Registers the reader as a hosted service\. It reads the tables you add and hands every change to the registered
[ICatChangeSink](../../../Cat.Sql.Cdc/namespaces/Cat.Sql.Cdc.Abstractions/ICatChangeSink.md 'Cat\.Sql\.Cdc\.Abstractions\.ICatChangeSink')\. Register a sink too, such as the one of `Cat.Sql.Cdc.Messaging`\.
The module never enables change data capture\. Do that yourself with `sys.sp_cdc_enable_table`\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddCatSqlCdc(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration, System.Action<Cat.Sql.Cdc.CatCdcBuilder> declare);
```
#### Parameters

<a name='Cat.Sql.Cdc.Extensions.ServiceCollectionExtensions.AddCatSqlCdc(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.Action_Cat.Sql.Cdc.CatCdcBuilder_).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add to\.

<a name='Cat.Sql.Cdc.Extensions.ServiceCollectionExtensions.AddCatSqlCdc(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.Action_Cat.Sql.Cdc.CatCdcBuilder_).configuration'></a>

`configuration` [Microsoft\.Extensions\.Configuration\.IConfiguration](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.iconfiguration 'Microsoft\.Extensions\.Configuration\.IConfiguration')

Gives the settings from the section `CatSqlCdc`, see [CatCdcSettings](CatCdcSettings.md 'Cat\.Sql\.Cdc\.CatCdcSettings')\.

<a name='Cat.Sql.Cdc.Extensions.ServiceCollectionExtensions.AddCatSqlCdc(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.Action_Cat.Sql.Cdc.CatCdcBuilder_).declare'></a>

`declare` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[CatCdcBuilder](CatCdcBuilder.md 'Cat\.Sql\.Cdc\.CatCdcBuilder')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Adds the tables to capture\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')  
The service collection\.