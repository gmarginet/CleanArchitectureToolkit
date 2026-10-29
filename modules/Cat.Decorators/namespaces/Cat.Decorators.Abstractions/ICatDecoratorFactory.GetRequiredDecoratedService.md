<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Decorators\.Abstractions](index.md 'index') > [Cat\.Decorators\.Abstractions](Cat.Decorators.Abstractions.md 'Cat\.Decorators\.Abstractions') > [ICatDecoratorFactory](ICatDecoratorFactory.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory')

## ICatDecoratorFactory\.GetRequiredDecoratedService Method

| Overloads | |
| :--- | :--- |
| [GetRequiredDecoratedService\(IServiceProvider, Type\)](ICatDecoratorFactory.GetRequiredDecoratedService.md#Cat.Decorators.Abstractions.ICatDecoratorFactory.GetRequiredDecoratedService(System.IServiceProvider,System.Type) 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\.GetRequiredDecoratedService\(System\.IServiceProvider, System\.Type\)') | Gets the decorated service, or throws when the service isn't registered\. |
| [GetRequiredDecoratedService&lt;TService&gt;\(IServiceProvider\)](ICatDecoratorFactory.GetRequiredDecoratedService.md#Cat.Decorators.Abstractions.ICatDecoratorFactory.GetRequiredDecoratedService_TService_(System.IServiceProvider) 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\.GetRequiredDecoratedService\<TService\>\(System\.IServiceProvider\)') | Gets the decorated service, or throws when the service isn't registered\. |

<a name='Cat.Decorators.Abstractions.ICatDecoratorFactory.GetRequiredDecoratedService(System.IServiceProvider,System.Type)'></a>

## ICatDecoratorFactory\.GetRequiredDecoratedService\(IServiceProvider, Type\) Method

Gets the decorated service, or throws when the service isn't registered\.

```csharp
object GetRequiredDecoratedService(System.IServiceProvider serviceProvider, System.Type serviceType);
```
#### Parameters

<a name='Cat.Decorators.Abstractions.ICatDecoratorFactory.GetRequiredDecoratedService(System.IServiceProvider,System.Type).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

Resolves the service and the dependencies of the decorators\.

<a name='Cat.Decorators.Abstractions.ICatDecoratorFactory.GetRequiredDecoratedService(System.IServiceProvider,System.Type).serviceType'></a>

`serviceType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The closed generic service type\.

#### Returns
[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')  
The service, wrapped in its decorators\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
The service isn't registered\.

<a name='Cat.Decorators.Abstractions.ICatDecoratorFactory.GetRequiredDecoratedService_TService_(System.IServiceProvider)'></a>

## ICatDecoratorFactory\.GetRequiredDecoratedService\<TService\>\(IServiceProvider\) Method

Gets the decorated service, or throws when the service isn't registered\.

```csharp
TService GetRequiredDecoratedService<TService>(System.IServiceProvider serviceProvider);
```
#### Type parameters

<a name='Cat.Decorators.Abstractions.ICatDecoratorFactory.GetRequiredDecoratedService_TService_(System.IServiceProvider).TService'></a>

`TService`

The closed generic service type\.
#### Parameters

<a name='Cat.Decorators.Abstractions.ICatDecoratorFactory.GetRequiredDecoratedService_TService_(System.IServiceProvider).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

Resolves the service and the dependencies of the decorators\.

#### Returns
[TService](ICatDecoratorFactory.GetRequiredDecoratedService.md#Cat.Decorators.Abstractions.ICatDecoratorFactory.GetRequiredDecoratedService_TService_(System.IServiceProvider).TService 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\.GetRequiredDecoratedService\<TService\>\(System\.IServiceProvider\)\.TService')  
The service, wrapped in its decorators\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
The service isn't registered\.