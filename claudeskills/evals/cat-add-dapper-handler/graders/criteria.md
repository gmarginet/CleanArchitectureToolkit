---
type: llm
weight: 1
---

A good answer does all of this:
- Runs dotnet new cat-dapper-query and keeps the SQL in a .sql file.
- Passes values as parameters and never concatenates SQL.
- Keeps the core service on the abstractions.