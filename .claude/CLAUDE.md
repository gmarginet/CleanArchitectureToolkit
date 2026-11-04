# Clean Architecture Toolkit (`CLAUDE.md`)

Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications embracing SOLID principles for maintainability, testability, and scalability.

## 🛠️ Essential Commands
All workflows utilize Cake. Execute via the root `./build.sh` or `.\build.ps1`:
- **Clean:** `dotnet cake --target=Clean`
- **Build:** `dotnet cake --target=Build`
- **Test:** `dotnet cake --target=Test`
- **Pack:** `dotnet cake --target=Pack`
- **Publish:** `dotnet cake --target=Publish`
- **Namespace docs:** `dotnet cake --target=Build --configuration=Debug`. The default configuration is `Release`, and the namespace pages are only generated in `Debug`. Use this when you change code, XML docs, the generator or the template.

The `Test` target always runs the `Release` build, so `--configuration=Debug` only makes sense for `Build`. A `dotnet build` of a single project in `Debug` fails in the documentation step, so build through Cake or the solution.

## 🌿 Git Workflow
- Commit directly to the branch that is currently checked out, even when it is `master`.
- Never create a branch on your own. The owner creates feature branches before starting work when they want one.
- Do not push unless asked.

## Tools & Capabilities
- **Roslyn MCP Connected:** Use `cwm-roslyn-navigator` tools for deep codebase indexing, finding references, tracking hierarchies, and listing symbols.
- Avoid reading entire large source files directly via standard shell tools; query the Roslyn MCP server instead to optimize token usage.

## Environment Constraints
- Do NOT use Python scripts or bash utilities for file manipulation or automation.
- Use native PowerShell commands or the .NET CLI for all tasks.
- If you need to search or parse files, prefer native `dotnet` tools, PowerShell, or Roslyn MCP capabilities over third-party scripts.

## 📁 Repository Structure
- `demo/`: Showcases module usage examples.
- `resources/`: Assets (logos, icons, schemas, styles).
- `tests/`: Module unit tests (one project per module).
- Demo service tests live in the service folder in `demo/`, as `ServiceName.CoreService.Tests`. `dotnet cake --target=Test` runs every `*.Tests.csproj` under `tests/` and `demo/`.
- `tools/`: Tooling projects (e.g., XML doc markdown generators).
- `modules/`: Contains `CatModuleReadmeTemplate.md`, and individual module-folders.

### Demo Folder Structure
Every deployable unit in `demo/` gets its own folder. Never put project folders directly in `demo/`.
Use the `demo-structure` skill to add or restructure demo projects. It also keeps `CleanArchitectureToolkit.slnx` in sync.

## 📦 Module Folder Blueprint
Each module directory contains its C# projects, an auto-generated `namespaces/` markdown folder, and a local `README.md`.

### Generated Files
- Never edit the files in `modules/*/namespaces/` by hand or with a script (sed and the like). They are generated.
- To change them, change the XML docs, the generator (`tools/Cat.DefaultDocumentationPlugin/`) or the template, then run `dotnet cake --target=Build --configuration=Debug`. A plain `dotnet cake --target=Build` builds `Release` and does not regenerate them.
- After the build, check the diff of the regenerated pages to confirm the change is what you expect.

### Readmes
- Use the `module-readme` skill when you create or change a module `README.md`. It follows `modules/CatModuleReadmeTemplate.md`.
- Use the `root-module-table` skill when you change the module table in the root `README.md`.
- Never remove the `<!-- Modules start-->` and `<!-- Modules end-->` markers in the root `README.md`.
- Use the `new-module` skill to start a new module.

## 📐 Drawings
- Architecture and flow drawings are Excalidraw. Use the `excalidraw-svg` skill.
- ERD, UML class and sequence diagrams are Mermaid, inline in markdown. Use the `mermaid-diagram` skill.

## 🔗 Link Check
- Use the `link-check` skill, and only when the owner asks for it. It sends thousands of requests.

## 🧩 Skills
- When you add, rename, change or remove a skill in `.claude/skills/`, update the table and the entry for it in `.claude/skills/README.md` in the same change.

## ✍️ Documentation & Comment Style
When writing, modifying, or generating code comments, XML documentation, or markdown files, strictly adhere to these natural language rules:

- **Tone:** Use a human-centric, plain, conversational, and direct tone. Write as an empathetic peer, avoiding overly technical jargon unless absolutely necessary.
- **Punctuation:** NEVER use long dashes (`—` or `--`), ellipses (`...`), or decorative markdown wrappers. Stick to standard sentences.
- **Structure:** Write in the active voice with short, punchy sentences. Use concise bullet fragments instead of sprawling text walls.
- **XML Docs:** Keep C# XML `<summary>` tags descriptive but grounded. Do not write generic preambles like *"This method is used to..."*—start immediately with the action (e.g., *"Calculates the module layout boundaries."*).
