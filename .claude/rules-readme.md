# Rule: Dotnet Module Readme Generation
**Trigger:** Creating or modifying any README.md file inside the `modules/` directory.

**Requirements:**
- Always read `modules/CatModuleReadmeTemplate.md` first.
- Replace [[ModuleName]], [[Intro]], [[Usage]], [[NamespaceName]], and [[DependentModuleName]].
- Enforce the precise comment boundaries (`<!-- Start -->` / `<!-- End -->`) and use the exact markdown link formats specified in CLAUDE.md.
- Keep the table of contents up-to-date with the chapters that exist in the readme, ignore the chapters marked with `<!-- omit in toc -->`
