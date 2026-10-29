<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Decorators](index.md 'index') > [Cat\.Decorators](Cat.Decorators.md 'Cat\.Decorators') > [CatDecoratorFactory](CatDecoratorFactory.md 'Cat\.Decorators\.CatDecoratorFactory')

## CatDecoratorFactory\.GetDecoratedService Method

| Overloads | |
| :--- | :--- |
| [GetDecoratedService\(IServiceProvider, Type\)](CatDecoratorFactory.GetDecoratedService.md#Cat.Decorators.CatDecoratorFactory.GetDecoratedService(System.IServiceProvider,System.Type) 'Cat\.Decorators\.CatDecoratorFactory\.GetDecoratedService\(System\.IServiceProvider, System\.Type\)') | Gets the decorated service, or `null` when the service isn't registered\. |
| [GetDecoratedService&lt;TService&gt;\(IServiceProvider\)](CatDecoratorFactory.GetDecoratedService.md#Cat.Decorators.CatDecoratorFactory.GetDecoratedService_TService_(System.IServiceProvider) 'Cat\.Decorators\.CatDecoratorFactory\.GetDecoratedService\<TService\>\(System\.IServiceProvider\)') | Gets the decorated service, or `null` when the service isn't registered\. |

<a name='Cat.Decorators.CatDecoratorFactory.GetDecoratedService(System.IServiceProvider,System.Type)'></a>

## CatDecoratorFactory\.GetDecoratedService\(IServiceProvider, Type\) Method

Gets the decorated service, or `null` when the service isn't registered\.

```csharp
public object? GetDecoratedService(System.IServiceProvider serviceProvider, System.Type serviceType);
```
#### Parameters

<a name='Cat.Decorators.CatDecoratorFactory.GetDecoratedService(System.IServiceProvider,System.Type).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

Resolves the service and the dependencies of the decorators\.

<a name='Cat.Decorators.CatDecoratorFactory.GetDecoratedService(System.IServiceProvider,System.Type).serviceType'></a>

`serviceType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The closed generic service type\.

Implements [GetDecoratedService\(IServiceProvider, Type\)](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorFactory.GetDecoratedService.md#Cat.Decorators.Abstractions.ICatDecoratorFactory.GetDecoratedService(System.IServiceProvider,System.Type) 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\.GetDecoratedService\(System\.IServiceProvider,System\.Type\)')

#### Returns
[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')  
The service, wrapped in its decorators, or `null`\.

<a name='Cat.Decorators.CatDecoratorFactory.GetDecoratedService_TService_(System.IServiceProvider)'></a>

## CatDecoratorFactory\.GetDecoratedService\<TService\>\(IServiceProvider\) Method

Gets the decorated service, or `null` when the service isn't registered\.

```csharp
public TService? GetDecoratedService<TService>(System.IServiceProvider serviceProvider);
```
#### Type parameters

<a name='Cat.Decorators.CatDecoratorFactory.GetDecoratedService_TService_(System.IServiceProvider).TService'></a>

`TService`

The closed generic service type\.
#### Parameters

<a name='Cat.Decorators.CatDecoratorFactory.GetDecoratedService_TService_(System.IServiceProvider).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

Resolves the service and the dependencies of the decorators\.

Implements [GetDecoratedService&lt;TService&gt;\(IServiceProvider\)](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorFactory.GetDecoratedService.md#Cat.Decorators.Abstractions.ICatDecoratorFactory.GetDecoratedService_TService_(System.IServiceProvider) 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\.GetDecoratedService\`\`1\(System\.IServiceProvider\)')

#### Returns
[TService](CatDecoratorFactory.md#Cat.Decorators.CatDecoratorFactory.GetDecoratedService_TService_(System.IServiceProvider).TService 'Cat\.Decorators\.CatDecoratorFactory\.GetDecoratedService\<TService\>\(System\.IServiceProvider\)\.TService')  
The service, wrapped in its decorators, or `null`\.