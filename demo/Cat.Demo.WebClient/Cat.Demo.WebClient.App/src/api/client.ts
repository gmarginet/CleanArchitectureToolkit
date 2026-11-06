import createClient from 'openapi-fetch'
import type { paths } from './catalog.schema'

// The AppHost sets VITE_GATEWAY_URL. The fallback is the gateway of a plain local run.
export const gatewayUrl: string = import.meta.env.VITE_GATEWAY_URL ?? 'http://localhost:5100'

// Every call goes through the gateway. The types come from the OpenAPI document of the service,
// see `npm run api:generate`.
export const catalogApi = createClient<paths>({ baseUrl: gatewayUrl })
