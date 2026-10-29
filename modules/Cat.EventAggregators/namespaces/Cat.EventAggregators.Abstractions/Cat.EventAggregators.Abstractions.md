<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.EventAggregators\.Abstractions](index.md 'index')

## Cat\.EventAggregators\.Abstractions Namespace

Defines the contracts for publishing events and handling them, without depending on any concrete implementation\.

| Interfaces | |
| :--- | :--- |
| [ICatEventAggregator](ICatEventAggregator.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator') | Publishes events to subscribers that implement [ICatHandleEvent&lt;TEvent&gt;](ICatHandleEvent_TEvent_.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\<TEvent\>') for the event's type\. |
| [ICatHandleEvent&lt;TEvent&gt;](ICatHandleEvent_TEvent_.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\<TEvent\>') | Implemented by a subscriber to receive events of type [TEvent](ICatHandleEvent_TEvent_.md#Cat.EventAggregators.Abstractions.ICatHandleEvent_TEvent_.TEvent 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\<TEvent\>\.TEvent') from an [ICatEventAggregator](ICatEventAggregator.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator')\. |
