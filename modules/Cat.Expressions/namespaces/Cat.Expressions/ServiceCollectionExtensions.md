<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Expressions](index.md 'index') > [Cat\.Expressions\.Extensions](Cat.Expressions.Extensions.md 'Cat\.Expressions\.Extensions')

## ServiceCollectionExtensions Class

Registers the Cat Expressions module's compiled member expression cache in the dependency injection container\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatCompiledMemberExpressionCache\(this IServiceCollection\)](ServiceCollectionExtensions.AddCatCompiledMemberExpressionCache.GYBU1MOV5DI835Y09JUFS3EFB.md 'Cat\.Expressions\.Extensions\.ServiceCollectionExtensions\.AddCatCompiledMemberExpressionCache\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)') | Registers [ICatCompiledMemberExpressionCache&lt;T&gt;](../../../Cat.Expressions/namespaces/Cat.Expressions.Abstractions/ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1') as a singleton, backed by the caching implementation\. |
| [AddCatNoCacheCompiledMemberExpressionCache\(this IServiceCollection\)](ServiceCollectionExtensions.AddCatNoCacheCompiledMemberExpressionCache.C0WMGE0B6WGIKD9NC0M4M8JK6.md 'Cat\.Expressions\.Extensions\.ServiceCollectionExtensions\.AddCatNoCacheCompiledMemberExpressionCache\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)') | Registers [ICatCompiledMemberExpressionCache&lt;T&gt;](../../../Cat.Expressions/namespaces/Cat.Expressions.Abstractions/ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1') as a singleton, backed by the non\-caching implementation\. |
