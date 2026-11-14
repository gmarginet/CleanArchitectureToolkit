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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SAGAS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Sagas Assembly](index.md 'index') >> [Cat\.Sagas\.Extensions Namespace](Cat.Sagas.Extensions.md 'Cat\.Sagas\.Extensions') >> [CatWorkflowBuilderExtensions Class](CatWorkflowBuilderExtensions.md 'Cat\.Sagas\.Extensions\.CatWorkflowBuilderExtensions')

## CatWorkflowBuilderExtensions\.SendAndWait\<TWorkflowState,TRequest,TAnswer\>\(this ICatWorkflowBuilder\<TWorkflowState\>, string\) Method

Adds a step that sends a request message and waits for the answer\. The workflow stops here and its state is saved\.
When the answer arrives, the workflow goes on with the step after this one\.
The request is created with its parameterless constructor\. Fill it with `Input`, like `.Input(s => s.OrderId, step => step.Request.OrderId)`\.
Read the answer with `Output`, like `.Output(step => step.Answer, s => s.Payment)`\.
The saga puts its instance id in the `CorrelationId` of the request\. The other service must copy it into its answer\.

```csharp
public static Cat.FluentWorkflows.Abstractions.ICatStepBuilder<TWorkflowState,Cat.Sagas.Steps.CatSendAndWaitStep<TRequest,TAnswer>> SendAndWait<TWorkflowState,TRequest,TAnswer>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder, string name)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
    where TRequest : class, Cat.Messaging.Abstractions.ICatMessage
    where TAnswer : class;
```
#### Type parameters

<a name='Cat.Sagas.Extensions.CatWorkflowBuilderExtensions.SendAndWait_TWorkflowState,TRequest,TAnswer_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,string).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

<a name='Cat.Sagas.Extensions.CatWorkflowBuilderExtensions.SendAndWait_TWorkflowState,TRequest,TAnswer_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,string).TRequest'></a>

`TRequest`

The request message to send\.

<a name='Cat.Sagas.Extensions.CatWorkflowBuilderExtensions.SendAndWait_TWorkflowState,TRequest,TAnswer_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,string).TAnswer'></a>

`TAnswer`

The answer to wait for\.
#### Parameters

<a name='Cat.Sagas.Extensions.CatWorkflowBuilderExtensions.SendAndWait_TWorkflowState,TRequest,TAnswer_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,string).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.SendAndWait.70SQYR5IK1WM1NZHTE2SIH313.md#Cat.Sagas.Extensions.CatWorkflowBuilderExtensions.SendAndWait_TWorkflowState,TRequest,TAnswer_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,string).TWorkflowState 'Cat\.Sagas\.Extensions\.CatWorkflowBuilderExtensions\.SendAndWait\<TWorkflowState,TRequest,TAnswer\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, string\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

<a name='Cat.Sagas.Extensions.CatWorkflowBuilderExtensions.SendAndWait_TWorkflowState,TRequest,TAnswer_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the step\. A step that waits needs a name that does not change, because the saved position points at it\.

#### Returns
[Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[TWorkflowState](CatWorkflowBuilderExtensions.SendAndWait.70SQYR5IK1WM1NZHTE2SIH313.md#Cat.Sagas.Extensions.CatWorkflowBuilderExtensions.SendAndWait_TWorkflowState,TRequest,TAnswer_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,string).TWorkflowState 'Cat\.Sagas\.Extensions\.CatWorkflowBuilderExtensions\.SendAndWait\<TWorkflowState,TRequest,TAnswer\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, string\)\.TWorkflowState')[,](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[Cat\.Sagas\.Steps\.CatSendAndWaitStep&lt;](CatSendAndWaitStep_TRequest,TAnswer_.md 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>')[TRequest](CatWorkflowBuilderExtensions.SendAndWait.70SQYR5IK1WM1NZHTE2SIH313.md#Cat.Sagas.Extensions.CatWorkflowBuilderExtensions.SendAndWait_TWorkflowState,TRequest,TAnswer_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,string).TRequest 'Cat\.Sagas\.Extensions\.CatWorkflowBuilderExtensions\.SendAndWait\<TWorkflowState,TRequest,TAnswer\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, string\)\.TRequest')[,](CatSendAndWaitStep_TRequest,TAnswer_.md 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>')[TAnswer](CatWorkflowBuilderExtensions.SendAndWait.70SQYR5IK1WM1NZHTE2SIH313.md#Cat.Sagas.Extensions.CatWorkflowBuilderExtensions.SendAndWait_TWorkflowState,TRequest,TAnswer_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,string).TAnswer 'Cat\.Sagas\.Extensions\.CatWorkflowBuilderExtensions\.SendAndWait\<TWorkflowState,TRequest,TAnswer\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, string\)\.TAnswer')[&gt;](CatSendAndWaitStep_TRequest,TAnswer_.md 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')  
A builder to connect the step to the state with `Input` and `Output`\.