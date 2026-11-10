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
- [Can the module be built?](#can-the-module-be-built)
- [Questions before building](#questions-before-building)

## The idea

More modules will ship decorators: transactions, authorization, and probably tracing, caching and auditing. Each one is optional, and a developer picks the ones they want. The order matters. A transaction must wrap the handler but not the cache. Authorization should run before validation does any work. Today the developer has to know this and add the decorators in the right sequence.

## What we already know

From the module README:

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
| How order works today | The order in which you add decorators sets the order. See the `Cat.Decorators` README. |
| Order by convention | A user should not have to worry about the order. The decorators run in an order set by convention, whatever the sequence in which the user added them (note of the owner). |
| Override | A user who wants a different order can override the convention (note of the owner). |

### Open

How it could work, as a proposal. None of this is decided.

- **How a decorator says where it belongs.** Today `AddDecorator(serviceType, decoratorType, parameters)` only appends to a list, and the factory wraps in list order. The convention needs a position per decorator. Options:
  - **A. An order number on the registration.** `AddDecorator` gets an `order` argument. The module that ships a decorator passes its default. The factory sorts by order, and by the sequence of the calls when the numbers are equal. The numbers come from named constants in `Cat.Decorators.Abstractions`, spaced out (such as 100, 200, 300), so a user can slot an own decorator in between. Cost: a new argument, and a list of constants that every module shares.
  - **B. An attribute on the decorator class.** `[CatDecoratorOrder(...)]` sits with the class, so the position is next to the code it describes. Registration stays as it is. Cost: the factory reads attributes by reflection, and an override still needs a second path.
  - **C. Named stages instead of numbers.** A small enum such as `Tracing`, `Logging`, `Authorization`, `Validation`, `Caching` and `Transaction`. Reads well, but a user cannot slot something between two stages, unless the enum has an `Order` offset as well.
  - **Recommendation.** A. It is the smallest change and the same mechanism does both jobs: the default of a module and the override of a user. B hides the order in a class, which makes an override harder to see.
- **How a user overrides it.** With A, two ways, and the user could have both:
  - the `Add...Decorator` method of a module takes an optional `order`, such as `AddCatServiceRequestsModuleValidationDecorator(order: 250)`,
  - or the builder has a call that changes the order of a decorator type already added, `SetDecoratorOrder(typeof(ValidationDecorator<,>), 250)`.
  
  Recommendation: the optional `order` argument. It is the only one a user needs to find, and it shows at the place where the decorator is added.
- **The default order.** A first proposal, from the outside in, from what the plans say:
  1. tracing (`ActivitySource`),
  2. logging,
  3. authorization, before validation does any work (see [Cat.Authorization.md](Cat.Authorization.md)),
  4. validation,
  5. caching, for queries only,
  6. transaction, for commands only and next to the handler, so it never wraps the cache (see [Cat.EFCore.md](Cat.EFCore.md)).

  The demo adds validation, logging and tracing in that sequence today, which gives tracing, logging, validation from the outside in. So this proposal matches what the demo does now. Auditing has no place yet, see the plan of that module. Confirm or change this order.
- **A user decorator without an order.** What position does it get? Options: next to the handler, as the innermost, or at a middle number. Recommendation: a middle number, after validation and before the transaction, so it sees valid input and runs inside the transaction. A user who wants another place passes an order.
- **Existing registrations.** Today the call sequence rules. With A the sequence still decides between equal numbers, so a user who never passes an order and adds the modules in the old sequence gets the same result as before. The shipped decorators get their default numbers, so the result can change for someone who used the opposite sequence on purpose. That counts as a breaking change in behavior, so it goes in the release notes.
- **Documented order.** The proposal above goes into the `Cat.Decorators` README as the one place that every module points to. The README of every module with a decorator says its default order.
- **Check at startup.** A check that the registered decorators are valid, instead of failing at the first request. With order numbers the check could also warn about two decorators with the same number, since the sequence then decides.
- **Several modules.** Who registers the decorators of an optional module, and in what position? With A the module does it and passes its default, so a module needs to know no other module. A module must not force another one on the developer.
- **Layers.** Do the decorators of commands, queries and service requests share one convention? The order is kept per service type today, as the factory keeps a list per open generic type. With A the constants are shared, so one convention covers all three, and a decorator that exists for one layer only (caching for queries, transaction for commands) simply never meets the others.

## Can the module be built?

Not yet. The mechanism and the default order need your answer first. Once they are decided, the work is small:

1. `Cat.Decorators.Abstractions`: the named order constants and the `order` argument on `ICatDecoratorFactoryBuilder.AddDecorator`.
2. `CatDecoratorFactory`: keep the order in `CatDecoratorInfo` and sort stably, so the call sequence decides between equal numbers.
3. The `Add...Decorator` extension of each existing module: pass its default order, with an optional `order` argument for the override.
4. Tests for the sort, the tie break and the override.
5. The README chapter on decorator order, and the module READMEs.

## Questions before building

1. Which mechanism do we use: an order number on the registration, an attribute or named stages?
2. How does a user override the order: an optional argument on the `Add...Decorator` method, a builder call, or both?
3. Is the proposed default order right: tracing, logging, authorization, validation, caching, transaction?
4. Which position gets a decorator of the user without an order?
5. Do we add a startup check, and should it warn about equal order numbers?
6. Where does the recommended order live: the `Cat.Decorators` README only, or in every module README too?
