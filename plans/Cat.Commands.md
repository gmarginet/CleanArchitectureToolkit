# Plans for Cat.Commands

Open question for the existing `Cat.Commands` module: may a command carry a result?  
Status: not started. `Cat.Commands` itself exists. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

The module readme says a command changes state and returns no data, only the outcome. Use a query to read data.

A real use case pushes against that. When a command creates an order, the caller wants the new order id, the order number and the time. The demo solves it by putting result properties on the command, which the handler fills in after it runs. That works, but the module does not say it is allowed. We need to decide whether this is a supported pattern, a thing to avoid, or a reason for a change in the module.

## What we already know

From the module readme:

- A command changes state and returns no data, only the outcome. Use `Cat.Queries` to read data.
- A command returns an `ICatResponse`. A failed response is the normal way to say something went wrong.

From the demo:

- `OrderCreateCommand` has the properties `OrderId`, `OrderNumber` and `PlacedAt`, marked "the result. Set by the handler."
- It is a class with a parameterless constructor, because a workflow step creates it and fills it.
- The place order workflow needs the order number after the command ran.

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Current rule | The readme says a command returns no data. Nothing newer is decided. |

### Open

- **Result on the command.** Allow result properties as a documented pattern? Cost: the command is no longer a plain message, and a workflow step has to read it back.
- **A typed command.** A command with a result type, such as `ICatCommand<TResult>` and a response that carries the value. Cost: a bigger change to the processor, the decorators and the workflow steps, and it blurs the line with queries.
- **Query after the command.** The caller sends the command and then a query for the data. Cost: a second round trip, and the id must still come from somewhere.
- **Caller supplied ids.** The caller creates the id, so no result is needed. Cost: it does not cover a number the database hands out, like the order number.
- **Readme.** Whichever way we go, the readme and the demo must say the same thing.

## Questions before building

1. May a command carry a result?
2. If yes, is a property filled by the handler enough, or do we want a typed command?
3. If no, how does the demo get the order number back?
4. Should the readme describe the chosen pattern?
