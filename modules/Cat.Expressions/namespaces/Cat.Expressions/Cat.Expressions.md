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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.EXPRESSIONS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Expressions Assembly](index.md 'index')

## Cat\.Expressions Namespace

Provides caching and non\-caching implementations of [ICatCompiledMemberExpressionCache&lt;T&gt;](../../../Cat.Expressions/namespaces/Cat.Expressions.Abstractions/ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\`1'),
along with the extension methods to register them in a dependency injection container\.

| Classes | |
| :--- | :--- |
| [CatCompiledMemberExpressionCache&lt;T&gt;](CatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.CatCompiledMemberExpressionCache\<T\>') | Caches compiled member expressions in a concurrent dictionary, keyed by member and expression text, so the same expression is compiled only once\. |
| [CatCompiledMemberExpressionKey](CatCompiledMemberExpressionKey.md 'Cat\.Expressions\.CatCompiledMemberExpressionKey') | Identifies a compiled member expression by its member and the expression's text, so it can be used as a cache key\. |
| [CatNoCacheCompiledMemberExpressionCache&lt;T&gt;](CatNoCacheCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.CatNoCacheCompiledMemberExpressionCache\<T\>') | Compiles a member expression into a delegate on every call, without caching the result\. Use this when caching isn't worth it, for example when expressions are built fresh each time anyway\. |
