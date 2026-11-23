---
type: llm
weight: 1
---

A good answer does all of this:
- Turns the schedule into a cron expression and says it back with the time zone.
- Puts the cron in appsettings under CatScheduling.
- Makes the work a service request with a handler.