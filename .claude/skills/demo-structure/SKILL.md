---
name: demo-structure
description: Add or restructure a deployable unit in demo/ (service, client, Aspire AppHost or Aspire ServiceDefaults) and keep CleanArchitectureToolkit.slnx in sync. Use when a demo project is added, moved or renamed.
argument-hint: "[service|client|apphost|servicedefaults] [Name]"
---

# Demo structure

Every deployable unit in `demo/` gets its own folder. Never put project folders directly in `demo/`.

## Folder rules
- **Services:** one folder per service. It holds all projects of that service, as described in the Service Project structure chapter of the root `README.md`: Api, CoreService, Infrastructure, Contracts, DataModels and the optional ones. Read that chapter first.
- **Clients:** one folder per client.
- **Aspire AppHosts:** one folder per AppHost.
- **Aspire ServiceDefaults:** one folder per ServiceDefaults project.
- Each project sits in its own subfolder inside the folder of its service, client or Aspire project.
- `demo/` itself only holds shared files like `Directory.Build.props` and `README.md`.

Example, from the Todo service:

```
demo/
  Cat.Demo.TodoService/
    Cat.Demo.TodoService.Api/
    Cat.Demo.TodoService.Contracts/
    Cat.Demo.TodoService.DataModels/
    Cat.Demo.TodoService.Infrastructure/
    Cat.Demo.ToDoService.Core/
```

## Solution file
Mirror the structure in `CleanArchitectureToolkit.slnx`.
- Each unit folder is a solution folder: `<Folder Name="/demo/Cat.Demo.TodoService/">`.
- Each project is a `<Project Path="demo/<Unit>/<Project>/<Project>.csproj" />` entry inside it, sorted by path.
- When you move, rename or add a project, update the paths in the solution file in the same change.
- Keep the `/demo/` folder entry with `demo/Directory.Build.props`.

## Steps
1. Read the Service Project structure chapter in the root `README.md` and `demo/DemoPlan.md`.
2. Decide which projects the unit needs. Start from the required ones and add optional ones only when the plan asks for them.
3. Create the folders and project files. Use `dotnet new` or copy a project from an existing unit.
4. Move files with `git mv` so the history stays intact.
5. Update the project references and `CleanArchitectureToolkit.slnx`.
6. Run `dotnet cake --target=Build` to check that everything still builds. The `cat-verify` skill does this and reports the result.
7. Update `demo/README.md` if the list of demo units changes.
