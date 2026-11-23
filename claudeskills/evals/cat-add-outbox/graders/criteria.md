---
type: llm
weight: 1
---

A good answer does all of this:
- Turns the outbox on for the context of the service and adds its table.
- Says that the receiver needs the inbox because delivery is at least once.
- Checks that the handler calls SaveChanges.