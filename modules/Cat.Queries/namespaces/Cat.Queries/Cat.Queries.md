<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Queries](index.md 'index')

## Cat\.Queries Namespace

Provides the default [ICatQueryProcessor](..\Cat.Queries.Abstractions\ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor')\.
It resolves the matching handler, wraps it in the registered decorators and runs it\.

| Classes | |
| :--- | :--- |
| [CatQueryProcessor](CatQueryProcessor.md 'Cat\.Queries\.CatQueryProcessor') | Default [ICatQueryProcessor](..\Cat.Queries.Abstractions\ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor')\. Opens a new scope per query, gets the decorated handler from it and invokes the handler\. |
