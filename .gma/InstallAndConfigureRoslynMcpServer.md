# Install the Roslyn MCP Server via .NET CLI

Run the following command in a PowerShell terminal:
```powershell
dotnet tool install -g CWM.RoslynNavigator
```

# Register it with Claude Code

Run the following command in a PowerShell terminal:
```powershell
claude mcp add --scope user cwm-roslyn-navigator -- cwm-roslyn-navigator
```

# Update your claude.md

Add the following lines to your claude.md
```markdown
## Tools & Capabilities
- **Roslyn MCP Connected:** Use `cwm-roslyn=navigator` tools for deep codebase indexing, finding references, tracking hierarchies, and listing symbols.
- Avoid reading entire large source files directly via standard shell tools; query the Roslyn MCP server instead to optimize token usage.
```