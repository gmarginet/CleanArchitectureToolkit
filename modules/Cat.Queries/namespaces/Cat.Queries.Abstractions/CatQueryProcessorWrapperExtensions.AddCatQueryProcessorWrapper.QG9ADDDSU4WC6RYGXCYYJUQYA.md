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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.QUERIES](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Queries\.Abstractions Assembly](index.md 'index') >> [Cat\.Queries\.Abstractions Namespace](Cat.Queries.Abstractions.md 'Cat\.Queries\.Abstractions') >> [CatQueryProcessorWrapperExtensions Class](CatQueryProcessorWrapperExtensions.md 'Cat\.Queries\.Abstractions\.CatQueryProcessorWrapperExtensions')

## CatQueryProcessorWrapperExtensions\.AddCatQueryProcessorWrapper\(this IServiceCollection, int, Func\<IServiceProvider,ICatQueryProcessor,ICatQueryProcessor\>, string\) Method

Wraps the registered [ICatQueryProcessor](ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor')\.
The first call replaces the registration of the processor with one that builds the processor and all the wrappers\.
Later calls add their wrapper to the same registration\.
A wrapper with a lower order is further out\. Wrappers with the same order are kept in the order of the calls, and the last one is outside\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddCatQueryProcessorWrapper(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, int order, System.Func<System.IServiceProvider,Cat.Queries.Abstractions.ICatQueryProcessor,Cat.Queries.Abstractions.ICatQueryProcessor> wrap, string callName);
```
#### Parameters

<a name='Cat.Queries.Abstractions.CatQueryProcessorWrapperExtensions.AddCatQueryProcessorWrapper(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,int,System.Func_System.IServiceProvider,Cat.Queries.Abstractions.ICatQueryProcessor,Cat.Queries.Abstractions.ICatQueryProcessor_,string).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to change\.

<a name='Cat.Queries.Abstractions.CatQueryProcessorWrapperExtensions.AddCatQueryProcessorWrapper(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,int,System.Func_System.IServiceProvider,Cat.Queries.Abstractions.ICatQueryProcessor,Cat.Queries.Abstractions.ICatQueryProcessor_,string).order'></a>

`order` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The place of the wrapper, from the outside in\. Use a number of [CatQueryProcessorOrder](CatQueryProcessorOrder.md 'Cat\.Queries\.Abstractions\.CatQueryProcessorOrder')\.

<a name='Cat.Queries.Abstractions.CatQueryProcessorWrapperExtensions.AddCatQueryProcessorWrapper(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,int,System.Func_System.IServiceProvider,Cat.Queries.Abstractions.ICatQueryProcessor,Cat.Queries.Abstractions.ICatQueryProcessor_,string).wrap'></a>

`wrap` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[ICatQueryProcessor](ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[ICatQueryProcessor](ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')

Creates the wrapper\. It gets the service provider of the scope and the processor it must wrap\.

<a name='Cat.Queries.Abstractions.CatQueryProcessorWrapperExtensions.AddCatQueryProcessorWrapper(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,int,System.Func_System.IServiceProvider,Cat.Queries.Abstractions.ICatQueryProcessor,Cat.Queries.Abstractions.ICatQueryProcessor_,string).callName'></a>

`callName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the registration call, such as `AddCatQueryRetry`\. It is used in the message of the exception\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')  
The same service collection, for chaining\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
No [ICatQueryProcessor](ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor') is registered yet\.