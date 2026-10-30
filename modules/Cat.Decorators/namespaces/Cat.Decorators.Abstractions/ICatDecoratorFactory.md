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
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.DECORATORS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Decorators\.Abstractions Assembly](index.md 'index') >> [Cat\.Decorators\.Abstractions Namespace](Cat.Decorators.Abstractions.md 'Cat\.Decorators\.Abstractions')

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
