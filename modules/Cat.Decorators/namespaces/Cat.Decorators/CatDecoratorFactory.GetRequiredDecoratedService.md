<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Decorators](index.md 'index') > [Cat\.Decorators](Cat.Decorators.md 'Cat\.Decorators') > [CatDecoratorFactory](CatDecoratorFactory.md 'Cat\.Decorators\.CatDecoratorFactory')

## CatDecoratorFactory\.GetRequiredDecoratedService Method

| Overloads | |
| :--- | :--- |
| [GetRequiredDecoratedService\(IServiceProvider, Type\)](CatDecoratorFactory.GetRequiredDecoratedService.md#Cat.Decorators.CatDecoratorFactory.GetRequiredDecoratedService(System.IServiceProvider,System.Type) 'Cat\.Decorators\.CatDecoratorFactory\.GetRequiredDecoratedService\(System\.IServiceProvider, System\.Type\)') | Gets the decorated service, or throws when the service isn't registered\. |
| [GetRequiredDecoratedService&lt;TService&gt;\(IServiceProvider\)](CatDecoratorFactory.GetRequiredDecoratedService.md#Cat.Decorators.CatDecoratorFactory.GetRequiredDecoratedService_TService_(System.IServiceProvider) 'Cat\.Decorators\.CatDecoratorFactory\.GetRequiredDecoratedService\<TService\>\(System\.IServiceProvider\)') | Gets the decorated service, or throws when the service isn't registered\. |

<a name='Cat.Decorators.CatDecoratorFactory.GetRequiredDecoratedService(System.IServiceProvider,System.Type)'></a>

## CatDecoratorFactory\.GetRequiredDecoratedService\(IServiceProvider, Type\) Method

Gets the decorated service, or throws when the service isn't registered\.

```csharp
public object GetRequiredDecoratedService(System.IServiceProvider serviceProvider, System.Type serviceType);
```
#### Parameters

<a name='Cat.Decorators.CatDecoratorFactory.GetRequiredDecoratedService(System.IServiceProvider,System.Type).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

Resolves the service and the dependencies of the decorators\.

<a name='Cat.Decorators.CatDecoratorFactory.GetRequiredDecoratedService(System.IServiceProvider,System.Type).serviceType'></a>

`serviceType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The closed generic service type\.

Implements [GetRequiredDecoratedService\(IServiceProvider, Type\)](../Cat.Decorators.Abstractions/ICatDecoratorFactory.GetRequiredDecoratedService.md#Cat.Decorators.Abstractions.ICatDecoratorFactory.GetRequiredDecoratedService(System.IServiceProvider,System.Type) 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\.GetRequiredDecoratedService\(System\.IServiceProvider,System\.Type\)')

#### Returns
[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')  
The service, wrapped in its decorators\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
The service isn't registered\.

<a name='Cat.Decorators.CatDecoratorFactory.GetRequiredDecoratedService_TService_(System.IServiceProvider)'></a>

## CatDecoratorFactory\.GetRequiredDecoratedService\<TService\>\(IServiceProvider\) Method

Gets the decorated service, or throws when the service isn't registered\.

```csharp
public TService GetRequiredDecoratedService<TService>(System.IServiceProvider serviceProvider);
```
#### Type parameters

<a name='Cat.Decorators.CatDecoratorFactory.GetRequiredDecoratedService_TService_(System.IServiceProvider).TService'></a>

`TService`

The closed generic service type\.
#### Parameters

<a name='Cat.Decorators.CatDecoratorFactory.GetRequiredDecoratedService_TService_(System.IServiceProvider).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

Resolves the service and the dependencies of the decorators\.

Implements [GetRequiredDecoratedService&lt;TService&gt;\(IServiceProvider\)](../Cat.Decorators.Abstractions/ICatDecoratorFactory.GetRequiredDecoratedService.md#Cat.Decorators.Abstractions.ICatDecoratorFactory.GetRequiredDecoratedService_TService_(System.IServiceProvider) 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\.GetRequiredDecoratedService\`\`1\(System\.IServiceProvider\)')

#### Returns
[TService](CatDecoratorFactory.md#Cat.Decorators.CatDecoratorFactory.GetRequiredDecoratedService_TService_(System.IServiceProvider).TService 'Cat\.Decorators\.CatDecoratorFactory\.GetRequiredDecoratedService\<TService\>\(System\.IServiceProvider\)\.TService')  
The service, wrapped in its decorators\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
The service isn't registered\.