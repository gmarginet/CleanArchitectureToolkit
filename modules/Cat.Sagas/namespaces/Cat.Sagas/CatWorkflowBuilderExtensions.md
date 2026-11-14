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
  
##### >> [Cat\.Sagas Assembly](index.md 'index') >> [Cat\.Sagas\.Extensions Namespace](Cat.Sagas.Extensions.md 'Cat\.Sagas\.Extensions')

## CatWorkflowBuilderExtensions Class

The wait step for the workflow builder\.

```csharp
public static class CatWorkflowBuilderExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatWorkflowBuilderExtensions

| Methods | |
| :--- | :--- |
| [SendAndWait&lt;TWorkflowState,TRequest,TAnswer&gt;\(this ICatWorkflowBuilder&lt;TWorkflowState&gt;, string, Nullable&lt;TimeSpan&gt;\)](CatWorkflowBuilderExtensions.SendAndWait.9P7QYONTIGEMA5XK377GWFGT1.md 'Cat\.Sagas\.Extensions\.CatWorkflowBuilderExtensions\.SendAndWait\<TWorkflowState,TRequest,TAnswer\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, string, System\.Nullable\<System\.TimeSpan\>\)') | Adds a step that sends a request message and waits for the answer\. The workflow stops here and its state is saved\. When the answer arrives, the workflow goes on with the step after this one\. The request is created with its parameterless constructor\. Fill it with `Input`, like `.Input(s => s.OrderId, step => step.Request.OrderId)`\. Read the answer with `Output`, like `.Output(step => step.Answer, s => s.Payment)`\. The saga puts its instance id in the `CorrelationId` of the request\. The other service must copy it into its answer\. |
