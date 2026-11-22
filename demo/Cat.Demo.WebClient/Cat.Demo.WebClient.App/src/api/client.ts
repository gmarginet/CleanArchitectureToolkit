import createClient, { type Middleware } from 'openapi-fetch'
import { getAccessToken } from '../auth/accessToken'
import { currentLanguage } from '../i18n'
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

/**
 * Sends the language of the person with every call, so the services answer in it. The gateway passes the header on
 * as it is, and each service picks English or Dutch from it. Before the person picks a language, the language of
 * the browser applies, see i18n.ts.
 */
export const acceptLanguage: Middleware = {
  onRequest({ request }) {
    request.headers.set('Accept-Language', currentLanguage())
    return request
  },
}

// Every call goes through the gateway. The types come from the OpenAPI document of each service,
// see `npm run api:generate`.
export const catalogApi = createClient<CatalogPaths>({ baseUrl: gatewayUrl })
catalogApi.use(bearerToken, acceptLanguage)

export const ordersApi = createClient<OrdersPaths>({ baseUrl: gatewayUrl })
ordersApi.use(bearerToken, acceptLanguage)
