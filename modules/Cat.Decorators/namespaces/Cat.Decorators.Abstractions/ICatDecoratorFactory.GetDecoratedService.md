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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.DECORATORS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Decorators\.Abstractions Assembly](index.md 'index') >> [Cat\.Decorators\.Abstractions Namespace](Cat.Decorators.Abstractions.md 'Cat\.Decorators\.Abstractions') >> [ICatDecoratorFactory Interface](ICatDecoratorFactory.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory')

## ICatDecoratorFactory\.GetDecoratedService Method

| Overloads | |
| :--- | :--- |
| [GetDecoratedService\(IServiceProvider, Type\)](ICatDecoratorFactory.GetDecoratedService.md#Cat.Decorators.Abstractions.ICatDecoratorFactory.GetDecoratedService(System.IServiceProvider,System.Type) 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\.GetDecoratedService\(System\.IServiceProvider, System\.Type\)') | Gets the decorated service, or `null` when the service isn't registered\. |
| [GetDecoratedService&lt;TService&gt;\(IServiceProvider\)](ICatDecoratorFactory.GetDecoratedService.md#Cat.Decorators.Abstractions.ICatDecoratorFactory.GetDecoratedService_TService_(System.IServiceProvider) 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\.GetDecoratedService\<TService\>\(System\.IServiceProvider\)') | Gets the decorated service, or `null` when the service isn't registered\. |

<a name='Cat.Decorators.Abstractions.ICatDecoratorFactory.GetDecoratedService(System.IServiceProvider,System.Type)'></a>

## ICatDecoratorFactory\.GetDecoratedService\(IServiceProvider, Type\) Method

Gets the decorated service, or `null` when the service isn't registered\.

```csharp
object? GetDecoratedService(System.IServiceProvider serviceProvider, System.Type serviceType);
```
#### Parameters

<a name='Cat.Decorators.Abstractions.ICatDecoratorFactory.GetDecoratedService(System.IServiceProvider,System.Type).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

Resolves the service and the dependencies of the decorators\.

<a name='Cat.Decorators.Abstractions.ICatDecoratorFactory.GetDecoratedService(System.IServiceProvider,System.Type).serviceType'></a>

`serviceType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The closed generic service type\.

#### Returns
[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')  
The service, wrapped in its decorators, or `null`\.

<a name='Cat.Decorators.Abstractions.ICatDecoratorFactory.GetDecoratedService_TService_(System.IServiceProvider)'></a>

## ICatDecoratorFactory\.GetDecoratedService\<TService\>\(IServiceProvider\) Method

Gets the decorated service, or `null` when the service isn't registered\.

```csharp
TService? GetDecoratedService<TService>(System.IServiceProvider serviceProvider);
```
#### Type parameters

<a name='Cat.Decorators.Abstractions.ICatDecoratorFactory.GetDecoratedService_TService_(System.IServiceProvider).TService'></a>

`TService`

The closed generic service type\.
#### Parameters

<a name='Cat.Decorators.Abstractions.ICatDecoratorFactory.GetDecoratedService_TService_(System.IServiceProvider).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

Resolves the service and the dependencies of the decorators\.

#### Returns
[TService](ICatDecoratorFactory.GetDecoratedService.md#Cat.Decorators.Abstractions.ICatDecoratorFactory.GetDecoratedService_TService_(System.IServiceProvider).TService 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\.GetDecoratedService\<TService\>\(System\.IServiceProvider\)\.TService')  
The service, wrapped in its decorators, or `null`\.