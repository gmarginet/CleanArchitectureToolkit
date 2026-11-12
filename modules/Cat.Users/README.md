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

# Cat.Users <!-- omit in toc -->  

<!-- region start: Intro-->
Cat.Users tells your business logic who the user is. Handlers depend on one small interface, `ICatUser`, and never see the HTTP context or the token.

The module builds the user from the claims of a validated token. A worker, such as the event processor, can set the user for the work it starts. It does not check permissions. An endpoint uses the policies of ASP.NET Core for that.  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Register the module](#register-the-module)
  - [Use the user in a handler](#use-the-user-in-a-handler)
  - [Set the user in a worker](#set-the-user-in-a-worker)
  - [Change the claim names](#change-the-claim-names)
  - [Share the role claim with JWT bearer](#share-the-role-claim-with-jwt-bearer)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Users)](#nuget-packages)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.Users.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.Users.Abstractions/) | Contracts | `dotnet add package gmarginet.Cat.Users.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Users.Abstractions)](#nuget-packages) |
| [Cat.Users](https://www.nuget.org/packages/gmarginet.Cat.Users/) | Implementation | `dotnet add package gmarginet.Cat.Users` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Users)](#nuget-packages) |
| [Cat.Users.JwtBearer](https://www.nuget.org/packages/gmarginet.Cat.Users.JwtBearer/) | Optional JWT bearer setting | `dotnet add package gmarginet.Cat.Users.JwtBearer` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Users.JwtBearer)](#nuget-packages) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Users.Abstractions](namespaces/Cat.Users.Abstractions/index.md) | The user, the accessor and a plain user for the anonymous and the system user. |
| [Cat.Users](namespaces/Cat.Users/index.md) | The user built from claims, the accessor and the registration. |
| [Cat.Users.JwtBearer](namespaces/Cat.Users.JwtBearer/index.md) | The registration that gives the JWT bearer scheme the role claim name. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

Cat.Users has no dependencies on other CAT modules.  

<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
### Register the module
The core of a service only references `Cat.Users.Abstractions`. The host references `Cat.Users` and registers it.

```csharp
builder.Services.AddCatUsers();
```

`ICatUser` and `ICatUserAccessor` are scoped. The user of an HTTP request comes from the claims of the token. Without a request, and without a worker that set a user, the user is anonymous.

### Use the user in a handler
Ask for `ICatUser`. It has the id, the name, a flag for a login and a role check.

```csharp
public class SavePriceHandler(ICatUser user /* ... */)
{
    // user.UserId goes into a LastUpdatedBy column
    // user.IsInRole("admin") answers a role question
}
```

### Set the user in a worker
Background work has no token. A worker sets the user for the scope it starts. Running as the system is a choice of the worker and never a default.

```csharp
scope.ServiceProvider.GetRequiredService<ICatUserAccessor>().User = CatUser.System("orders");
```

The system user is authenticated and has the role `system`. `CatUser` also builds any other user by hand, which is handy in tests.

### Change the claim names
The defaults fit a token with a flat `roles` claim. Change them for another identity provider.

```csharp
builder.Services.AddCatUsers(options => options.RoleClaimType = "groups");
```

The module reads a token and makes no call to the identity provider.

### Share the role claim with JWT bearer
A role policy such as `RequireRole("admin")` reads the role claim named in the token validation, and `ICatUser.IsInRole` reads `RoleClaimType`. Both must name the same claim. Add `Cat.Users.JwtBearer` and the scheme takes the value from `CatUsersOptions`, so you set it once.

```csharp
builder.Services.AddCatUsers(options => options.RoleClaimType = "roles");
builder.Services.AddCatUsersJwtBearer();
```

The setting runs after the other settings of the scheme, so it wins over a role claim type set in `AddJwtBearer`. Pass the scheme name when it is not `Bearer`. Without this package, set the same value in the token validation yourself.
<!-- region end: Usage-->
