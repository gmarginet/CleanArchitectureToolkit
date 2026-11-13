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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SCHEDULING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Scheduling Assembly](index.md 'index') >> [Cat\.Scheduling Namespace](Cat.Scheduling.md 'Cat\.Scheduling') >> [CatSchedulerBuilder Class](CatSchedulerBuilder.md 'Cat\.Scheduling\.CatSchedulerBuilder')

## CatSchedulerBuilder\.Job Method

| Overloads | |
| :--- | :--- |
| [Job\(string, string, Func&lt;ICatServiceRequest&gt;, Action&lt;CatJobOptions&gt;\)](CatSchedulerBuilder.Job.md#Cat.Scheduling.CatSchedulerBuilder.Job(string,string,System.Func_Cat.ServiceRequests.Abstractions.ICatServiceRequest_,System.Action_Cat.Scheduling.Abstractions.CatJobOptions_) 'Cat\.Scheduling\.CatSchedulerBuilder\.Job\(string, string, System\.Func\<Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\>, System\.Action\<Cat\.Scheduling\.Abstractions\.CatJobOptions\>\)') | Declares a job that sends a service request built by a factory, for a request with data\. |
| [Job&lt;TRequest&gt;\(string, string, Action&lt;CatJobOptions&gt;\)](CatSchedulerBuilder.Job.md#Cat.Scheduling.CatSchedulerBuilder.Job_TRequest_(string,string,System.Action_Cat.Scheduling.Abstractions.CatJobOptions_) 'Cat\.Scheduling\.CatSchedulerBuilder\.Job\<TRequest\>\(string, string, System\.Action\<Cat\.Scheduling\.Abstractions\.CatJobOptions\>\)') | Declares a job that sends a service request with a parameterless constructor, such as one without data\. |

<a name='Cat.Scheduling.CatSchedulerBuilder.Job(string,string,System.Func_Cat.ServiceRequests.Abstractions.ICatServiceRequest_,System.Action_Cat.Scheduling.Abstractions.CatJobOptions_)'></a>

## CatSchedulerBuilder\.Job\(string, string, Func\<ICatServiceRequest\>, Action\<CatJobOptions\>\) Method

Declares a job that sends a service request built by a factory, for a request with data\.

```csharp
public Cat.Scheduling.CatSchedulerBuilder Job(string name, string cron, System.Func<Cat.ServiceRequests.Abstractions.ICatServiceRequest> requestFactory, System.Action<Cat.Scheduling.Abstractions.CatJobOptions>? configure=null);
```
#### Parameters

<a name='Cat.Scheduling.CatSchedulerBuilder.Job(string,string,System.Func_Cat.ServiceRequests.Abstractions.ICatServiceRequest_,System.Action_Cat.Scheduling.Abstractions.CatJobOptions_).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the job\. It must be unique\. It is the key in the configuration and in the claim store\.

<a name='Cat.Scheduling.CatSchedulerBuilder.Job(string,string,System.Func_Cat.ServiceRequests.Abstractions.ICatServiceRequest_,System.Action_Cat.Scheduling.Abstractions.CatJobOptions_).cron'></a>

`cron` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The cron expression, see [Cron](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/CatJobOptions.Cron.md 'Cat\.Scheduling\.Abstractions\.CatJobOptions\.Cron')\.

<a name='Cat.Scheduling.CatSchedulerBuilder.Job(string,string,System.Func_Cat.ServiceRequests.Abstractions.ICatServiceRequest_,System.Action_Cat.Scheduling.Abstractions.CatJobOptions_).requestFactory'></a>

`requestFactory` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')[ICatServiceRequest](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequest.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-1 'System\.Func\`1')

Creates the service request\. It is called once for every run\.

<a name='Cat.Scheduling.CatSchedulerBuilder.Job(string,string,System.Func_Cat.ServiceRequests.Abstractions.ICatServiceRequest_,System.Action_Cat.Scheduling.Abstractions.CatJobOptions_).configure'></a>

`configure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[CatJobOptions](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/CatJobOptions.md 'Cat\.Scheduling\.Abstractions\.CatJobOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Changes the other settings of the job\.

#### Returns
[CatSchedulerBuilder](CatSchedulerBuilder.md 'Cat\.Scheduling\.CatSchedulerBuilder')  
The same builder, so calls can be chained\.

<a name='Cat.Scheduling.CatSchedulerBuilder.Job_TRequest_(string,string,System.Action_Cat.Scheduling.Abstractions.CatJobOptions_)'></a>

## CatSchedulerBuilder\.Job\<TRequest\>\(string, string, Action\<CatJobOptions\>\) Method

Declares a job that sends a service request with a parameterless constructor, such as one without data\.

```csharp
public Cat.Scheduling.CatSchedulerBuilder Job<TRequest>(string name, string cron, System.Action<Cat.Scheduling.Abstractions.CatJobOptions>? configure=null)
    where TRequest : Cat.ServiceRequests.Abstractions.ICatServiceRequest, new();
```
#### Type parameters

<a name='Cat.Scheduling.CatSchedulerBuilder.Job_TRequest_(string,string,System.Action_Cat.Scheduling.Abstractions.CatJobOptions_).TRequest'></a>

`TRequest`

The service request\. Every run creates a new one\.
#### Parameters

<a name='Cat.Scheduling.CatSchedulerBuilder.Job_TRequest_(string,string,System.Action_Cat.Scheduling.Abstractions.CatJobOptions_).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the job\. It must be unique\. It is the key in the configuration and in the claim store\.

<a name='Cat.Scheduling.CatSchedulerBuilder.Job_TRequest_(string,string,System.Action_Cat.Scheduling.Abstractions.CatJobOptions_).cron'></a>

`cron` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The cron expression, see [Cron](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/CatJobOptions.Cron.md 'Cat\.Scheduling\.Abstractions\.CatJobOptions\.Cron')\.

<a name='Cat.Scheduling.CatSchedulerBuilder.Job_TRequest_(string,string,System.Action_Cat.Scheduling.Abstractions.CatJobOptions_).configure'></a>

`configure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[CatJobOptions](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/CatJobOptions.md 'Cat\.Scheduling\.Abstractions\.CatJobOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Changes the other settings of the job\.

#### Returns
[CatSchedulerBuilder](CatSchedulerBuilder.md 'Cat\.Scheduling\.CatSchedulerBuilder')  
The same builder, so calls can be chained\.