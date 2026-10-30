# Rule: Dotnet Module Readme Generation
**Trigger:** Creating or modifying any README.md file inside the `modules/` directory.

**Requirements:**
- Always read the latest `modules/CatModuleReadmeTemplate.md` first.
- Replace [[ModuleName]], [[Intro]], [[Usage]], [[NamespaceName]], [[PackageRole]], [[NamespaceDescription]], [[DependentModuleName]], and [[DependencyReason]].
- The NuGet, Namespaces, and Dependencies blocks are tables. Fill one row per project or dependency.
- The NuGet version badge uses the package named like the module. If there is none, use the first project.
- A module without dependencies gets the sentence `[[ModuleName]] has no dependencies on other CAT modules.` instead of the Dependencies table.
- Enforce the precise comment boundaries (`<!-- Start -->` / `<!-- End -->`) and use the exact markdown link formats specified in CLAUDE.md.
- Keep the table of contents up-to-date with the chapters that exist in the readme, ignore the chapters marked with `<!-- omit in toc -->`
