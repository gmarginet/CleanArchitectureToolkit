<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Decorators](index.md 'index') > [Cat\.Decorators](Cat.Decorators.md 'Cat\.Decorators')

## CatDecoratorFactory Class

Default [ICatDecoratorFactory](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorFactory.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory')\.
Gets the service from the service provider, then wraps it in each registered decorator in registration order\.

```csharp
public class CatDecoratorFactory : Cat.Decorators.Abstractions.ICatDecoratorFactory
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatDecoratorFactory

Implements [ICatDecoratorFactory](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorFactory.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory')

| Fields | |
| :--- | :--- |
| [\_serviceTypes](CatDecoratorFactory._serviceTypes.md 'Cat\.Decorators\.CatDecoratorFactory\.\_serviceTypes') | |

| Methods | |
| :--- | :--- |
| [AddDecorator\(Type, Type, Dictionary&lt;string,object&gt;\)](CatDecoratorFactory.AddDecorator.OCUL9MXI7QENHYDMP9EQKHGZA.md 'Cat\.Decorators\.CatDecoratorFactory\.AddDecorator\(System\.Type, System\.Type, System\.Collections\.Generic\.Dictionary\<string,object\>\)') | Adds a decorator for a service\. The first decorator you add is the innermost one\. |
| [GetConstructorParameterArray\(IServiceProvider, object, Type, IDictionary&lt;string,object&gt;\)](CatDecoratorFactory.GetConstructorParameterArray.US7JJIIHVZG76CDKG9CJNZI53.md 'Cat\.Decorators\.CatDecoratorFactory\.GetConstructorParameterArray\(System\.IServiceProvider, object, System\.Type, System\.Collections\.Generic\.IDictionary\<string,object\>\)') | Fills the constructor of a decorator\. For each parameter it picks, in this order: a value registered by name, the service being wrapped, or a service from the provider\. |
| [GetDecoratedService\(IServiceProvider, Type\)](CatDecoratorFactory.GetDecoratedService.md#Cat.Decorators.CatDecoratorFactory.GetDecoratedService(System.IServiceProvider,System.Type) 'Cat\.Decorators\.CatDecoratorFactory\.GetDecoratedService\(System\.IServiceProvider, System\.Type\)') | Gets the decorated service, or `null` when the service isn't registered\. |
| [GetDecoratedService&lt;TService&gt;\(IServiceProvider\)](CatDecoratorFactory.GetDecoratedService.md#Cat.Decorators.CatDecoratorFactory.GetDecoratedService_TService_(System.IServiceProvider) 'Cat\.Decorators\.CatDecoratorFactory\.GetDecoratedService\<TService\>\(System\.IServiceProvider\)') | Gets the decorated service, or `null` when the service isn't registered\. |
| [GetRequiredDecoratedService\(IServiceProvider, Type\)](CatDecoratorFactory.GetRequiredDecoratedService.md#Cat.Decorators.CatDecoratorFactory.GetRequiredDecoratedService(System.IServiceProvider,System.Type) 'Cat\.Decorators\.CatDecoratorFactory\.GetRequiredDecoratedService\(System\.IServiceProvider, System\.Type\)') | Gets the decorated service, or throws when the service isn't registered\. |
| [GetRequiredDecoratedService&lt;TService&gt;\(IServiceProvider\)](CatDecoratorFactory.GetRequiredDecoratedService.md#Cat.Decorators.CatDecoratorFactory.GetRequiredDecoratedService_TService_(System.IServiceProvider) 'Cat\.Decorators\.CatDecoratorFactory\.GetRequiredDecoratedService\<TService\>\(System\.IServiceProvider\)') | Gets the decorated service, or throws when the service isn't registered\. |
