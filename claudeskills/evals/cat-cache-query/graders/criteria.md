---
type: llm
weight: 1
---

A good answer does all of this:
- Calls AddCatQueryCaching once and lists the query type in the options.
- Uses Shared only when every user gets the same answer.
- Finds the commands that change the data and clears the tag there.