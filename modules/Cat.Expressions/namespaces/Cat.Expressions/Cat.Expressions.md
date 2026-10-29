<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Expressions](index.md 'index')

## Cat\.Expressions Namespace

Provides caching and non\-caching implementations of [ICatCompiledMemberExpressionCache&lt;T&gt;](..\Cat.Expressions.Abstractions\ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1'),
along with the extension methods to register them in a dependency injection container\.

| Classes | |
| :--- | :--- |
| [CatCompiledMemberExpressionCache&lt;T&gt;](CatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.CatCompiledMemberExpressionCache\<T\>') | Caches compiled member expressions in a concurrent dictionary, keyed by member and expression text, so the same expression is compiled only once\. |
| [CatCompiledMemberExpressionKey](CatCompiledMemberExpressionKey.md 'Cat\.Expressions\.CatCompiledMemberExpressionKey') | Identifies a compiled member expression by its member and the expression's text, so it can be used as a cache key\. |
| [CatNoCacheCompiledMemberExpressionCache&lt;T&gt;](CatNoCacheCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.CatNoCacheCompiledMemberExpressionCache\<T\>') | Compiles a member expression into a delegate on every call, without caching the result\. Use this when caching isn't worth it, for example when expressions are built fresh each time anyway\. |
