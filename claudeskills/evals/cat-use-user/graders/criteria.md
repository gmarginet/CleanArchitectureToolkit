---
type: llm
weight: 1
---

A good answer does all of this:
- Takes ICatUser through the constructor.
- Does not read claims from the HTTP context in the core service.
- Adds a test that gives the handler a user.