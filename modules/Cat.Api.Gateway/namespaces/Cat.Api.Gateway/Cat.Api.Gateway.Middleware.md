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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.API.GATEWAY](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Api\.Gateway Assembly](index.md 'index')

## Cat\.Api\.Gateway\.Middleware Namespace

| Classes | |
| :--- | :--- |
| [CorrelationIdMiddleware](CorrelationIdMiddleware.md 'Cat\.Api\.Gateway\.Middleware\.CorrelationIdMiddleware') | Gives every request a correlation id and passes it on to the service and back to the caller\. |
| [RequestLimitsMiddleware](RequestLimitsMiddleware.md 'Cat\.Api\.Gateway\.Middleware\.RequestLimitsMiddleware') | Rejects a request body that is larger than [MaxRequestBodySize](CatGatewayLimitsOptions.MaxRequestBodySize.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayLimitsOptions\.MaxRequestBodySize')\. |
| [RequestLoggingMiddleware](RequestLoggingMiddleware.md 'Cat\.Api\.Gateway\.Middleware\.RequestLoggingMiddleware') | Logs one line for every request: the method, the path, the status, the time and the service\. |
