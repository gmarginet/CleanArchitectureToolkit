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
  
##### >> [Cat\.Decorators Assembly](index.md 'index') >> [Cat\.Decorators Namespace](Cat.Decorators.md 'Cat\.Decorators')

## CatDecoratorFactory Class

Default [ICatDecoratorFactory](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorFactory.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory')\.
Gets the service from the service provider, then wraps it in each registered decorator in registration order\.

```csharp
public class CatDecoratorFactory : Cat.Decorators.Abstractions.ICatDecoratorFactory
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatDecoratorFactory

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
