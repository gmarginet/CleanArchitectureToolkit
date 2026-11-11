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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EVENTPROCESSOR](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EventProcessor\.Minimal\.Api Assembly](index.md 'index') >> [Cat\.EventProcessor\.Minimal\.Api\.Extensions Namespace](Cat.EventProcessor.Minimal.Api.Extensions.md 'Cat\.EventProcessor\.Minimal\.Api\.Extensions') >> [EndpointRouteBuilderExtensions Class](EndpointRouteBuilderExtensions.md 'Cat\.EventProcessor\.Minimal\.Api\.Extensions\.EndpointRouteBuilderExtensions')

## EndpointRouteBuilderExtensions\.MapCatEventProcessor\(this IEndpointRouteBuilder\) Method

Maps `GET /dev/event-processor`, which lists the declared message types, and `POST /dev/event-processor/{messageType}`,
which takes the JSON of a message and runs it through the same pipeline as a real message\.
The endpoints exist only in the Development environment\. In any other environment nothing is mapped\.
The result says what the broker would do with the message, but nothing is settled, because there is no real message\.

```csharp
public static Microsoft.AspNetCore.Routing.RouteGroupBuilder? MapCatEventProcessor(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder endpoints);
```
#### Parameters

<a name='Cat.EventProcessor.Minimal.Api.Extensions.EndpointRouteBuilderExtensions.MapCatEventProcessor(thisMicrosoft.AspNetCore.Routing.IEndpointRouteBuilder).endpoints'></a>

`endpoints` [Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.routing.iendpointroutebuilder 'Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder')

The endpoint route builder of the API\.

#### Returns
[Microsoft\.AspNetCore\.Routing\.RouteGroupBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.routing.routegroupbuilder 'Microsoft\.AspNetCore\.Routing\.RouteGroupBuilder')  
The group of the development endpoints, or null when the environment is not Development\.