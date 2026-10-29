<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Decorators](index.md 'index') > [Cat\.Decorators](Cat.Decorators.md 'Cat\.Decorators') > [CatDecoratorInfo](CatDecoratorInfo.md 'Cat\.Decorators\.CatDecoratorInfo')

## CatDecoratorInfo\(Type, IDictionary\<string,object\>\) Constructor

Creates the description\.

```csharp
public CatDecoratorInfo(System.Type decoratorGenericTypeDefinition, System.Collections.Generic.IDictionary<string,object>? decoratorParameterDictionary);
```
#### Parameters

<a name='Cat.Decorators.CatDecoratorInfo.CatDecoratorInfo(System.Type,System.Collections.Generic.IDictionary_string,object_).decoratorGenericTypeDefinition'></a>

`decoratorGenericTypeDefinition` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The open generic decorator type\.

<a name='Cat.Decorators.CatDecoratorInfo.CatDecoratorInfo(System.Type,System.Collections.Generic.IDictionary_string,object_).decoratorParameterDictionary'></a>

`decoratorParameterDictionary` [System\.Collections\.Generic\.IDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')

Constructor values by parameter name, or `null` for none\.