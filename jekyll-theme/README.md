# CAT Jekyll theme

Jekyll theme for the Clean Architecture Toolkit GitHub Pages.

- Renders markdown like the dark mode preview of Visual Studio Code.
- Keeps the dashed heading lines and full width tables from `resources/styles/style.css`.
- Adds no header text of its own, so the header table of each readme is the only header.
- Shows a `View on GitHub` button in a slim top bar.

## How it is used

- `Gemfile` loads it as a path gem: `gem "cat-theme", path: "jekyll-theme"`.
- `_config.yml` turns it on with `theme: cat-theme` and excludes this folder from the site.
- The GitHub link comes from `jekyll-github-metadata`, with `github_url` in `_config.yml` as fallback.

## Files

| File | Purpose |
| --- | --- |
| `_layouts/default.html` | Page skeleton with the top bar and the content. |
| `assets/css/cat-theme.css` | All colors and styles. |
| `cat-theme.gemspec` | Makes the folder a gem that Jekyll can load as a theme. |
