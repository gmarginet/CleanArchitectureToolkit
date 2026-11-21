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

# Cat.Resilience <!-- omit in toc -->  

<!-- region start: Intro-->
Cat.Resilience makes calls to other services and to outside providers survive a bad moment. A retry fixes a short glitch. A circuit breaker stops you from hammering something that is down.

You pick a named profile and put it on an `HttpClient`, or around one call that is not HTTP. The module has two profiles: `Internal` for your own services and `External` for an outside provider. You can add more by name.

The module is plain .NET. It never references Aspire.  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Put a profile on an HttpClient](#put-a-profile-on-an-httpclient)
  - [The two profiles](#the-two-profiles)
  - [Add or change a profile](#add-or-change-a-profile)
  - [Retry an unsafe method](#retry-an-unsafe-method)
  - [Protect one call that is not HTTP](#protect-one-call-that-is-not-http)
  - [Without Aspire](#without-aspire)
  - [Tests](#tests)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Resilience)](#nuget-packages)

| Package | Role | Targets | Install | Downloads |
|---------|------|---------|---------|-----------|
| [Cat.Resilience.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.Resilience.Abstractions/) | Contracts | netstandard2.0 | `dotnet add package gmarginet.Cat.Resilience.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Resilience.Abstractions)](https://www.nuget.org/packages/gmarginet.Cat.Resilience.Abstractions/) |
| [Cat.Resilience](https://www.nuget.org/packages/gmarginet.Cat.Resilience/) | Implementation | netstandard2.0 | `dotnet add package gmarginet.Cat.Resilience` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Resilience)](https://www.nuget.org/packages/gmarginet.Cat.Resilience/) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Resilience.Abstractions](namespaces/Cat.Resilience.Abstractions/index.md) | The profile names, the settings classes and the pipeline contracts. |
| [Cat.Resilience](namespaces/Cat.Resilience/index.md) | The profiles on `HttpClient`, the pipelines for one call and the module registration. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

Cat.Resilience has no dependencies on other CAT modules.  

<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
### Put a profile on an HttpClient
Call `AddCatResilience` on the `IHttpClientBuilder`. It also registers the module, so nothing else is needed.

```csharp
services.AddHttpClient<IPaymentClient, PaymentClient>()
    .AddCatResilience(CatResilienceProfile.External);
```

A profile has five strategies: a rate limiter, a total timeout, a retry, a circuit breaker and a timeout per try. The profile replaces any resilience handler the client already has, so a client never gets two retry layers. A profile name that does not exist fails the startup of the host.

The circuit breaker state is kept per registered client and per process.

### The two profiles

| Profile | Total timeout | Timeout per try | Retries | Circuit opens at |
|---------|---------------|-----------------|---------|------------------|
| `Internal` | 30 seconds | 10 seconds | 3, after 2 seconds, doubling | 10% failures, 100 calls in 30 seconds |
| `External` | 60 seconds | 15 seconds | 2, after 1 second, doubling | 50% failures, 10 calls in 60 seconds |

`Internal` matches the standard resilience handler of Microsoft. `External` also follows the `Retry-After` header and retries an unsafe method only with an idempotency key.

### Add or change a profile
Add a profile in configuration. Configuration wins over code.

```json
{
  "Cat": {
    "Resilience": {
      "Profiles": {
        "FastFail": {
          "Retry": { "MaxRetryAttempts": 1, "Delay": "00:00:00.500" },
          "AttemptTimeout": { "Timeout": "00:00:05" },
          "TotalTimeout": { "Timeout": "00:00:12" }
        }
      }
    }
  }
}
```

Or add it in code, and use it by name.

```csharp
services.AddCatResilienceModule(options => options.AddProfile("FastFail", profile =>
{
    profile.Retry.MaxRetryAttempts = 1;
    profile.TotalTimeout.Timeout = TimeSpan.FromSeconds(12);
}));

services.AddHttpClient<IInventoryClient, InventoryClient>()
    .AddCatResilience("FastFail");
```

A new profile starts with the defaults of `Internal`. A setting you leave out keeps its default.

### Retry an unsafe method
A `POST`, `PUT`, `PATCH` or `DELETE` can run twice on the other side. The `External` profile therefore retries one only when the request carries an idempotency key. The header is `Idempotency-Key` by default, and `Retry.IdempotencyHeaderName` changes it.

```csharp
var request = new HttpRequestMessage(HttpMethod.Post, "/payments") { Content = content };
request.Headers.Add("Idempotency-Key", sagaId.ToString());
await client.SendAsync(request);
```

You set the key from a business id that survives a restart, such as the saga id. The module never makes a key itself. A `GET` or `HEAD` is retried as usual. Set `Retry.RequireIdempotencyKeyForUnsafeMethods` to apply the same rule to another profile.

### Protect one call that is not HTTP
Inject `ICatResiliencePipelines` and run the call through a profile.

```csharp
await _pipelines.Get(CatResilienceProfile.Internal)
    .ExecuteAsync(ct => _blobs.UploadAsync(name, stream, ct), cancellationToken);
```

The call inside must be safe to repeat, because the pipeline can run it more than once. Never put a database write of the handler inside it. The circuit breaker state is shared by every call that uses the same profile name.

### Without Aspire
The module does not need Aspire. A project without it makes the same calls in its `Program` that the demo `ServiceDefaults` makes:

```csharp
builder.Services.ConfigureHttpClientDefaults(http => http.AddCatResilience(CatResilienceProfile.Internal));
```

### Tests
Register a `TimeProvider` in the service provider, such as `FakeTimeProvider`, and the profiles use it for delays and timeouts. Set `Retry.Delay` to zero to keep a test fast.
<!-- region end: Usage-->
