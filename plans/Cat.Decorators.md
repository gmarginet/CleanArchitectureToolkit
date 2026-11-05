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

# Plans for Cat.Decorators

Open question for the existing `Cat.Decorators` module: in which order do the decorators of different modules run?  
Status: not started. `Cat.Decorators` itself exists. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

More modules will ship decorators: transactions, authorization, and probably tracing, caching and auditing. Each one is optional, and a developer picks the ones they want. The order matters. A transaction must wrap the handler but not the cache. Authorization should run before validation does any work. Today the developer has to know this and add the decorators in the right sequence.

## What we already know

From the module readme:

- The first decorator you add is the innermost one. The last one you add runs first on the way in and last on the way out.
- The factory only wraps a service when you ask for it. A mistake in a decorator shows up at the first request, not at startup.
- Decorators are open generic classes that implement the same open generic interface as the service.

From the plans:

- [Cat.EFCore.md](Cat.EFCore.md) plans a transaction decorator for commands.
- [Cat.Authorization.md](Cat.Authorization.md) suggests an admin check as a decorator on a service request.

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| How order works today | The order in which you add decorators sets the order. See the `Cat.Decorators` readme. |

### Open

- **Documented order.** A recommended order in one place, for example in the `Cat.Decorators` readme, so every module can point to it.
- **Order by number.** A decorator carries an order number, so the sequence does not depend on the sequence of the calls. Cost: a new concept in the module.
- **Check at startup.** A check that the registered decorators are valid, instead of failing at the first request.
- **Several modules.** Who registers the decorators of an optional module, and in what position? A module must not force another one on the developer.
- **Layers.** Do the decorators of commands, queries and service requests share one convention?

## Questions before building

1. Do we only document a recommended order, or add an order number?
2. Do we want a startup check for decorators?
3. Where does the recommended order live?
4. Which decorators do we expect first, and in what order should they run?
