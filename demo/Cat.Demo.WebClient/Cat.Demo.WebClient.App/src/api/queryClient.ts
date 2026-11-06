import { QueryClient } from '@tanstack/react-query'
import { ApiError } from './errors'

/** A call that the service refused, such as a 404, is not retried. A call that got no answer or a 5xx is, twice. */
export function createQueryClient(): QueryClient {
  return new QueryClient({
    defaultOptions: {
      queries: {
        retry: (failureCount, error) => {
          const refused = error instanceof ApiError && error.status >= 400 && error.status < 500
          return !refused && failureCount < 2
        },
        staleTime: 30_000,
      },
    },
  })
}
