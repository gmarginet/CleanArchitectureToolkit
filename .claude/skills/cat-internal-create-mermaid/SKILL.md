---
name: cat-internal-create-mermaid
description: Write or update a Mermaid diagram (ERD, UML class, sequence) inside a markdown file, in the house style. Use when a data model, class or sequence diagram is added or changed. Architecture and flow drawings use the cat-internal-create-excalidraw skill instead.
argument-hint: "[diagram type and what it should show]"
---

# Mermaid diagrams

Mermaid is for diagrams where the structure matters more than the exact position of the boxes. The renderer places them. For architecture and flow drawings where position carries meaning, use the `cat-internal-create-excalidraw` skill.

| Diagram | Tool |
|---|---|
| ERD, UML class, sequence | Mermaid (this skill) |
| Architecture, flow, layered or deployment drawings | Excalidraw (`cat-internal-create-excalidraw` skill) |

## Where it lives
- Inline in the markdown file that needs it, in a fenced block with the language `mermaid`.
- No separate diagram files and no generated images.
- Put a short plain sentence above the block that says what it shows.

## House rules
- **No styling.** No `%%{init: ...}%%` line, no `themeVariables`, no `style`, `classDef` or other colours. The viewer applies its own theme. Overriding it was tried and rejected.
- **No Mermaid theme for the background.** A code block cannot set its own background. Do not try again.
- Keep labels short and in plain words. No long dashes and no ellipses in labels or comments.

## ERD rules
- Use `erDiagram`.
- Entity names are PascalCase and match the C# class names, for example `OrderLine`.
- Attribute types are C# style: `Guid`, `int`, `decimal`, `string`, `datetime`.
- Show the inherited columns of the `Cat.EFCore` base classes. Check `modules/Cat.EFCore/Cat.EFCore.Entities/` for the current members.
  - `CatEntityBase` (regular entities): `Guid Id PK` and `int SequenceId`.
  - `CatTemporalEntityBase` (temporal data): the same as `CatEntityBase`, plus `datetime ValidFrom` and `datetime ValidUntil`. They are the period columns of the temporal table.
  - `CatReferenceEntityBase` (a table owned by another service): only `Guid Id PK`, no `SequenceId`. It appears in a diagram only when the services share a database. See the foreign key rules below.
  - Database first entities (scaffolded, like the Inventory service) inherit none of these. Show only the columns of the existing database, with its own key types and names, and say so in the sentence above the diagram.
  - Say in the sentence above the diagram which base class each entity uses.
  - Mermaid cannot show index types. State once in that sentence that `Id` is a non-clustered primary key and that `SequenceId` is the identity column with the clustered index. Do not repeat it per table.
- Mark keys with `PK` and `FK`.
- A foreign key column is the full name of the referenced table plus `Id`. For example `OrderStatusId` in `Order`, not `StatusId`. When a table has two foreign keys to the same table, put the role in front, for example `BillingCustomerId`.
- Every relationship has a short verb: `places`, `contains`, `paid by`. Quote it when it has a space.
- Cardinality follows the data: `||--o{` one to zero or many, `||--|{` one to one or many, `||--o|` one to zero or one.
- Services own their data. Check whether the services share a database. The demo plan says which ones do.
  - **Separate databases (the default):** a reference to another service has no `FK`. Give the attribute a short comment instead, for example `Guid ProductId "Book in Catalog, no foreign key"`.
  - **Shared database:** a service may have a foreign key to a table of another service. It maps that table as an entity that inherits `CatReferenceEntityBase` in its own `DbContext`. Draw that entity in the diagram with only the columns the service needs, and say in the sentence above the diagram which service owns it. Mark the foreign key with `FK`.
- A lookup table the service owns, such as a status, is a normal entity that inherits `CatEntityBase`. It is not reference data in the `CatReferenceEntityBase` sense.

## Class and sequence diagrams
- Same naming as the code. Use the real type and member names.
- Show only what the reader needs. Leave out getters, setters and private members.
- Sequence diagrams use the service names from the demo plan as participants.

## Steps
1. Read the markdown file and the code or plan the diagram describes. Use the real names.
2. Write or change the block.
3. Preview it. GitHub, Visual Studio Code and Rider each bundle their own Mermaid version, so a very new feature can render in one and not in another. Stick to the stable diagram types above.
4. Tell the owner which viewers you could not check.
