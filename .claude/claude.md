# Clean Architecture Toolkit (`CLAUDE.md`)

Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications embracing SOLID principles for maintainability, testability, and scalability.

## 🛠️ Essential Commands
All workflows utilize Cake. Execute via the root `./build.sh` or `.\build.ps1`:
- **Clean:** `dotnet cake --target=Clean`
- **Build:** `dotnet cake --target=Build`
- **Test:** `dotnet cake --target=Test`
- **Pack:** `dotnet cake --target=Pack`
- **Publish:** `dotnet cake --target=Publish`

## 📁 Repository Structure
- `demo/`: Showcases module usage examples.
- `resources/`: Assets (logos, icons, schemas, styles).
- `tests/`: Module unit tests (one project per module).
- `tools/`: Tooling projects (e.g., XML doc markdown generators).
- `modules/`: Contains `CatModuleReadmeTemplate.md`, and individual module-folders.

## 📦 Module Folder Blueprint
Each module directory contains its C# projects, an auto-generated `namespaces/` markdown folder, and a local `README.md`.

### Root `README.md` Rules
- Acts as the documentation entry point.
- The module list section is strictly enclosed within:
  `<!-- Modules start -->` and `<!-- Modules end -->`

### Module `README.md` & Template Rules
When creating or updating a module readme, use `modules/CatModuleReadmeTemplate.md`. Inject data into these exact block/placeholder markers:

1. **`[[ModuleName]]`**: The name of the module-folder.
2. **Intro Block**: `<!-- Intro start -->[[Intro]]<!-- Intro end -->` (Brief overview).
3. **NuGet Block**: `<!-- NuGet start -->` / `<!-- NuGet end -->`
   - Every project in the module has a package named `gmarginet.` followed by the root namespace of the project.
   - Start with one version badge for the main package (the package named like the module). If no project is named like the module, use the first project instead. All packages of a module share the same version.
   - Add a table with the columns `Package`, `Role`, `Install` and `Downloads`, and one row per project.
   - Row format: `| [[[NamespaceName]]](https://www.nuget.org/packages/gmarginet.[[NamespaceName]]/) | [[PackageRole]] | `dotnet add package gmarginet.[[NamespaceName]]` | ![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.[[NamespaceName]]) |`
   - `[[PackageRole]]` is a short label such as `Contracts`, `Implementation` or `Optional decorator`.
4. **Namespaces Block**: `<!-- Namespaces start -->` / `<!-- Namespaces end -->`
   - Add a table with the columns `Namespace` and `What it holds`, and one row per project.
   - Row format: `| [[[NamespaceName]]](namespaces/[[NamespaceName]]/index.md) | [[NamespaceDescription]] |`
   - `[[NamespaceDescription]]` is one short sentence, based on the namespace summary.
5. **Dependencies Block**: `<!-- Dependencies start -->` / `<!-- Dependencies end -->`
   - Add a table with the columns `Module` and `Why [[ModuleName]] needs it`, and one row per dependency.
   - Row format: `| [[[DependentModuleName]]](../[[DependentModuleName]]/README.md) | [[DependencyReason]] |`
   - No dependencies? Skip the table and write `[[ModuleName]] has no dependencies on other CAT modules.` followed by two trailing spaces.
6. **Usage Block**: `<!-- Usage start -->[[Usage]]<!-- Usage end -->` (Code examples).

Also keep the table of contents up-to-date with the chapters that exist in the readme, ignore the chapters marked with `<!-- omit in toc -->`

## 🤖 Automation Rules
@.claude/rules-readme.md

## ✍️ Documentation & Comment Style
When writing, modifying, or generating code comments, XML documentation, or markdown files, strictly adhere to these natural language rules:

- **Tone:** Use a human-centric, plain, conversational, and direct tone. Write as an empathetic peer, avoiding overly technical jargon unless absolutely necessary.
- **Punctuation:** NEVER use long dashes (`—` or `--`), ellipses (`...`), or decorative markdown wrappers. Stick to standard sentences.
- **Structure:** Write in the active voice with short, punchy sentences. Use concise bullet fragments instead of sprawling text walls.
- **XML Docs:** Keep C# XML `<summary>` tags descriptive but grounded. Do not write generic preambles like *"This method is used to..."*—start immediately with the action (e.g., *"Calculates the module layout boundaries."*).
