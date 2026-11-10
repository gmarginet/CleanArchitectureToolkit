<!-- region start: Header-->
<!-- Header template: @.claude\skills\cat-internal-create-header\header.template.md, RootPath: .. -->
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
<!-- region end: Header-->

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-plan skill to update this plan.-->
<!-- region end: TemplateSkill-->

# Plans for `Cat.Decorators` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-catdecorators)
<!-- region end: StatusBadge-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
- [Phase 1](#phase-1)
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
#### Goal
`Cat.Decorators` already exists. This phase settles one question: in which order do the decorators of different modules run? Then it builds the mechanism, so a developer no longer has to add decorators in the right sequence.

#### The problem
More modules will ship decorators: transactions, authorization, and probably tracing, caching and auditing. Each one is optional, and a developer picks the ones they want. The order matters. A transaction must wrap the handler but not the cache. Authorization should run before validation does any work. Today the developer has to know this and add the decorators in the right sequence.

#### What exists today
From the module README:
- The first decorator you add is the innermost one. The last one you add runs first on the way in and last on the way out.
- The factory only wraps a service when you ask for it. A mistake in a decorator shows up at the first request, not at startup.
- Decorators are open generic classes that implement the same open generic interface as the service.
- `AddDecorator(serviceType, decoratorType, parameters)` only appends to a list, and the factory wraps in list order. There is no way to give a decorator a position.

From the other plans:
- [Cat.EFCore.md](Cat.EFCore.md) plans a transaction decorator for commands.
- [Cat.Authorization.md](Cat.Authorization.md) suggests an admin check as a decorator on a service request.

From the demo:
- The demo adds validation, logging and tracing in that sequence, which gives tracing, logging, validation from the outside in.

#### Decided
- **How order works today.** The order in which you add decorators sets the order. See the `Cat.Decorators` README.
- **Order by convention.** A developer should not have to worry about the order. The decorators run in an order set by convention, whatever the sequence in which the developer added them (note of the owner).
- **Override.** A developer who wants a different order can override the convention (note of the owner).

#### Consequences of the recommended mechanism
This is a proposal, not a decision. It assumes option A of question 1, an order number on the registration.
- **Existing registrations.** Today the call sequence rules. With A the sequence still decides between equal numbers, so a developer who never passes an order and adds the modules in the old sequence gets the same result as before. The shipped decorators get their default numbers, so the result can change for someone who used the opposite sequence on purpose. That counts as a breaking change in behavior, so it goes in the release notes.
- **Several modules.** With A, the module registers its own decorator and passes its default order, so a module needs to know no other module. A module must not force another one on the developer.
- **Layers.** The order is kept per service type today, as the factory keeps a list per open generic type. With A the constants are shared, so one convention covers commands, queries and service requests. A decorator that exists for one layer only (caching for queries, transaction for commands) never meets the others.

#### What to build
The module cannot be built yet. The mechanism and the default order need the owner's answer first. Once they are decided, the work is small:
1. `Cat.Decorators.Abstractions`: the named order constants and the `order` argument on `ICatDecoratorFactoryBuilder.AddDecorator`.
2. `CatDecoratorFactory`: keep the order in `CatDecoratorInfo` and sort stably, so the call sequence decides between equal numbers.
3. The `Add...Decorator` extension of each existing module: pass its default order, with an optional `order` argument for the override.
4. Tests for the sort, the tie break and the override.
5. The README chapter on decorator order, and the module READMEs.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Which mechanism do we use to say where a decorator belongs: an order number on the registration, an attribute or named stages?

The convention needs a position per decorator. Options:
- **A. An order number on the registration.** `AddDecorator` gets an `order` argument. The module that ships a decorator passes its default. The factory sorts by order, and by the sequence of the calls when the numbers are equal. The numbers come from named constants in `Cat.Decorators.Abstractions`, spaced out (such as 100, 200, 300), so a developer can slot an own decorator in between. Cost: a new argument, and a list of constants that every module shares.
- **B. An attribute on the decorator class.** `[CatDecoratorOrder(...)]` sits with the class, so the position is next to the code it describes. Registration stays as it is. Cost: the factory reads attributes by reflection, and an override still needs a second path.
- **C. Named stages instead of numbers.** A small enum such as `Tracing`, `Logging`, `Authorization`, `Validation`, `Caching` and `Transaction`. Reads well, but a developer cannot slot something between two stages, unless the enum has an `Order` offset as well.

Recommendation: A. It is the smallest change and the same mechanism does both jobs: the default of a module and the override of a developer. B hides the order in a class, which makes an override harder to see.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
How does a developer override the order: an optional argument on the `Add...Decorator` method, a builder call, or both?

With A, two ways, and the developer could have both:
- the `Add...Decorator` method of a module takes an optional `order`, such as `AddCatServiceRequestsModuleValidationDecorator(order: 250)`,
- or the builder has a call that changes the order of a decorator type already added, `SetDecoratorOrder(typeof(ValidationDecorator<,>), 250)`.

Recommendation: the optional `order` argument. It is the only one a developer needs to find, and it shows at the place where the decorator is added.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Is the proposed default order right: tracing, logging, authorization, validation, caching, transaction?

A first proposal, from the outside in, from what the plans say:
1. tracing (`ActivitySource`),
2. logging,
3. authorization, before validation does any work (see [Cat.Authorization.md](Cat.Authorization.md)),
4. validation,
5. caching, for queries only,
6. transaction, for commands only and next to the handler, so it never wraps the cache (see [Cat.EFCore.md](Cat.EFCore.md)).

The demo adds validation, logging and tracing in that sequence today, which gives tracing, logging, validation from the outside in. So this proposal matches what the demo does now. Auditing has no place yet, see the plan of that module. Confirm or change this order.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Which position gets a decorator of the developer without an order? Options: next to the handler, as the innermost, or at a middle number.

Recommendation: a middle number, after validation and before the transaction, so it sees valid input and runs inside the transaction. A developer who wants another place passes an order.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
Do we add a startup check, and should it warn about equal order numbers?

The check would test that the registered decorators are valid, instead of failing at the first request. With order numbers it could also warn about two decorators with the same number, since the sequence then decides.
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
Where does the recommended order live: the `Cat.Decorators` README only, or in every module README too?

The proposal goes into the `Cat.Decorators` README as the one place that every module points to. The README of every module with a decorator says its default order.
<!-- region end: Question 6-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->