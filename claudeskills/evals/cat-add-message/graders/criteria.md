---
type: llm
weight: 1
---

A good answer does all of this:
- Runs dotnet new cat-message with --Kind for an event.
- Sends it with the sender of Cat.Messaging and through the outbox when the service has one.
- Points the receiving service to cat-add-message-handler.