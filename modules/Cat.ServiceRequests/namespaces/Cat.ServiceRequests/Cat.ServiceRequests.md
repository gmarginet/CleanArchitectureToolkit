<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests](index.md 'index')

## Cat\.ServiceRequests Namespace

Provides the default [ICatServiceRequestProcessor](../Cat.ServiceRequests.Abstractions/ICatServiceRequestProcessor.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor')\.
It resolves the matching handler, wraps it in the registered decorators and runs it\.

| Classes | |
| :--- | :--- |
| [CatServiceRequestProcessor](CatServiceRequestProcessor.md 'Cat\.ServiceRequests\.CatServiceRequestProcessor') | Default [ICatServiceRequestProcessor](../Cat.ServiceRequests.Abstractions/ICatServiceRequestProcessor.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor')\. Opens a new scope per request, gets the decorated handler from it and invokes the handler\. |
