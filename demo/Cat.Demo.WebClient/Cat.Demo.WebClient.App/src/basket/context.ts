import { createContext } from 'react'
import type { BasketLine } from './basketState'

export interface Basket {
  lines: BasketLine[]
  /** The number of copies in the basket. */
  count: number
  total: number
  add: (book: Omit<BasketLine, 'quantity'>) => void
  setQuantity: (bookId: string, quantity: number) => void
  remove: (bookId: string) => void
  clear: () => void
}

export const BasketContext = createContext<Basket | undefined>(undefined)
