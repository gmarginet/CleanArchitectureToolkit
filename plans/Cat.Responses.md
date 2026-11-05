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

# Plans for Cat.Responses

Open question for the existing `Cat.Responses` module and its users: how do we name error codes?  
Status: not started. `Cat.Responses` itself exists. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

Every failed response carries errors with a stable code. Clients match on the code, not on the text. The modules define codes and the demo services define their own, and so far nothing says how a service should choose a prefix. A clear convention keeps codes unique and tells a developer what to do.

## What we already know

From the module readmes:

- `Cat.Validators` uses the prefix `CAT-VAL-` and says to give your own codes a prefix of your own, like `APP-`, so they do not clash with `CAT-VAL-` or `CAT-GEN-`.
- `Cat.ServiceRequests` returns `CAT-GEN-1001` for an unexpected response.
- `Cat.Responses` has the failed types `BadRequest`, `Unauthorized`, `Forbidden`, `NotFound`, `Conflict` and `InternalServerError`.
- `Cat.Minimal.Api` shows `CAT-DEM-1000` as an example code in its readme.

From the demo:

- Catalog uses the prefix `CAT-CTL-` in `CatalogErrorDefinitions`.
- Orders uses the prefix `CAT-ORD-` in `OrderErrorDefinitions`.
- Both demo prefixes start with `CAT-`, the same start as the module codes. This is the opposite of the advice in the `Cat.Validators` readme.

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Advice for your own codes | Use a prefix of your own, as the `Cat.Validators` readme says. Module codes use `CAT-` with a short area name. |

### Open

- **The demo prefixes.** Keep `CAT-CTL-` and `CAT-ORD-`, or change them to a prefix that is not `CAT-`? Keeping them is simple. Changing them makes the demo follow its own advice.
- **A convention.** A pattern such as `<PREFIX>-<AREA>-<number>`, and a number range for each kind of error.
- **A registry.** A list of the codes of every module in one place, for example in the `Cat.Responses` readme.
- **A helper.** A small base class for error definitions, since both demo services repeat the same shape.
- **Message text.** Do codes go with localized messages through `Cat.Localizations`? See [Cat.Localizations.md](Cat.Localizations.md).

## Questions before building

1. Do the demo services keep the `CAT-` prefix, or switch to their own?
2. Do we write down a code convention in the `Cat.Responses` readme?
3. Do we want a registry of all module codes?
4. Is a base class for error definitions worth adding?
