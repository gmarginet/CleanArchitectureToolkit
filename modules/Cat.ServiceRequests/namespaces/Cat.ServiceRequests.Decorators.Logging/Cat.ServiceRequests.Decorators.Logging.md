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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.SERVICEREQUESTS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.ServiceRequests\.Decorators\.Logging Assembly](index.md 'index')

## Cat\.ServiceRequests\.Decorators\.Logging Namespace

Adds a decorator that logs the start and end of every service request handler,
including the errors of a failed response\.

| Classes | |
| :--- | :--- |
| [LoggingDecorator](LoggingDecorator.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator') | Wraps service request handlers with debug logging and error logging\. |
| [LoggingDecorator\.CatServiceRequestHandler&lt;TRequest,TResponse&gt;](LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>') | Logs a handler that returns a payload\. |
| [LoggingDecorator\.CatServiceRequestHandler&lt;TRequest&gt;](LoggingDecorator.CatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest\>') | Logs a handler that returns no payload\. |
