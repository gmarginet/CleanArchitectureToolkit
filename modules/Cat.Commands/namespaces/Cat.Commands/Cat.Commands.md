<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Commands](index.md 'index')

## Cat\.Commands Namespace

Provides the default [ICatCommandProcessor](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor')\.
It resolves the matching handler, wraps it in the registered decorators and runs it\.

| Classes | |
| :--- | :--- |
| [CatCommandProcessor](CatCommandProcessor.md 'Cat\.Commands\.CatCommandProcessor') | Default [ICatCommandProcessor](../../../Cat.Commands/namespaces/Cat.Commands.Abstractions/ICatCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor')\. Opens a new scope per command, gets the decorated handler from it and invokes the handler\. |
