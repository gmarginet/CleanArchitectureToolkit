import createClient, { type Middleware } from 'openapi-fetch'
import { getAccessToken } from '../auth/accessToken'
import type { paths as CatalogPaths } from './catalog.schema'
import type { paths as OrdersPaths } from './orders.schema'

// The AppHost sets VITE_GATEWAY_URL. The fallback is the gateway of a plain local run.
export const gatewayUrl: string = import.meta.env.VITE_GATEWAY_URL ?? 'http://localhost:5100'

/** Sends the access token with every call when a person is logged in. */
export const bearerToken: Middleware = {
  onRequest({ request }) {
    const token = getAccessToken()
    if (token) {
      request.headers.set('Authorization', `Bearer ${token}`)
    }
    return request
  },
}

// Every call goes through the gateway. The types come from the OpenAPI document of each service,
// see `npm run api:generate`.
export const catalogApi = createClient<CatalogPaths>({ baseUrl: gatewayUrl })
catalogApi.use(bearerToken)

export const ordersApi = createClient<OrdersPaths>({ baseUrl: gatewayUrl })
ordersApi.use(bearerToken)
