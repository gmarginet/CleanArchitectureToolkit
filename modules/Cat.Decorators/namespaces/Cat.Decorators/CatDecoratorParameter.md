<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Decorators](index.md 'index') > [Cat\.Decorators](Cat.Decorators.md 'Cat\.Decorators')

## CatDecoratorParameter Class

Default [ICatDecoratorParameter](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorParameter.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorParameter')\.

```csharp
public record CatDecoratorParameter : Cat.Decorators.Abstractions.ICatDecoratorParameter, System.IEquatable<Cat.Decorators.CatDecoratorParameter>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatDecoratorParameter

Implements [ICatDecoratorParameter](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorParameter.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorParameter'), [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[CatDecoratorParameter](CatDecoratorParameter.md 'Cat\.Decorators\.CatDecoratorParameter')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [CatDecoratorParameter\(string, object\)](CatDecoratorParameter..ctor.GSF504BV2LLXS4FC3L5HUPYO1.md 'Cat\.Decorators\.CatDecoratorParameter\.CatDecoratorParameter\(string, object\)') | Creates the parameter\. |

| Properties | |
| :--- | :--- |
| [Name](CatDecoratorParameter.Name.md 'Cat\.Decorators\.CatDecoratorParameter\.Name') | The name of the constructor parameter\. |
| [Value](CatDecoratorParameter.Value.md 'Cat\.Decorators\.CatDecoratorParameter\.Value') | The value to pass\. Its type must fit the parameter type\. |
