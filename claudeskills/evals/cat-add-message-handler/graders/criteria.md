---
type: llm
weight: 1
---

A good answer does all of this:
- Runs dotnet new cat-message-handler.
- Adds a Receive of the message to the event processor registration.
- Says that a handler that writes to the database saves through its own context so the inbox row is saved with it.