// Crawls the published GitHub Pages and reports broken links.
//
// Usage: node .claude/scripts/check-links.mjs [baseUrl] [--external]
//
// - Follows every internal page, and checks pages, images, styles and #anchors.
// - Anchors count both id="..." and name="..." (the code reference pages use <a name>).
// - With --external it also checks external links once each.
//   It skips learn.microsoft.com API pages and shields.io badges, to avoid hammering them.
const args = process.argv.slice(2);
const checkExternal = args.includes('--external');
const base = args.find((a) => !a.startsWith('--')) ?? 'https://gmarginet.github.io/CleanArchitectureToolkit/';
const origin = new URL(base).origin;

const pages = new Map(); // url -> { status, ids, html }
const files = new Map(); // non page url -> status
const queue = [base];
const broken = [];
const brokenAnchors = [];
const externals = new Set();
const checked = new Set();

async function get(url, options = {}) {
  for (let i = 0; i < 3; i++) {
    try {
      return await fetch(url, { redirect: 'follow', ...options });
    } catch {
      // Retry, then fall through to a fake failed response.
    }
  }
  return { status: 0, headers: new Headers(), text: async () => '' };
}

async function loadPage(url) {
  if (pages.has(url)) return pages.get(url);
  const response = await get(url);
  const info = { status: response.status, ids: new Set(), html: '' };
  if (response.status === 200 && (response.headers.get('content-type') || '').includes('html')) {
    info.html = await response.text();
    for (const m of info.html.matchAll(/\s(?:id|name)="([^"]+)"/g)) info.ids.add(m[1]);
  }
  pages.set(url, info);
  return info;
}

while (queue.length) {
  const batch = queue.splice(0, 10);
  await Promise.all(batch.map(async (url) => {
    const info = await loadPage(url);
    if (info.status !== 200) {
      broken.push(`${info.status} ${url}`);
      return;
    }

    for (const m of info.html.matchAll(/<(?:a|link|img|script)\s[^>]*?(?:href|src)="([^"]*)"/g)) {
      const href = m[1].replace(/&amp;/g, '&');
      if (!href || href.startsWith('mailto:') || href.startsWith('data:')) continue;

      let abs;
      try { abs = new URL(href, url); } catch { continue; }
      if (abs.origin !== origin) {
        externals.add(abs.href);
        continue;
      }

      const hash = abs.hash;
      abs.hash = '';
      const target = abs.href;
      const key = `${url} -> ${target}${hash}`;
      if (checked.has(key)) continue;
      checked.add(key);

      const isPage = /\/$|\.html$/.test(abs.pathname);
      if (isPage && !pages.has(target) && !queue.includes(target)) queue.push(target);

      if (!isPage) {
        if (!files.has(target)) files.set(target, (await get(target)).status);
        if (files.get(target) !== 200) broken.push(`${files.get(target)} ${target} (from ${url})`);
        continue;
      }

      const targetInfo = await loadPage(target);
      if (targetInfo.status !== 200) {
        broken.push(`${targetInfo.status} ${target} (from ${url})`);
      } else if (hash.length > 1 && !targetInfo.ids.has(decodeURIComponent(hash.slice(1)))) {
        brokenAnchors.push(`${url} -> ${target}${hash}`);
      }
    }
  }));
}

const brokenExternal = [];
if (checkExternal) {
  const toCheck = [...externals].filter((u) => !/learn\.microsoft\.com\/en-us\/dotnet\/api|img\.shields\.io/.test(u));
  for (const url of toCheck) {
    const response = await get(url, { headers: { 'User-Agent': 'Mozilla/5.0' }, signal: AbortSignal.timeout(20000) });
    if (response.status !== 200) brokenExternal.push(`${response.status} ${url}`);
    await new Promise((resolve) => setTimeout(resolve, 500));
  }
  console.log(`External links checked: ${toCheck.length}`);
}

const pageCount = [...pages.values()].filter((p) => p.html).length;
console.log(`Pages crawled: ${pageCount}`);
console.log(`Internal links checked: ${checked.size}`);
console.log(`Broken internal links: ${[...new Set(broken)].length}`);
for (const line of new Set(broken)) console.log(`  ${line}`);
console.log(`Broken anchors: ${[...new Set(brokenAnchors)].length}`);
for (const line of new Set(brokenAnchors)) console.log(`  ${line}`);
if (checkExternal) {
  console.log(`Broken external links: ${brokenExternal.length}`);
  for (const line of brokenExternal) console.log(`  ${line}`);
}

process.exitCode = broken.length || brokenAnchors.length || brokenExternal.length ? 1 : 0;
