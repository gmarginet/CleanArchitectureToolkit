<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.EventAggregators](index.md 'index')

## Cat\.EventAggregators Namespace

Provides the default in\-memory implementation of [ICatEventAggregator](..\Cat.EventAggregators.Abstractions\ICatEventAggregator.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator'),
along with the extension method to register it in a dependency injection container\.

| Classes | |
| :--- | :--- |
| [CatEventAggregator](CatEventAggregator.md 'Cat\.EventAggregators\.CatEventAggregator') | Default in\-memory implementation of [ICatEventAggregator](..\Cat.EventAggregators.Abstractions\ICatEventAggregator.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator')\. Tracks subscribers through weak references, so a subscriber doesn't need to unsubscribe to be garbage collected\. |
| [CatEventAggregator\.Subscription](CatEventAggregator.Subscription.md 'Cat\.EventAggregators\.CatEventAggregator\.Subscription') | Tracks one subscriber's live reference and the [ICatHandleEvent&lt;TEvent&gt;](..\Cat.EventAggregators.Abstractions\ICatHandleEvent_TEvent_.md 'Cat\.EventAggregators\.Abstractions\.ICatHandleEvent\`1') handler methods it implements\. |
