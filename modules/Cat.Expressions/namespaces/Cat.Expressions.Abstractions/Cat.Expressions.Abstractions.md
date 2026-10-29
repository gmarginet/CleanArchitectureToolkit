<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Expressions\.Abstractions](index.md 'index')

## Cat\.Expressions\.Abstractions Namespace

Defines the contract for caching compiled member access delegates, without depending on any concrete implementation\.

| Interfaces | |
| :--- | :--- |
| [ICatCompiledMemberExpressionCache&lt;T&gt;](ICatCompiledMemberExpressionCache_T_.md 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\<T\>') | Caches compiled member access delegates for [T](ICatCompiledMemberExpressionCache_T_.md#Cat.Expressions.Abstractions.ICatCompiledMemberExpressionCache_T_.T 'Cat\.Expressions\.Abstractions\.ICatCompiledMemberExpressionCache\<T\>\.T'), so the same expression doesn't get recompiled on every call\. |
