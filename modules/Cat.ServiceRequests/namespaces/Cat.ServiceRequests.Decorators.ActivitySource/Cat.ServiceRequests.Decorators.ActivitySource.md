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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SERVICEREQUESTS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.ServiceRequests\.Decorators\.ActivitySource Assembly](index.md 'index')

## Cat\.ServiceRequests\.Decorators\.ActivitySource Namespace

Adds a decorator that starts a [System\.Diagnostics\.Activity](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.activity 'System\.Diagnostics\.Activity') around every service request handler,
so each request shows up in your distributed traces\.

| Classes | |
| :--- | :--- |
| [ActivitySourceDecorator](ActivitySourceDecorator.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator') | Wraps service request handlers in an [System\.Diagnostics\.Activity](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.activity 'System\.Diagnostics\.Activity') for tracing\. |
| [ActivitySourceDecorator\.CatServiceRequestHandler&lt;TRequest,TResponse&gt;](ActivitySourceDecorator.CatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>') | Traces a handler that returns a payload\. |
| [ActivitySourceDecorator\.CatServiceRequestHandler&lt;TRequest&gt;](ActivitySourceDecorator.CatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest\>') | Traces a handler that returns no payload\. |
| [ActivitySourceDecorator\.ServiceRequestActivitySource](ActivitySourceDecorator.ServiceRequestActivitySource.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.ServiceRequestActivitySource') | Owns the shared [System\.Diagnostics\.ActivitySource](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.activitysource 'System\.Diagnostics\.ActivitySource') named "Cat\.ServiceRequests"\. |
