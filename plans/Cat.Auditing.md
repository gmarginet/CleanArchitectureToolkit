# Plans for Cat.Auditing

Records who changed what and when.  
Status: not started. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

Some changes matter later: a price that was changed, an order that was cancelled. People ask who did it and when. An audit trail answers that without anyone writing log statements by hand.

`Cat.Auditing` records the change together with the user and the time. The business logic should not have to know about it.

## What we already know

From the demo plan:

- The demo shows it with who changed a price, and who cancelled an order.
- Orders has an event subscriber, `OrderAuditSubscriber`, that writes an audit record when an order event happens. It is a first sketch of what the module could replace.
- Catalog keeps every old price in a temporal table, which already answers "what was the price then". It does not say who changed it.
- The demo gets the current user from its own `ICurrentUser`, with `UserId`, `Name`, `Email` and `IsAdmin`. It lives in the core service for now. It will become `ICatUser` in `Cat.Authorization.Abstractions`. A development stub reads the `X-Demo-User` header.
- Work without a user, like a scheduled job, has no person to record. The Scheduler uses a client credentials token.

From the module conventions:

- Cross-cutting work is added through decorators, not mixed into the business logic. `Cat.ServiceRequests`, `Cat.Commands` and `Cat.Queries` all run decorators from `Cat.Decorators`.
- Events inside a service go through `Cat.EventAggregators`. Subscribers cannot drive a process, and a failing subscriber throws.

From the architecture:

- Every service owns its data. An audit trail for a service belongs to that service, unless a central audit store is chosen.
- Important events also go out on the Service Bus.

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Content | Who, what and when. |
| Style | Added through a decorator or an event subscriber, not in the business logic. |
| User | The module gets the user from `ICatUser` in `Cat.Authorization.Abstractions`. `Cat.Authorization` owns that interface. |

### Open

- **Where to hook in.** A decorator on commands, a decorator on service requests, a `SaveChanges` interceptor in EF Core, or an event subscriber? Each sees something different.
- **Detail.** Only the fact ("order 123 cancelled by Alice"), or the changed fields with old and new values?
- **Storage.** A table in the database of the service, a separate store, or messages to a central audit service?
- **Overlap.** Temporal tables already keep history for some entities. Does the module use them or stay apart?
- **Who.** It references `Cat.Authorization.Abstractions` for `ICatUser`, without the rest of the authorization module. Is a dependency on a package called Authorization acceptable for users who only want auditing?
- **No user.** What is recorded for a scheduled job or a message handler?
- **Opt in.** Is everything audited, or only what is marked? How is it marked: attribute, registration or interface?
- **Sensitive data.** Names, emails and addresses are personal data. What is left out, and how long is the trail kept?
- **Failures.** If writing the audit record fails, does the change fail too?
- **Reading.** Does the module offer a query to read the trail, or is that the job of the service?
- **Tamper evidence.** Does the trail need to be append only?

## Questions before building

1. What is audited: use cases, entity changes or both?
2. Do you want old and new values, or only the fact?
3. Where should the trail live: in each service database or in one central place?
4. Is it fine that this module references `Cat.Authorization.Abstractions` for `ICatUser`? Which members of `ICatUser` does auditing need?
5. How long must the trail be kept, and are there privacy rules we must follow?
6. Is an audit failure allowed to fail the business action?
7. How do we mark what to audit?
8. What should be recorded when there is no user?
9. Do we need to read the trail in the demo, and through which endpoint?
10. Does `OrderAuditSubscriber` in the demo stay as an example of the event approach, or does the module replace it?
