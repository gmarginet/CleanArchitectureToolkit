<link href="../resources/styles/style.css" rel="stylesheet" />
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
            <img src='../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Plans for Cat.Api.Gateway

The single front door of an application: it routes the calls of clients and services to the right service and checks the token in one place.  
Status: in development. The module is built and tested. The demo gateway does not use it yet.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [What the spike showed](#what-the-spike-showed)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

The application architecture of the toolkit has an API gateway. Clients only talk to it, and so do services that need something from another service. Every team that follows the architecture has to build that gateway itself: the routes, the token check, the forwarding and the health checks. Most of it is the same in every application.

`Cat.Api.Gateway` gives the gateway a standard shape. A developer picks it when they want the architecture as it is described, and leaves it out when they use another gateway. It holds no business logic. It only routes, and it does the cross-cutting work that belongs at the door.

It sits between two other modules. `Cat.Api.Client` is the caller side of a service to service call and sends it to the gateway. `Cat.Authorization` makes the service check the token again, because the gateway and the service both validate it.

## What we already know

From the root readme:

- The API gateway is the single front door of the application. It receives every request from the clients, and every call between services, and forwards it to the right service.
- Clients need to know one address, not one per service. Services only need to know the gateway address.
- Cross-cutting concerns like authentication and routing live in one place.
- The gateway holds no business logic. It only routes.
- Services never call each other directly. The call always goes through the gateway.
- A request flows from the client through the gateway to the service. A call from one service to another goes through the gateway and the answer comes back the same way.
- The application runs as containers in Azure Container Apps.

From the demo plan:

- The gateway is planned for later. It is the API gateway of the root readme. How it looks is clear once it is built, and it could become a new module.
- The React client only talks to the gateway. The client has no shared contracts with the services.
- Keycloak runs as a container, started by the AppHost. The realm holds a client for the gateway.
- The gateway validates the token and forwards it unchanged. The inner service validates the JWT itself and does not trust the network.
- Catalog reads need no token. The Orders endpoints do. The gateway rejects an unauthenticated save of a book, and the service checks the token again.
- The gateway comes together with Keycloak, the JWT validation in the services, the real `ICurrentUser` and the login of the React client. Orders does not change for it.
- The roadmap puts the gateway and the login in stage 2, before the React client.
- Until the gateway exists, Orders calls Catalog directly, and the calls of the `.http` files go straight to the services on the ports 5101 and 5102.
- The architecture drawing has a hatched box for it, and the demo block detects it by a folder `demo/Cat.Demo.Api.Gateway`.

From the other module plans:

- `Cat.Api.Client` sends calls through the gateway. The gateway address comes from configuration or Aspire service discovery, and the module must work without Aspire.
- `Cat.Api.Client` forwards the token of the caller. Calls without a user use a client credentials token.
- `Cat.Authorization` says the gateway and the service both validate the token.
- `Cat.Messaging` covers the asynchronous side. A message does not go through the gateway.

From the module conventions:

- A module never depends on Aspire or on the demo `ServiceDefaults`.
- A module splits into an `Abstractions` project, the implementation and optional parts. A developer picks the modules and the projects they want, and a module never forces another one on them.

## What the spike showed

A throwaway project with YARP 2.3.0 and `Microsoft.Extensions.ServiceDiscovery.Yarp` 10.11.0 on .NET 10 tested the two fit checks. It used HTTP only, with a configuration file in place of Aspire service discovery.

- **Header stripping.** A request transform removes identity headers after YARP copies the request headers. A spoofed `X-User-Id` never reached the service, and a forged assertion header was replaced. The `Authorization` header and the trace header were forwarded.
- **Reload.** After a change of the service address in the configuration file, the gateway sent traffic to the new address in about 6 seconds, without a restart.
- **Broken configuration.** Invalid JSON kept the last good configuration. A valid but wrong change goes live, as YARP does it: removing the service gave a 502. This is a reason for the module to validate its service options.
- **Not tested.** JWT validation, assertion signing, rate limiting and CORS. They are standard ASP.NET Core and YARP features and are tested in the build.

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Name | `Cat.Api.Gateway`. The owner decided that the gateway is a module. |
| Job | The single front door. It routes the calls of clients and services. It holds no business logic. See the root readme. |
| Token | The gateway validates the token and forwards it unchanged. The service validates it again. See the demo plan. |
| Aspire | The module never references Aspire or `ServiceDefaults`. |
| Demo project name | The gateway block of the demo is the project `Cat.Demo.Api.Gateway`. The module, if we build it, is `Cat.Api.Gateway`. |
| Module shape | A library of extensions that a host project calls. It is not a ready made host and not a template. |
| Trust | The user chooses how internal services trust the gateway: rely on network security only, or check the token. With the token check, the gateway validates the token and forwards it unchanged, and the service validates it again. The owner accepts the token check as enough for protected endpoints. |
| Gateway only | A user can choose that anonymous communication to a service has a guarantee that it comes from the gateway. It is an option, not a rule. |
| Gateway assertion | The gateway only guarantee uses a gateway assertion: a short-lived token, signed by the gateway, in its own header. The user token stays untouched in `Authorization`. mTLS is not planned. |
| Assertion keys | Services get the public key from a JWKS endpoint of the gateway by default, or from a key in configuration as a fallback. The gateway signs with a configured key in production and a generated key in development. |
| Routes | The unit of configuration is the service, not the route. A service has a name and an address, and the routes follow by convention: `/name/**` goes to that service. A developer only configures what differs. Full YARP configuration stays available underneath. |
| Public routes | Every route requires a token by default. A service lists the public endpoints as method and path patterns, such as `GET /books/**`. |
| Live config | The module builds no live configuration feature of its own and follows the default behavior of YARP and .NET configuration. |
| Token only | The gateway is only responsible for the token. It checks that a valid token is present. Role and other authorization rules stay in the services. |
| Duties | Besides routing, the token check and the gateway assertion, the module has: stripping of identity and `X-Forwarded-*` headers (always on), correlation id and trace continuation, request logging, health checks of the destinations, rate limiting with a sensible default, request size limits and timeouts with defaults, and CORS (off unless configured). |
| Not in the module | Retries (the caller retries, see `Cat.Resilience`), OpenAPI aggregation and response caching. |
| Token exchange | Not in scope. A service forwards the token it received, or `Cat.Api.Client` gets a client credentials token. |
| Finding services | `Address` is a plain URL, also on Azure Container Apps. Aspire service discovery is an optional extra that the host adds. The module never references it. |
| Other gateways | A developer may use another gateway, such as Azure API Management, and still use `Cat.Api.Client`. The gateway only option needs this module as the gateway. |
| Authentication | The module does not validate tokens itself. It uses the standard ASP.NET Core JWT bearer authentication, and by convention only `Authority` and `Audience` need configuring. Any OpenID Connect provider works, Keycloak is only the demo choice. Services do the same on their side. |
| Projects | `Cat.Api.Gateway.Abstractions` (shared, no dependencies: header name, options, claim names), `Cat.Api.Gateway` (the YARP based extensions for the gateway host) and `Cat.Api.Gateway.Verification` (an authentication scheme for services that choose the gateway only option, no YARP). A service that does not choose that option references none of them. |
| Demo gateway | The demo gateway `Cat.Demo.Api.Gateway` uses the module from the start. It is a host project that calls the extensions of the module. |
| Scope | The module has all its features from the start, even those the demo does not use. The demo does not lead the module, and there is no time pressure. |
| Foundation | Build on YARP. We do not write our own router, and we do not reinvent what exists, like `Mapperly` for mappings. A spike confirmed that it fits, see [What the spike showed](#what-the-spike-showed). |

### Open

None at the moment.

## Questions before building

None at the moment. The design is decided and the fit checks passed.


