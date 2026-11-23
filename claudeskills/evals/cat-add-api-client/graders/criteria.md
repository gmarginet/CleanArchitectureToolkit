---
type: llm
weight: 1
---

A good answer does all of this:
- Separates the service that offers the client from the service that calls it.
- Registers the client with AddCatApiClient and calls it through CatApiCall.
- Does not edit the generated code.