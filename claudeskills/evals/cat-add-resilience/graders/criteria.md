---
type: llm
weight: 1
---

A good answer does all of this:
- Searches for an existing AddCatResilience before adding one.
- Does not retry an unsafe method without asking.
- Does not stack a retry on a retry.