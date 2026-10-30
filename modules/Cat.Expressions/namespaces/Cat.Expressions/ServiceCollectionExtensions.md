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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.EXPRESSIONS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Expressions Assembly](index.md 'index') >> [Cat\.Expressions\.Extensions Namespace](Cat.Expressions.Extensions.md 'Cat\.Expressions\.Extensions')

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
