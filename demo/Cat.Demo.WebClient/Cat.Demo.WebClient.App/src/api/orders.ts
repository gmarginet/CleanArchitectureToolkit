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

/** How often a pending order is asked for again, in milliseconds. */
export const pendingPollInterval = 2000

/**
 * One order. While the status is Pending, the order is asked for again every few seconds, because the payment
 * is taken in the background. The polling stops when the status changes, so a confirmed or cancelled order is not asked for again.
 */
export function useOrder(orderId: string, enabled: boolean) {
  return useQuery({
    queryKey: ['orders', orderId],
    enabled,
    queryFn: () => unwrap(ordersApi.GET('/orders/{orderId}', { params: { path: { orderId } } })),
    refetchInterval: (query) => (query.state.data?.status === pendingStatus ? pendingPollInterval : false),
  })
}

/** Cancels an order. A conflict, such as an order that is already paid and shipped, shows as an error. */
export function useCancelOrder(orderId: string) {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: () => unwrap(ordersApi.POST('/orders/{orderId}/cancel', { params: { path: { orderId } } })),
    onSuccess: () => queryClient.invalidateQueries({ queryKey: ['orders'] }),
  })
}
