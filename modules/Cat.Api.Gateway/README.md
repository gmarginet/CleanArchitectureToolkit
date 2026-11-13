<!-- region start: Header-->
<!-- Header template: @.claude\skills\cat-internal-create-header\header.template.md, RootPath: ../.. -->
<link href="../../resources/styles/style.css" rel="stylesheet" />
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
            <img src='../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>
<!-- region end: Header-->

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-module-readme skill to update this readme.-->
<!-- region end: TemplateSkill-->

# Cat.Api.Gateway <!-- omit in toc -->  

<!-- region start: Intro-->
Cat.Api.Gateway is the single front door of an application. Clients and services call it, and it routes each call to the right service and checks the token in one place. It is built on [YARP](https://microsoft.github.io/reverse-proxy/), the reverse proxy of Microsoft, and adds the conventions and the secure defaults on top.  

You list your services and their addresses. The gateway derives the routes from that. Everything needs a valid token unless you say otherwise, and a service can choose to accept only the calls that really come from the gateway.  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Set up a gateway host](#set-up-a-gateway-host)
  - [Describe your services](#describe-your-services)
  - [Check the token](#check-the-token)
  - [Make endpoints public](#make-endpoints-public)
  - [Choose how services trust the gateway](#choose-how-services-trust-the-gateway)
  - [Accept only calls from the gateway](#accept-only-calls-from-the-gateway)
  - [Manage the signing key](#manage-the-signing-key)
  - [Headers the gateway removes](#headers-the-gateway-removes)
  - [More duties of the gateway](#more-duties-of-the-gateway)
  - [Change the configuration while the gateway runs](#change-the-configuration-while-the-gateway-runs)
  - [Deploy it anywhere](#deploy-it-anywhere)
  - [Use YARP directly next to your services](#use-yarp-directly-next-to-your-services)
  - [Use another gateway](#use-another-gateway)
  - [What the gateway does not do](#what-the-gateway-does-not-do)
  - [Configuration reference](#configuration-reference)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Api.Gateway)](#nuget-packages)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.Api.Gateway.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.Api.Gateway.Abstractions/) | Contracts | `dotnet add package gmarginet.Cat.Api.Gateway.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Api.Gateway.Abstractions)](#nuget-packages) |
| [Cat.Api.Gateway](https://www.nuget.org/packages/gmarginet.Cat.Api.Gateway/) | Implementation | `dotnet add package gmarginet.Cat.Api.Gateway` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Api.Gateway)](#nuget-packages) |
| [Cat.Api.Gateway.Verification](https://www.nuget.org/packages/gmarginet.Cat.Api.Gateway.Verification/) | Optional check in a service | `dotnet add package gmarginet.Cat.Api.Gateway.Verification` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Api.Gateway.Verification)](#nuget-packages) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Api.Gateway.Abstractions](namespaces/Cat.Api.Gateway.Abstractions/index.md) | The header names and values that the gateway and the services share. |
| [Cat.Api.Gateway](namespaces/Cat.Api.Gateway/index.md) | The gateway: the setup calls, the configuration and the secure defaults, on top of YARP. |
| [Cat.Api.Gateway.Verification](namespaces/Cat.Api.Gateway.Verification/index.md) | The check that makes a service accept only calls that come from the gateway. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

Cat.Api.Gateway has no dependencies on other CAT modules.  

<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
You need the gateway project and, only in the services that want the gateway only guarantee, the verification project. A service that relies on the token alone, or on the network, references nothing from this module.

| You are | You reference |
|---------|---------------|
| The gateway host | `Cat.Api.Gateway` |
| A service that accepts only calls from the gateway | `Cat.Api.Gateway.Verification` |
| A service that checks the token itself | Nothing from this module. Use the standard ASP.NET Core JWT bearer authentication. |

The gateway project and the verification project target the latest .NET. The abstractions project targets `netstandard2.0`.

### Set up a gateway host
The gateway is a normal ASP.NET Core project. Three calls set it up.

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCatApiGateway(builder.Configuration);

var app = builder.Build();
app.UseCatApiGateway();
app.MapCatApiGateway();
app.Run();
```

- `AddCatApiGateway` reads the `CatGateway` section of the configuration and registers everything.
- `UseCatApiGateway` adds the middleware in this order: correlation id, request log, request limits, rate limit, CORS, authentication and authorization.
- `MapCatApiGateway` maps the reverse proxy. When the gateway has a signing key, it also maps the endpoint that publishes the public keys.

The gateway is closed by default. Every endpoint of the host needs a valid token, so also a health check that you map yourself. Mark it with `AllowAnonymous()`.

The gateway holds no business logic and no other module is needed.

### Describe your services
The service is the unit of configuration. Give it a name and an address. The routes follow by convention.

```json
{
  "CatGateway": {
    "Authentication": {
      "Authority": "https://keycloak.example.com/realms/shop",
      "Audience": "shop-gateway"
    },
    "Services": {
      "catalog": { "Address": "https://localhost:5000" },
      "orders":  { "Address": "https://localhost:5001" }
    }
  }
}
```

What this gives you:

| Convention | Result |
|------------|--------|
| The path is `/` followed by the service name | A request to `/catalog/books/42` goes to the `catalog` service. |
| The prefix is removed | The service sees `/books/42`. Set `StripPrefix` to `false` to keep it. |
| The path of the address stays | With the address `https://localhost:5000/catalog`, the service sees `/catalog/books/42`. |
| Every endpoint needs a token | See [Check the token](#check-the-token). |
| The wait for an answer is 30 seconds | Set `Timeout` on the service, or in `Defaults`. A slow service gives a 504 answer. |

Only configure what differs:

```json
"catalog": {
  "Address": "https://localhost:5000",
  "Path": "/shop/api",
  "StripPrefix": true,
  "Timeout": "00:00:10",
  "HealthCheckPath": "/health"
}
```

- `Path` changes where the gateway listens for the service.
- `Addresses` replaces `Address` when a service runs in more than one instance. The gateway spreads the calls.
- `HealthCheckPath` makes the gateway call that path, every `HealthCheckInterval` (15 seconds by default). An instance that fails is left out until it answers again.
- `Defaults` holds the values a service gets when it sets none, for now `GatewayOnly` and `Timeout`.

A service name can hold letters, digits and `-`, `.` and `_`. Two services cannot share a path.

### Check the token
The gateway uses the standard ASP.NET Core JWT bearer authentication. It does not check tokens with code of its own, so every OpenID Connect provider works, such as Keycloak, Microsoft Entra ID or Auth0.

You set the address of the provider and the audience a token must have:

```json
"Authentication": {
  "Authority": "https://keycloak.example.com/realms/shop",
  "Audience": "shop-gateway",
  "RequireHttpsMetadata": true
}
```

- A request without a valid token gets a 401 answer, and the service never sees it.
- A valid token goes on to the service unchanged. The gateway does not read, change or replace it, and it does not check roles. The service checks the token again and does its own authorization with the claims in it.
- The same goes for a call from one service to another through the gateway. The caller forwards the token it received, so the second service can authorize with the same claims.
- The gateway needs `Authority` and `Audience` unless every endpoint is public.
- A request to a path that no service owns also gets a 401 answer when it has no token, so a caller learns nothing about the paths of the gateway.

### Make endpoints public
Some endpoints need no token, such as the book catalog that anyone may read. List them per service as a method and a path:

```json
"catalog": {
  "Address": "https://localhost:5000",
  "Anonymous": [ "GET /books/**", "GET,HEAD /covers/*/small" ]
}
```

| Part | Meaning |
|------|---------|
| `GET` or `GET,HEAD` | The methods that are public. Without methods, or with `*`, every method is public. Use no spaces inside the list. |
| `*` as a segment | Exactly one segment. |
| `**` as the last segment | The rest of the path, also nothing. `/books/**` matches `/books` and `/books/42/cover`. |

The path is relative to the path of the service. Everything you do not list stays protected. `POST /books` stays protected in the example above.

Things to know:

- A pattern matches without regard to case, because route matching does. The service gets the path as it was sent.
- A pattern can only hold letters, digits and `- . _ ~ %`, and the two wildcards.
- `* /**` makes the whole service public. Then the gateway needs no `Authority`.

### Choose how services trust the gateway
All calls go through the gateway, so a service only has to decide whom it trusts. You choose, per service.

| Choice | The service | What it protects against | Cost |
|--------|-------------|--------------------------|------|
| Network only | Accepts every call it can reach and trusts the network | Nothing beyond the network itself. Anything that can reach the service can claim any identity. | None |
| Check the token | Validates the forwarded token itself, with the standard JWT bearer authentication | A caller without a valid token, and a forged identity | The service needs the address of the identity provider and the audience |
| Gateway only | Also checks that the call really came from the gateway, with the gateway assertion | A call that goes around the gateway, also an anonymous one | A signing key at the gateway and the verification project in the service |

The token check is enough for protected endpoints. The gateway only choice matters most for the public endpoints, because they carry no token. Without it, anything that reaches the service can call them, and can call the protected ones too, as far as the service checks the token itself.

Network only is a valid choice when the network is trusted, but it is the weakest. Treat it as a decision, and write it down.

### Accept only calls from the gateway
Turn it on in two places.

At the gateway, per service or for all of them:

```json
"CatGateway": {
  "Defaults": { "GatewayOnly": true },
  "Services": {
    "catalog": { "Address": "https://localhost:5000" },
    "payments": { "Address": "https://localhost:5002", "GatewayOnly": false }
  }
}
```

The gateway now adds a gateway assertion to every call to a gateway only service, also to a public endpoint. The assertion is a short-lived token that the gateway signs. It travels in its own header, `X-Cat-Gateway-Assertion`, so the token of the user stays untouched in `Authorization`.

In the service, add the verification project:

```csharp
builder.Services.AddCatGatewayVerification(builder.Configuration);

var app = builder.Build();
app.UseCatGatewayOnly();
```

```json
"CatGatewayVerification": {
  "Audience": "catalog",
  "JwksAddress": "https://gateway.example.com/.well-known/cat-gateway/jwks.json"
}
```

- `Audience` is the name of this service, as the gateway knows it. An assertion is for one service only. A service rejects an assertion that was made for another one.
- `JwksAddress` is where the gateway publishes its public keys. The service downloads them, keeps them for 10 minutes and downloads again when an assertion has a key it does not know. It never downloads more often than every 30 seconds, so a caller cannot make the service download without end. When a download fails, the service keeps the keys it has.
- `PublicKeyPems` holds the public keys as text, for a service that cannot reach the gateway or that wants a fixed key. You can use it next to `JwksAddress`.
- Use HTTPS for `JwksAddress` when the network is not trusted. Whoever can change that answer can sign assertions. The service logs a warning when you use HTTP.
- The service starts only when `Audience` and one key source are set.

A request without a valid assertion gets a 401 answer. Let an endpoint stay reachable without the gateway, such as a health check, with `AllowDirectAccess()`:

```csharp
app.MapGet("/health", () => "ok").AllowDirectAccess();
```

Prefer a policy over the middleware when only some endpoints need it. The scheme name is `CatGatewayVerificationDefaults.AuthenticationScheme`.

What the service checks, on every assertion:

- The signature, with the keys of the gateway. Only the algorithm `ES256` is accepted, so a token that asks for another algorithm, or for none, fails.
- The issuer, `cat-gateway` unless you changed `Assertion:Issuer` at the gateway.
- The audience, the name of the service.
- The lifetime, with a difference of 10 seconds allowed between the clocks. A token without an expiry fails.
- That the request has one assertion header, not two.

The assertion is valid for 30 seconds by default, and the gateway reuses one for a service until half of that time has passed. That keeps the cost low. A copy of an assertion is useless for another service and after the lifetime.

### Manage the signing key
The gateway signs with an elliptic curve key on P-256.

| Environment | Behavior |
|-------------|----------|
| Development | The gateway generates a key when you configure none. It changes with every start, and two instances would not share it. |
| Anywhere else | You configure the key. A gateway only service without a key stops the gateway from starting. |

Create a key and keep the private part in a secret store:

```bash
openssl ecparam -name prime256v1 -genkey -noout | openssl pkcs8 -topk8 -nocrypt -out gateway-key.pem
```

```json
"Assertion": {
  "PrivateKeyPemFile": "/run/secrets/gateway-key.pem"
}
```

Use `PrivateKeyPem` to give the text itself, for example from an environment variable of your platform. Use one of the two, not both.

To replace the key without a gap:

1. Put the public key of the old key in `Assertion:PreviousPublicKeyPems`.
2. Configure the new private key.
3. Restart the gateway. It publishes both public keys, so a service accepts the assertions that are already out.
4. After the lifetime has passed, remove the old public key.

The key and the other `Assertion` settings are read when the gateway starts.

### Headers the gateway removes
A caller must never be able to set a header that a service reads as a fact. The gateway removes these from every request, on every route, also on routes you added with plain YARP configuration:

| Header | Why |
|--------|-----|
| `X-Cat-Gateway-Assertion` | Only the gateway may add it. |
| `X-User`, `X-User-Id`, `X-Forwarded-User`, `X-Authenticated-User`, `X-Remote-User`, `X-Original-User` | Common headers that a service might read as an identity. |
| `Forwarded` | Replaced like the `X-Forwarded-*` headers, see below. |
| The headers in `Headers:StripHeaders` | Your own, such as `X-Tenant`. |

The `X-Forwarded-For`, `-Host`, `-Proto` and `-Prefix` headers are replaced by the gateway, so a caller cannot fake an address. When another proxy stands in front of the gateway and you trust it, set `Headers:TrustForwardedHeaders` to `true`, and the gateway adds to the headers it gets.

The removal runs after YARP has copied the headers of the request, so the copy cannot bring one back.

### More duties of the gateway
| Duty | Default | Setting |
|------|---------|---------|
| Correlation id | Every request gets an id in `X-Correlation-Id`. A short id of plain characters from the caller is kept. Anything else is replaced. The id goes to the service, back to the caller and into the log scope. | None |
| Trace context | The `traceparent` header continues through the gateway, so a trace spans the gateway and the services. | None |
| Request log | One line per request with the method, the path, the status, the time and the service. Never the query string, a header or a body. | Use the logging configuration of your host |
| Request size | 10 MB. A larger body gets a 413 answer, and the service never sees it. | `Limits:MaxRequestBodySize` |
| Rate limit | 300 requests per minute per remote address. More gets a 429 answer. | `RateLimit:Enabled`, `PermitLimit`, `Window` |
| Timeout | 30 seconds per service. | `Timeout` on the service or in `Defaults` |
| Health checks | Off. Switch them on per service. | `HealthCheckPath` |
| CORS | Off. List the origins that may call the gateway. A browser preflight is answered without a token. | `Cors:AllowedOrigins`, `AllowedMethods`, `AllowedHeaders`, `AllowCredentials` |

Behind a load balancer or a proxy, every call seems to come from the same address. Then the rate limit counts them all together. Let the host use the forwarded headers middleware of ASP.NET Core, or limit at the proxy.

The rate limit, CORS, the limits, the authentication and the assertion settings are read when the gateway starts.

### Change the configuration while the gateway runs
The module has no live configuration feature of its own. It follows the default behavior of .NET configuration and YARP: when the configuration source reloads, the gateway picks up the services and the defaults without a restart. A file that you edit, a mounted file or Azure App Configuration all work.

- A new configuration is read and checked before it goes live. When it is not valid, the gateway logs the errors and keeps the last good configuration. It never stops because of a bad edit.
- A change that is valid goes live as it is. Removing a service or a public pattern takes effect right away, and so does adding one.
- Whoever can change the configuration can send traffic elsewhere and open an endpoint. Protect the source of the configuration like you protect a secret.

At the start there is no earlier configuration, so a configuration that is not valid stops the gateway with a message that lists every error.

### Deploy it anywhere
The module never references Aspire, and it does not care where it runs. It is an ASP.NET Core project, so it runs as an executable, in a container, in Azure Container Apps or on a developer machine.

The address of a service is a plain address. Pick the one that fits the place:

| Place | Address |
|-------|---------|
| Development machine | `https://localhost:5000` |
| Containers on one network | The name of the container, such as `http://catalog:8080` |
| Azure Container Apps | The internal address of the app, such as `http://catalog` |

Settings can come from any configuration source. Environment variables use two underscores, for example `CatGateway__Services__catalog__Address` and `CatGateway__Services__catalog__Anonymous__0`. Put the private key in a secret of your platform and map it to `CatGateway__Assertion__PrivateKeyPem`.

#### Aspire service discovery
When you use Aspire, let the service name stand for the address. Add the service discovery package to the host and one call to the YARP builder that `AddCatApiGateway` returns:

```csharp
builder.Services.AddServiceDiscovery();
builder.Services.AddCatApiGateway(builder.Configuration)
    .AddServiceDiscoveryDestinationResolver();
```

```json
"catalog": { "Address": "http://catalog" }
```

The package is `Microsoft.Extensions.ServiceDiscovery.Yarp`. Aspire gives the host the real address of `catalog`. A change of the address is picked up, also while the gateway runs. For the verification project, the key download goes through the standard `HttpClient` setup, so it uses service discovery when you add it to the HTTP client defaults.

### Use YARP directly next to your services
Everything of YARP stays available. Use the builder that `AddCatApiGateway` returns, and do not call `AddReverseProxy` again:

```csharp
builder.Services.AddCatApiGateway(builder.Configuration)
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
```

Routes from YARP configuration get the same secure defaults as your services. They need a token unless the route says `"AuthorizationPolicy": "anonymous"`, the identity headers are removed and the forwarded headers are replaced. To make such a route send the gateway assertion, add the metadata `Cat.Service` with the service name and `Cat.GatewayOnly` with the value `true` to the route.

### Use another gateway
You do not have to use this module. Azure API Management or any other gateway can take the role, and a service can still check the token and forward it. What you lose is the gateway only guarantee, because that needs this module as the gateway. A client or a service can call another gateway as long as it has the address.

### What the gateway does not do
- It does not check roles or other authorization rules. A service does that, with the claims in the token.
- It does not exchange or change tokens. A service forwards the token it received, or gets a token of its own for a call without a user.
- It does not retry calls. The caller retries, and two layers of retries multiply.
- It does not collect the OpenAPI documents of the services and does not cache responses.
- It does not use mutual TLS between the gateway and the services.

### Configuration reference
Everything lives in the `CatGateway` section.

| Setting | Default | Meaning |
|---------|---------|---------|
| `Authentication:Authority` | none | The address of the identity provider. Needed unless every endpoint is public. |
| `Authentication:Audience` | none | The audience a token must have. Needed unless every endpoint is public. |
| `Authentication:RequireHttpsMetadata` | `true` | Whether the address of the identity provider must use HTTPS. |
| `Defaults:GatewayOnly` | `false` | Whether services get the gateway assertion. |
| `Defaults:Timeout` | `00:00:30` | How long the gateway waits for a service. |
| `Services:<name>:Address` | none | The address of the service. |
| `Services:<name>:Addresses` | none | The addresses of the instances, instead of `Address`. |
| `Services:<name>:Path` | `/<name>` | Where the gateway listens for the service. |
| `Services:<name>:StripPrefix` | `true` | Whether the path is removed before the call. |
| `Services:<name>:Anonymous` | none | The public endpoints, as `METHOD /path`. |
| `Services:<name>:GatewayOnly` | from `Defaults` | Whether this service gets the gateway assertion. |
| `Services:<name>:Timeout` | from `Defaults` | How long the gateway waits for this service. |
| `Services:<name>:HealthCheckPath` | none | The path for the health check. |
| `Services:<name>:HealthCheckInterval` | `00:00:15` | How often the health check runs. |
| `Assertion:Issuer` | `cat-gateway` | The issuer of the assertion. |
| `Assertion:Lifetime` | `00:00:30` | How long an assertion is valid, from 5 seconds to 5 minutes. |
| `Assertion:PrivateKeyPem` | none | The private key as text. |
| `Assertion:PrivateKeyPemFile` | none | The path of a file with the private key. |
| `Assertion:PreviousPublicKeyPems` | none | Public keys of earlier signing keys. |
| `Assertion:JwksPath` | `/.well-known/cat-gateway/jwks.json` | Where the gateway publishes its public keys. |
| `RateLimit:Enabled` | `true` | Whether the rate limit is on. |
| `RateLimit:PermitLimit` | `300` | Requests per window. |
| `RateLimit:Window` | `00:01:00` | The length of the window. |
| `Cors:AllowedOrigins` | none | Origins that may call the gateway. CORS is off while this is empty. |
| `Cors:AllowedMethods` | all | Methods a browser may use. |
| `Cors:AllowedHeaders` | all | Headers a browser may send. |
| `Cors:AllowCredentials` | `false` | Whether a browser may send credentials. |
| `Limits:MaxRequestBodySize` | `10485760` | The largest request body, in bytes. |
| `Headers:StripHeaders` | none | Extra headers to remove from every request. |
| `Headers:TrustForwardedHeaders` | `false` | Whether to trust the forwarded headers of an earlier proxy. |

The settings of the verification project live in the `CatGatewayVerification` section of a service.

| Setting | Default | Meaning |
|---------|---------|---------|
| `Audience` | none | The name of the service, as the gateway knows it. Required. |
| `Issuer` | `cat-gateway` | Must match `Assertion:Issuer` of the gateway. |
| `JwksAddress` | none | Where the gateway publishes its keys. |
| `PublicKeyPems` | none | Public keys as text. Set this, `JwksAddress` or both. |
| `JwksRefreshInterval` | `00:10:00` | How long the downloaded keys are kept. |
| `JwksMinimumRefreshInterval` | `00:00:30` | The shortest time between two downloads. |
| `ClockSkew` | `00:00:10` | The difference allowed between the clocks. |

<!-- region end: Usage-->
