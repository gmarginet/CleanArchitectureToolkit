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
- Commit one topic per commit, and only when asked. Do not mix renames, new content and tooling in one commit.
- Always use the `cat-internal-commit` skill to commit, never a bare `git commit`. It splits the changes into logical commits and ends the subject with ` (skip-pub)` when a commit changes no code in `modules/`. Build files and `tools/` count as code.

## Tools & Capabilities
- **Roslyn MCP Connected:** Use `cwm-roslyn-navigator` tools for deep codebase indexing, finding references, tracking hierarchies, and listing symbols.
- Avoid reading entire large source files directly via standard shell tools; query the Roslyn MCP server instead to optimize token usage.

## Working with the owner
- The owner decides design. Propose options with their costs and a recommendation, and do not decide on your own. Write down only what the owner decided. Open points go in the plan as open questions.
- CAT is a toolbox. A developer picks the modules and the projects they want, and a module never forces another one on them.
- A module splits into an `Abstractions` project, the implementation and optional parts such as decorators. The core of a service only references abstractions.
- Modules never depend on Aspire or on the demo `ServiceDefaults`.
- Sharing the `Contracts` project of a service is the developer's choice, not a rule.
- Module projects target `netstandard2.0` as much as possible. A project that needs more, such as one that uses ASP.NET Core or EF Core, targets the latest stable .NET. Check this when you add a project.
- A shared abstraction lives in the `Abstractions` project of the module that owns it, such as `ICatUser` in `Cat.Authorization.Abstractions`.

## Environment Constraints
- Do NOT use Python scripts or bash utilities (`sed` and the like) for file manipulation or automation.
- Use native PowerShell commands or the .NET CLI for all tasks.
- If you need to search or parse files, prefer native `dotnet` tools, PowerShell, or Roslyn MCP capabilities over third-party scripts.
- Keep the line endings of a file. `.gitattributes` stores text as LF, and only `*.ps1`, `*.cmd` and `*.bat` are CRLF. Git may warn that LF will be replaced by CRLF in the working copy. Change only the lines you mean to change, and check with `git diff --stat` that the diff is not the whole file.
- Rename and move with `git mv`. Search the old name with `git grep` and fix every reference in the same change.
- Never name a PowerShell helper function like an alias, such as `R`, `Rd` or `Rm`. The alias wins and runs instead of the function, and it can delete real files.

## 📁 Repository Structure
- `demo/`: Showcases module usage examples.
- `resources/`: Assets (logos, icons, schemas, styles).
- `tests/`: Module unit tests (one project per module).
- Demo service tests live in the service folder in `demo/`, as `ServiceName.CoreService.Tests`. `dotnet cake --target=Test` runs every `*.Tests.csproj` under `tests/` and `demo/`.
- `tools/`: Tooling projects (e.g., XML doc markdown generators).
- `modules/`: Contains the individual module-folders.
- `plans/`: Plans for the demo, the tooling and the modules.

## 📦 Module Folder Blueprint
Each module directory contains its C# projects, an auto-generated `namespaces/` markdown folder, and a local `README.md`.

### Generated Files
- Never edit the files in `modules/*/namespaces/` by hand or with a script (sed and the like). They are generated.
- To change them, change the XML docs, the generator (`tools/Cat.DefaultDocumentationPlugin/`) or the template, then follow the `cat-internal-verify-code` skill. Only a `Debug` build regenerates them.

## 🚀 Release
- Releases are automatic after a push to `master`. `.github/workflows/build.yml` runs the tests and publishes the NuGet packages, with the version from MinVer and the `v` git tags. `.github/workflows/pages.yml` builds the GitHub Pages site from the markdown.
- A commit message with `skip-ci` skips the build workflow. `skip-pub` runs only the tests and does not publish. The `cat-internal-commit` skill adds ` (skip-pub)` to commits without code in `modules/`.
- This is why you never push unless asked.

## 🧩 Skills
Use the skill for the task and do not do its steps by hand.

- Prefix `cat-internal-` is for skills for the owner of the toolkit. Prefix `cat-` is for skills for developers who use the toolkit.
- When you add, rename, change or remove a skill in `.claude/skills/`, update the table and the entry for it in `.claude/skills/README.md` in the same change.
- Plans: put only decisions the owner made in the description of a phase, and everything else is an open question. Remove a plan only when the owner agrees.
- The demo readme describes only what exists. Plans stay in `plans/Demo.md`.
- Template files: load `cat-internal-template-concepts` first. Never remove a region marker, and edit only inside a region.

| Task | Skill |
|---|---|
| Commit | `cat-internal-commit` |
| Plans | `cat-internal-create-plan` |
| Readme, repo overview table | `cat-internal-create-readme` |
| Module readme | `cat-internal-create-module-readme` |
| Demo readme, demo drawing | `cat-internal-create-demo-readme` |
| New module | `cat-internal-create-module` |
| Demo project or folder | `cat-internal-create-demo-unit` |
| Header of a template file | `cat-internal-create-header` |
| New template | `cat-internal-create-template` |
| Excalidraw drawing (architecture, flow) | `cat-internal-create-excalidraw` |
| Mermaid diagram (ERD, UML, sequence) | `cat-internal-create-mermaid` |
| After changes to code, XML docs or the generator | `cat-internal-verify-code` |
| After changes to markdown, a heading or a file name, and after every rename or move | `cat-internal-verify-docs` |
| Link check, only when the owner asks | `cat-internal-verify-site` |
## ✍️ Documentation & Comment Style
When writing, modifying, or generating code comments, XML documentation, or markdown files, strictly adhere to these natural language rules:

- **Tone:** Use a human-centric, plain, conversational, and direct tone. Write as an empathetic peer, avoiding overly technical jargon unless absolutely necessary.
- **Punctuation:** NEVER use long dashes (`—` or `--`), ellipses (`...`), or decorative markdown wrappers. Stick to standard sentences.
- **Structure:** Write in the active voice with short, punchy sentences. Use concise bullet fragments instead of sprawling text walls.
- **XML Docs:** Keep C# XML `<summary>` tags descriptive but grounded. Do not write generic preambles like *"This method is used to..."*—start immediately with the action (e.g., *"Calculates the module layout boundaries."*).
- **Readme:** "the readme" is `README.md` in the root of the repository. Never write "root readme". The other readmes always get a qualifier: a module readme (`modules/<ModuleName>/README.md`) or the demo readme (`demo/README.md`).
- **Words for people:** Use the same word for the same person in every skill, template, plan, readme and XML doc.
  - **Owner:** the person who owns the toolkit and decides the design. Never "author".
  - **Claude:** the assistant.
  - **Developer:** a person who uses the toolkit modules in their own application.
  - **User:** a person who uses an application built with the toolkit, such as the demo app. Never use "user" for a developer.