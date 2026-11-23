---
type: llm
weight: 1
---

A good answer does all of this:
- Checks that the template pack is installed with dotnet new list before it creates anything.
- Runs dotnet new cat-service with --Database PostgreSQL and --Messages true and does not write the project files by hand.
- Runs a build and names next steps such as the connection string and the AppHost.