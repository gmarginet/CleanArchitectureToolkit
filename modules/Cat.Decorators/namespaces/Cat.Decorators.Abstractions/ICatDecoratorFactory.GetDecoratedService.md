<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Decorators\.Abstractions](index.md 'index') > [Cat\.Decorators\.Abstractions](Cat.Decorators.Abstractions.md 'Cat\.Decorators\.Abstractions') > [ICatDecoratorFactory](ICatDecoratorFactory.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory')

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
[TService](ICatDecoratorFactory.md#Cat.Decorators.Abstractions.ICatDecoratorFactory.GetDecoratedService_TService_(System.IServiceProvider).TService 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\.GetDecoratedService\<TService\>\(System\.IServiceProvider\)\.TService')  
The service, wrapped in its decorators, or `null`\.