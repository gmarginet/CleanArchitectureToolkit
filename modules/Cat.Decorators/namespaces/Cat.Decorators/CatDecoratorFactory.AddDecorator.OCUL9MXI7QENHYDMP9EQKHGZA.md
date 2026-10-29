<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Decorators](index.md 'index') > [Cat\.Decorators](Cat.Decorators.md 'Cat\.Decorators') > [CatDecoratorFactory](CatDecoratorFactory.md 'Cat\.Decorators\.CatDecoratorFactory')

## CatDecoratorFactory\.AddDecorator\(Type, Type, Dictionary\<string,object\>\) Method

Adds a decorator for a service\. The first decorator you add is the innermost one\.

```csharp
public void AddDecorator(System.Type serviceType, System.Type decoratorType, System.Collections.Generic.Dictionary<string,object>? decoratorParameterDictionary);
```
#### Parameters

<a name='Cat.Decorators.CatDecoratorFactory.AddDecorator(System.Type,System.Type,System.Collections.Generic.Dictionary_string,object_).serviceType'></a>

`serviceType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The open generic service type\.

<a name='Cat.Decorators.CatDecoratorFactory.AddDecorator(System.Type,System.Type,System.Collections.Generic.Dictionary_string,object_).decoratorType'></a>

`decoratorType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The open generic decorator type\. It needs exactly one public constructor\.

<a name='Cat.Decorators.CatDecoratorFactory.AddDecorator(System.Type,System.Type,System.Collections.Generic.Dictionary_string,object_).decoratorParameterDictionary'></a>

`decoratorParameterDictionary` [System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

Constructor values by parameter name, or `null` for none\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
The service type or the decorator type isn't an open generic type\.