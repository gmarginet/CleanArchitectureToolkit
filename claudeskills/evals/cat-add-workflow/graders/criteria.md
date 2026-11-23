---
type: llm
weight: 1
---

A good answer does all of this:
- Runs dotnet new cat-workflow.
- Adds the Cat.FluentWorkflows package to the core service when it is missing.
- Offers a saga when the flow must wait for another service.