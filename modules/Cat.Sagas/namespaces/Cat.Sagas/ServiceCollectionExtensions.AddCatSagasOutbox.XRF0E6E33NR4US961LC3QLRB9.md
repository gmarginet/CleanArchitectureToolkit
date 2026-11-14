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
  
##### >> [Cat\.Sagas Assembly](index.md 'index') >> [Cat\.Sagas\.Extensions Namespace](Cat.Sagas.Extensions.md 'Cat\.Sagas\.Extensions') >> [ServiceCollectionExtensions Class](ServiceCollectionExtensions.md 'Cat\.Sagas\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatSagasOutbox\(this IServiceCollection\) Method

Tells the engine that the outbox of `Cat.Messaging` is on\. The engine then hands the request to the sender first and saves once,
so the instance and the outbox row commit together\. Call it next to the outbox registration, in any order with [AddCatSagasModule\(this IServiceCollection\)](ServiceCollectionExtensions.AddCatSagasModule.OVT92BC24W6NFTKF3Z9HN100C.md 'Cat\.Sagas\.Extensions\.ServiceCollectionExtensions\.AddCatSagasModule\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)')\.
Without the outbox, do not call it\. The request would go out before the instance is saved\.

```csharp
public static void AddCatSagasOutbox(this Microsoft.Extensions.DependencyInjection.IServiceCollection services);
```
#### Parameters

<a name='Cat.Sagas.Extensions.ServiceCollectionExtensions.AddCatSagasOutbox(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add to\.