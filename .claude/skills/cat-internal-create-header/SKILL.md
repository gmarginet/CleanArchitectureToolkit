---
name: cat-internal-create-header
description: Create or update the header of a template-based markdown file (stylesheet link, banner table and navigation bar) from header.template.md. Updates every file that uses the header when the header template changes. Use when a new file gets its header, or when the owner changes the header template.
argument-hint: "[create|update] [file]"
---

# Header

The header is the banner and the navigation bar at the top of the markdown files that are created from a template, such as the plans. It is written once in [header.template.md](header.template.md), so no template repeats it.

Load the `cat-internal-template-concepts` skill first. It explains regions and placeholders.

## Rules
- A template that wants the header holds an empty `Header` region at the top of the file that it creates.
- The template file holds the `Header` region. Its first line is the comment line that names the template and the `RootPath`. The comment line stays in the created file. It is how Claude finds every file that uses the header.
- A new template that wants the header only needs the empty `Header` region and a pointer to this skill.

## Create
1. Open [header.template.md](header.template.md) and copy the whole `Header` region, including the region markers and the comment line.
2. Replace `[[RootPath]]` everywhere in the copy with the relative path from the new file to the repository root.
3. Put the copy in the empty `Header` region at the top of the new file.
4. Run the `cat-internal-verify-docs` skill.

## Update
Use this when the owner changes the header template and asks to update the files that use it.
1. Find the files with `git grep --untracked -l "Header template: @"`. Skip the files in the `.claude` folder. They only describe the header.
2. Read the `RootPath` from the comment line of each file.
3. Replace the whole `Header` region with the `Header` region of the template, using that `RootPath`.
4. Update the generated pages too, see [Generated pages](#generated-pages).
5. Run the `cat-internal-verify-docs` skill. It reports every `Header` region that differs from the template. It does not check the generated pages.

## Generated pages
The pages in `modules/*/namespaces` have the same header, but they are generated. The generator holds its own copy of the header in `tools/Cat.DefaultDocumentationPlugin/CatHeaderSection.cs`. Use this when the header template changes.
1. Make the same change in `CatHeaderSection.cs`. The generator builds the header lines in code, with the paths of a generated page.
2. Run `tools\Cat.DefaultDocumentationPlugin\BuildAndDeployPlugin.cmd`. It copies the plugin DLLs to `resources/defaultDocumentationPlugins/`.
3. Run `dotnet cake --target=Build --configuration=Debug`. Only a Debug build regenerates the pages.
4. Check the diff of the pages. Every page should differ only in the changed header line.
5. Never edit the generated pages by hand.
6. Commit the change to `tools/`, the DLLs and the regenerated pages together. The commit changes code, so it gets no ` (skip-pub)`. A push to `master` publishes the NuGet packages.
## Placeholders
- [[RootPath]]: The relative path from the file to the root of the repository.
  - It is `..` for a file in the `plans` folder.
  - It never ends with a slash.
