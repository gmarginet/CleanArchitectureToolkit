---
type: llm
weight: 1
---

A good answer does all of this:
- Reads the module readme for the version in use before it adds anything.
- Puts only the abstractions in the core service and the implementation in the Api or Infrastructure project.
- Uses the version from Directory.Packages.Cat.props and does not invent a package name.