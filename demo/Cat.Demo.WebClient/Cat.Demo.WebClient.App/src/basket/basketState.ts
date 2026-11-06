/** The most copies of one book in a line. The Orders service refuses more. */
export const maxQuantity = 50

/** The most lines in one order. The Orders service refuses more. */
export const maxLines = 50

export interface BasketLine {
  bookId: string
  title: string
  /** The price of the book list when the book was added. The order uses the price of the shop at that moment. */
  price: number
  quantity: number
}

export type BasketAction =
  | { type: 'add'; line: Omit<BasketLine, 'quantity'> }
  | { type: 'setQuantity'; bookId: string; quantity: number }
  | { type: 'remove'; bookId: string }
  | { type: 'clear' }

function clampQuantity(quantity: number): number {
  return Math.min(maxQuantity, Math.max(1, Math.trunc(quantity)))
}

export function basketReducer(lines: BasketLine[], action: BasketAction): BasketLine[] {
  switch (action.type) {
    case 'add': {
      const existing = lines.find((line) => line.bookId === action.line.bookId)
      if (existing) {
        return lines.map((line) =>
          line.bookId === existing.bookId ? { ...line, quantity: clampQuantity(line.quantity + 1) } : line,
        )
      }
      return lines.length >= maxLines ? lines : [...lines, { ...action.line, quantity: 1 }]
    }
    case 'setQuantity':
      if (!Number.isFinite(action.quantity)) return lines
      return lines.map((line) =>
        line.bookId === action.bookId ? { ...line, quantity: clampQuantity(action.quantity) } : line,
      )
    case 'remove':
      return lines.filter((line) => line.bookId !== action.bookId)
    case 'clear':
      return []
  }
}

export function basketCount(lines: BasketLine[]): number {
  return lines.reduce((count, line) => count + line.quantity, 0)
}

export function basketTotal(lines: BasketLine[]): number {
  return lines.reduce((total, line) => total + line.price * line.quantity, 0)
}

const storageKey = 'cat-demo-basket'

function isLine(value: unknown): value is BasketLine {
  const line = value as Partial<BasketLine> | null
  return (
    typeof line === 'object' &&
    line !== null &&
    typeof line.bookId === 'string' &&
    typeof line.title === 'string' &&
    typeof line.price === 'number' &&
    typeof line.quantity === 'number' &&
    line.quantity >= 1 &&
    line.quantity <= maxQuantity
  )
}

/** Reads the basket of this browser. A missing, blocked or damaged store gives an empty basket. */
export function loadBasket(): BasketLine[] {
  try {
    const parsed: unknown = JSON.parse(localStorage.getItem(storageKey) ?? '[]')
    return Array.isArray(parsed) ? parsed.filter(isLine).slice(0, maxLines) : []
  } catch {
    return []
  }
}

export function saveBasket(lines: BasketLine[]): void {
  try {
    localStorage.setItem(storageKey, JSON.stringify(lines))
  } catch {
    // The basket then lives until the page is closed.
  }
}
