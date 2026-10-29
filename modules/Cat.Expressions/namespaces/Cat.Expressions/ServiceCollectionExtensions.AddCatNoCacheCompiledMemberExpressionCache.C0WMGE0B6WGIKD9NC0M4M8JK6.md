<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Expressions](index.md 'index') > [Cat\.Expressions\.Extensions](Cat.Expressions.Extensions.md 'Cat\.Expressions\.Extensions') > [ServiceCollectionExtensions](ServiceCollectionExtensions.md 'Cat\.Expressions\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatNoCacheCompiledMemberExpressionCache\(this IServiceCollection\) Method

Registers [ICatCompiledMemberExpressionCache&lt;T&gt;](..\Cat.Expressions.Abstractions\ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1') as a singleton, backed by the non\-caching implementation\.

```csharp
public static void AddCatNoCacheCompiledMemberExpressionCache(this Microsoft.Extensions.DependencyInjection.IServiceCollection services);
```
#### Parameters

<a name='Cat.Expressions.Extensions.ServiceCollectionExtensions.AddCatNoCacheCompiledMemberExpressionCache(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add the registration to\.