import { useMutation, useQueryClient } from '@tanstack/react-query'
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
