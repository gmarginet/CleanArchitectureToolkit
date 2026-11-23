---
type: llm
weight: 1
---

A good answer does all of this:
- Runs dotnet new cat-entity with --Database SqlServer.
- Adds the DbSet and a migration and reads the migration.
- Does not use cat-table for a code first service.