<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Decorators](index.md 'index') > [Cat\.Decorators](Cat.Decorators.md 'Cat\.Decorators')

## CatDecoratorInfo Class

Describes one registered decorator: its open generic type and the constructor values to pass to it\.

```csharp
public record CatDecoratorInfo : System.IEquatable<Cat.Decorators.CatDecoratorInfo>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatDecoratorInfo

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[CatDecoratorInfo](CatDecoratorInfo.md 'Cat\.Decorators\.CatDecoratorInfo')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [CatDecoratorInfo\(Type, IDictionary&lt;string,object&gt;\)](CatDecoratorInfo..ctor.7N6RUQYPU2QAFERC8RWFG9II1.md 'Cat\.Decorators\.CatDecoratorInfo\.CatDecoratorInfo\(System\.Type, System\.Collections\.Generic\.IDictionary\<string,object\>\)') | Creates the description\. |

| Properties | |
| :--- | :--- |
| [DecoratorGenericTypeDefinition](CatDecoratorInfo.DecoratorGenericTypeDefinition.md 'Cat\.Decorators\.CatDecoratorInfo\.DecoratorGenericTypeDefinition') | The open generic decorator type\. |
| [DecoratorParameterDictionary](CatDecoratorInfo.DecoratorParameterDictionary.md 'Cat\.Decorators\.CatDecoratorInfo\.DecoratorParameterDictionary') | Constructor values by parameter name, or `null` for none\. |
