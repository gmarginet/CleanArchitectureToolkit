<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Commands\.Abstractions](index.md 'index')

## Cat\.Commands\.Abstractions Namespace

Defines the contracts for commands: the command marker, the handlers that run them,
and the processor that finds the right handler and returns an [ICatResponse](..\Cat.Responses.Abstractions\ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')\.

| Interfaces | |
| :--- | :--- |
| [ICatCommand](ICatCommand.md 'Cat\.Commands\.Abstractions\.ICatCommand') | Marks a command that changes state and returns a response without a payload\. Handle it with [ICatCommandHandler&lt;TCommand&gt;](ICatCommandHandler_TCommand_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\<TCommand\>')\. |
| [ICatCommandHandler&lt;TCommand&gt;](ICatCommandHandler_TCommand_.md 'Cat\.Commands\.Abstractions\.ICatCommandHandler\<TCommand\>') | Handles one kind of command\. Implement it once per command type\. The module finds and registers it for you\. |
| [ICatCommandProcessor](ICatCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor') | Single entry point for running commands\. It finds the handler for a command, runs it through the registered decorators and returns the response\. |
