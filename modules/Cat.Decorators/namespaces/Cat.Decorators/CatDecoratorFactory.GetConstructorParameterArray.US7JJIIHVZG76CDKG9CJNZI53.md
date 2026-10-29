<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Decorators](index.md 'index') > [Cat\.Decorators](Cat.Decorators.md 'Cat\.Decorators') > [CatDecoratorFactory](CatDecoratorFactory.md 'Cat\.Decorators\.CatDecoratorFactory')

## CatDecoratorFactory\.GetConstructorParameterArray\(IServiceProvider, object, Type, IDictionary\<string,object\>\) Method

Fills the constructor of a decorator\. For each parameter it picks, in this order:
a value registered by name, the service being wrapped, or a service from the provider\.

```csharp
private static object[] GetConstructorParameterArray(System.IServiceProvider serviceProvider, object service, System.Type decoratorType, System.Collections.Generic.IDictionary<string,object>? decoratorParameterDictionary);
```
#### Parameters

<a name='Cat.Decorators.CatDecoratorFactory.GetConstructorParameterArray(System.IServiceProvider,object,System.Type,System.Collections.Generic.IDictionary_string,object_).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

<a name='Cat.Decorators.CatDecoratorFactory.GetConstructorParameterArray(System.IServiceProvider,object,System.Type,System.Collections.Generic.IDictionary_string,object_).service'></a>

`service` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

<a name='Cat.Decorators.CatDecoratorFactory.GetConstructorParameterArray(System.IServiceProvider,object,System.Type,System.Collections.Generic.IDictionary_string,object_).decoratorType'></a>

`decoratorType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

<a name='Cat.Decorators.CatDecoratorFactory.GetConstructorParameterArray(System.IServiceProvider,object,System.Type,System.Collections.Generic.IDictionary_string,object_).decoratorParameterDictionary'></a>

`decoratorParameterDictionary` [System\.Collections\.Generic\.IDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')

#### Returns
[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')