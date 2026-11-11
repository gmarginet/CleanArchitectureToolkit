---
name: cat-internal-verify-site
description: Crawl the published GitHub Pages site and report broken pages, files and anchors. Only run it when the owner asks for it, because it sends thousands of requests.
argument-hint: "[--external]"
disable-model-invocation: true
allowed-tools: Bash(node .claude/skills/cat-internal-verify-site/check-links.mjs:*), PowerShell(node .claude/skills/cat-internal-verify-site/check-links.mjs:*)
---

# Link check

Run the link checker against the published site at https://gmarginet.github.io/CleanArchitectureToolkit/.

## Before you run
- It checks what is published, not your working tree. The latest push must be published first. If there are unpushed commits, tell the owner and ask if they still want to run it.
- Never push for the owner.

## Steps
1. Run `node .claude/skills/cat-internal-verify-site/check-links.mjs`. Add `--external` when the owner asks for external links too.
2. Wait for it to finish. A full crawl takes a while.
3. Group the findings: broken pages, broken files, broken anchors, and external links if checked.
4. For each finding, find the source file in the repo that holds the link, when you can.
5. Report the findings. Do not fix anything unless the owner asks.

## Notes
- Anchors count both `id="..."` and `name="..."`.
- With `--external` the script skips learn.microsoft.com API pages and shields.io badges.
- If everything is fine, say so in one line.
