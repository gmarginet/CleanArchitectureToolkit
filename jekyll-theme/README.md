# CAT Jekyll theme

Jekyll theme for the Clean Architecture Toolkit GitHub Pages.

- Renders markdown like the dark mode preview of Visual Studio Code.
- Keeps the dashed heading lines and full width tables from `resources/styles/style.css`.
- Adds no header text of its own, so the header table of each readme is the only header.
- Shows a `View on GitHub` button in a slim top bar.
- Sets the favicon and the touch icon from `resources/icon`.
- Opens the links to nuget.org packages in a new tab.
- Adds a copy button to every code block and to the install command in the package tables.
- Counts page views with GoatCounter when `goatcounter_endpoint` or `goatcounter` is set in `_config.yml`. The footer then says so. Without one of them the theme loads no script and shows no privacy line.

## How it is used

- `Gemfile` loads it as a path gem: `gem "cat-theme", path: "jekyll-theme"`.
- `_config.yml` turns it on with `theme: cat-theme` and excludes this folder from the site.
- The GitHub link comes from `jekyll-github-metadata`, with `github_url` in `_config.yml` as fallback.
- `goatcounter_endpoint` in `_config.yml` is the address that gets the page views, such as an own proxy that passes them on to GoatCounter. The script adds the query to it, so it has no question mark.
- `goatcounter` in `_config.yml` is the site code of the GoatCounter account, such as `cat-toolkit`. The count goes to `https://<code>.goatcounter.com/count`. It is only used when `goatcounter_endpoint` is empty.
- The page loads its own copy of the GoatCounter script, so no request goes to a third party for the file. GoatCounter allows this and keeps the `/count` endpoint compatible. A new version of the script is only needed for new features.

## Files

| File | Purpose |
| --- | --- |
| `_layouts/default.html` | Page skeleton with the top bar and the content. |
| `assets/css/cat-theme.css` | All colors and styles. |
| `assets/js/count.js` | The GoatCounter script, copied from `https://gc.zgo.at/count.js`. It is released under the ISC license. |
| `cat-theme.gemspec` | Makes the folder a gem that Jekyll can load as a theme. |
