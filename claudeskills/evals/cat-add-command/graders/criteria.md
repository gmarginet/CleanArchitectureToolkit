---
type: llm
weight: 1
---

A good answer does all of this:
- Runs dotnet new cat-command and does not write the command and handler files by hand.
- Puts the handler in Infrastructure and the command in the core service.
- Returns errors as responses and does not throw for an expected failure.