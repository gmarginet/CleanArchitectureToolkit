<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Queries](index.md 'index')

## Cat\.FluentWorkflows\.Queries\.Steps Namespace

| Classes | |
| :--- | :--- |
| [CatProcessQueryStep&lt;TQuery,TResult&gt;](CatProcessQueryStep_TQuery,TResult_.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>') | Built\-in step behind `ProcessQuery`\. It processes a query with the query processor\. A succeeded query continues the workflow\. A failed query ends it with BreakCascade and the errors\. |
