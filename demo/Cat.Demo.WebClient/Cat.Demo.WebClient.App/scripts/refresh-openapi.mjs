// Saves the OpenAPI document of each service into the api folder, so the types can be generated without a running
// service. Start the AppHost first. The services only publish the document in Development, which the AppHost uses.
// Run it with `npm run api:refresh` and commit the changed files.
import { mkdir, writeFile } from 'node:fs/promises'

const documents = [
  { name: 'catalog', url: process.env.CATALOG_OPENAPI_URL ?? 'http://localhost:5101/openapi/v1.json' },
  { name: 'orders', url: process.env.ORDERS_OPENAPI_URL ?? 'http://localhost:5102/openapi/v1.json' },
]

await mkdir('api', { recursive: true })

for (const { name, url } of documents) {
  const response = await fetch(url)
  if (!response.ok) {
    throw new Error(`${name}: ${url} answered ${response.status}. Is the AppHost running?`)
  }
  const document = await response.json()
  await writeFile(`api/${name}.openapi.json`, `${JSON.stringify(document, null, 2)}\n`)
  console.log(`${name}: saved api/${name}.openapi.json`)
}
