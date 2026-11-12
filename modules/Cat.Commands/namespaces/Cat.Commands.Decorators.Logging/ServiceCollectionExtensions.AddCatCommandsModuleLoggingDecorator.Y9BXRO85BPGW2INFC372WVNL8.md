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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.COMMANDS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Commands\.Decorators\.Logging Assembly](index.md 'index') >> [Cat\.Commands\.Decorators\.Logging\.Extensions Namespace](Cat.Commands.Decorators.Logging.Extensions.md 'Cat\.Commands\.Decorators\.Logging\.Extensions') >> [ServiceCollectionExtensions Class](ServiceCollectionExtensions.md 'Cat\.Commands\.Decorators\.Logging\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatCommandsModuleLoggingDecorator\(this IServiceProvider, Nullable\<int\>\) Method

Adds the logging decorator to all command handlers, with or without a result\.

```csharp
public static void AddCatCommandsModuleLoggingDecorator(this System.IServiceProvider serviceProvider, System.Nullable<int> order=null);
```
#### Parameters

<a name='Cat.Commands.Decorators.Logging.Extensions.ServiceCollectionExtensions.AddCatCommandsModuleLoggingDecorator(thisSystem.IServiceProvider,System.Nullable_int_).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

Must be able to resolve [ICatDecoratorFactoryBuilder](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorFactoryBuilder.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder')\.

<a name='Cat.Commands.Decorators.Logging.Extensions.ServiceCollectionExtensions.AddCatCommandsModuleLoggingDecorator(thisSystem.IServiceProvider,System.Nullable_int_).order'></a>

`order` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

Where the decorator sits, from the outside in\. The default is [Logging](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/CatDecoratorOrder.Logging.md 'Cat\.Decorators\.Abstractions\.CatDecoratorOrder\.Logging')\.