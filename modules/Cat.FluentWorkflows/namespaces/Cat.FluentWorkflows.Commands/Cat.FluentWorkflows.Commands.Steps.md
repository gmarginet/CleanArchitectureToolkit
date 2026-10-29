<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Commands](index.md 'index')

## Cat\.FluentWorkflows\.Commands\.Steps Namespace

| Classes | |
| :--- | :--- |
| [CatProcessCommandStep&lt;TCommand&gt;](CatProcessCommandStep_TCommand_.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>') | Built\-in step behind `ProcessCommand`\. It processes a command with the command processor\. A succeeded command continues the workflow\. A failed command ends it with BreakCascade and the errors\. |
