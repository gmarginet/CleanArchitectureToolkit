# Rule: Dotnet Module Readme Generation
**Trigger:** Creating or modifying any README.md file inside the `modules/` directory.

**Requirements:**
- Always read the latest `modules/CatModuleReadmeTemplate.md` first.
- Replace [[ModuleName]], [[Intro]], [[Usage]], [[NamespaceName]], [[PackageRole]], [[NamespaceDescription]], [[DependentModuleName]], and [[DependencyReason]].
- Copy the header table from the template unchanged. Its links and image path already fit the module folder depth.
- In the header table, keep the Markdown menu line and the closing `</td>`, `</tr>` and `</table>` tags at column 0. Indented tags show up as text in some previewers.
- The NuGet, Namespaces, and Dependencies blocks are tables. Fill one row per project or dependency.
- Always wrap a badge in a link (NuGet page, workflow page or module readme). GitHub turns an unlinked image into a link to a blank page with only the badge.
- The NuGet version badge uses the package named like the module. If there is none, use the first project.
- A module without dependencies gets the sentence `[[ModuleName]] has no dependencies on other CAT modules.` instead of the Dependencies table.
- Enforce the precise comment boundaries (`<!-- Start -->` / `<!-- End -->`) and use the exact markdown link formats specified in CLAUDE.md.
- Keep the table of contents up-to-date with the chapters that exist in the readme, ignore the chapters marked with `<!-- omit in toc -->`

# Rule: Root Readme Module Table
**Trigger:** Updating the module table in the root `README.md`, adding or removing a module, or putting a module in or out of development.

**Requirements:**
- Follow the Root `README.md` Rules in CLAUDE.md. Edit only between `<!-- Modules start-->` and `<!-- Modules end-->`.
- Add one row per module folder in `modules/`, sorted by name. Write the description from the intro of the module readme.
- Put a module in development: put the In development badge in the status cell (the column without a header) of its row.
- Make a module stable: empty the status cell of its row.
- Never remove the note above the table or the badge snippet comment inside the markers.
