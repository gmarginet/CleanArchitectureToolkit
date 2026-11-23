---
type: llm
weight: 1
---

A good answer does all of this:
- Finds the version in Directory.Packages.Cat.props.
- Compares the module readmes of the old and the new version from the NuGet cache.
- Shows the list of changes before it edits code and says that a change the readme does not show is missed.