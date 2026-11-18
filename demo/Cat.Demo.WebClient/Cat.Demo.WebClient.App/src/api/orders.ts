import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { ordersApi } from './client'
import { unwrap } from './errors'

export interface OrderLineInput {
  bookId: string
  quantity: number
}

/**
 * Places an order. The client sends only the book and the quantity. The server decides the price, the stock
 * and the payment. A failed order is never retried by itself, so a customer cannot be charged twice by a retry.
 */
export function usePlaceOrder() {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: (lines: OrderLineInput[]) => unwrap(ordersApi.POST('/orders', { body: { lines } })),
    onSuccess: () => queryClient.invalidateQueries({ queryKey: ['orders'] }),
  })
}

/** The orders of the logged in person. Only the caller's own orders come back. */
export function useOrders(enabled: boolean) {
  return useQuery({
    queryKey: ['orders'],
    enabled,
    queryFn: () => unwrap(ordersApi.GET('/orders')),
  })
}

/** The status of an order that waits for its payment. The shop answers 202 Accepted with this status. */
export const pendingStatus = 'Pending'

/** The status of an order that is paid and waits to be shipped. The shop ships it a few minutes later. */
export const confirmedStatus = 'Confirmed'

/** How often a pending order is asked for again, in milliseconds. */
export const pendingPollInterval = 2000

/** How often a confirmed order is asked for again, in milliseconds. The shop ships a confirmed order within minutes, so this can be slower. */
export const confirmedPollInterval = 10000

/** Gives the time to the next poll of an order with this status, or false when the status is final. */
export function orderPollInterval(status: string | undefined): number | false {
  if (status === pendingStatus) {
    return pendingPollInterval
  }
  return status === confirmedStatus ? confirmedPollInterval : false
}

/**
 * One order. A Pending order is asked for again every few seconds, because the payment is taken in the background.
 * A Confirmed order is asked for again every 10 seconds, until it is shipped. The polling stops when the status is
 * Shipped or Cancelled, so a final order is not asked for again.
 */
export function useOrder(orderId: string, enabled: boolean) {
  return useQuery({
    queryKey: ['orders', orderId],
    enabled,
    queryFn: () => unwrap(ordersApi.GET('/orders/{orderId}', { params: { path: { orderId } } })),
    refetchInterval: (query) => orderPollInterval(query.state.data?.status),
  })
}

/** Cancels an order. A conflict, such as an order that was shipped a moment ago, shows as an error. */
export function useCancelOrder(orderId: string) {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: () => unwrap(ordersApi.POST('/orders/{orderId}/cancel', { params: { path: { orderId } } })),
    onSuccess: () => queryClient.invalidateQueries({ queryKey: ['orders'] }),
  })
}
