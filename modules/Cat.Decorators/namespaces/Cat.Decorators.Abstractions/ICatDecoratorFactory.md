<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Decorators\.Abstractions](index.md 'index') > [Cat\.Decorators\.Abstractions](Cat.Decorators.Abstractions.md 'Cat\.Decorators\.Abstractions')

## ICatDecoratorFactory Interface

Gets a service wrapped in the decorators registered for it\.
The service type must be a closed generic type, like `IHandler<MyRequest>`\.

```csharp
public interface ICatDecoratorFactory
```

| Methods | |
| :--- | :--- |
| [GetDecoratedService\(IServiceProvider, Type\)](ICatDecoratorFactory.GetDecoratedService.md#Cat.Decorators.Abstractions.ICatDecoratorFactory.GetDecoratedService(System.IServiceProvider,System.Type) 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\.GetDecoratedService\(System\.IServiceProvider, System\.Type\)') | Gets the decorated service, or `null` when the service isn't registered\. |
| [GetDecoratedService&lt;TService&gt;\(IServiceProvider\)](ICatDecoratorFactory.GetDecoratedService.md#Cat.Decorators.Abstractions.ICatDecoratorFactory.GetDecoratedService_TService_(System.IServiceProvider) 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\.GetDecoratedService\<TService\>\(System\.IServiceProvider\)') | Gets the decorated service, or `null` when the service isn't registered\. |
| [GetRequiredDecoratedService\(IServiceProvider, Type\)](ICatDecoratorFactory.GetRequiredDecoratedService.md#Cat.Decorators.Abstractions.ICatDecoratorFactory.GetRequiredDecoratedService(System.IServiceProvider,System.Type) 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\.GetRequiredDecoratedService\(System\.IServiceProvider, System\.Type\)') | Gets the decorated service, or throws when the service isn't registered\. |
| [GetRequiredDecoratedService&lt;TService&gt;\(IServiceProvider\)](ICatDecoratorFactory.GetRequiredDecoratedService.md#Cat.Decorators.Abstractions.ICatDecoratorFactory.GetRequiredDecoratedService_TService_(System.IServiceProvider) 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\.GetRequiredDecoratedService\<TService\>\(System\.IServiceProvider\)') | Gets the decorated service, or throws when the service isn't registered\. |
