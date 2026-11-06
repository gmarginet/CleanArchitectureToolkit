import { beforeEach, describe, expect, it } from 'vitest'
import {
  basketCount,
  basketReducer,
  basketTotal,
  loadBasket,
  maxLines,
  maxQuantity,
  saveBasket,
  type BasketLine,
} from './basketState'

const dune = { bookId: 'b1', title: 'Dune', price: 12.5 }
const emma = { bookId: 'b2', title: 'Emma', price: 9.99 }

describe('basketReducer', () => {
  it('adds a book with quantity 1', () => {
    expect(basketReducer([], { type: 'add', line: dune })).toEqual([{ ...dune, quantity: 1 }])
  })

  it('adds one more copy of a book that is already there', () => {
    const lines = basketReducer([{ ...dune, quantity: 2 }], { type: 'add', line: dune })

    expect(lines).toEqual([{ ...dune, quantity: 3 }])
  })

  it('stops at the maximum quantity', () => {
    const lines = basketReducer([{ ...dune, quantity: maxQuantity }], { type: 'add', line: dune })

    expect(lines[0].quantity).toBe(maxQuantity)
  })

  it('stops at the maximum number of lines', () => {
    const full: BasketLine[] = Array.from({ length: maxLines }, (_, index) => ({
      bookId: `id-${index}`,
      title: `Book ${index}`,
      price: 1,
      quantity: 1,
    }))

    expect(basketReducer(full, { type: 'add', line: dune })).toHaveLength(maxLines)
  })

  it('sets a quantity within the limits', () => {
    const start = [{ ...dune, quantity: 1 }]

    expect(basketReducer(start, { type: 'setQuantity', bookId: 'b1', quantity: 7 })[0].quantity).toBe(7)
    expect(basketReducer(start, { type: 'setQuantity', bookId: 'b1', quantity: 0 })[0].quantity).toBe(1)
    expect(basketReducer(start, { type: 'setQuantity', bookId: 'b1', quantity: 500 })[0].quantity).toBe(maxQuantity)
    expect(basketReducer(start, { type: 'setQuantity', bookId: 'b1', quantity: 2.9 })[0].quantity).toBe(2)
  })

  it('ignores a quantity that is not a number', () => {
    const start = [{ ...dune, quantity: 3 }]

    expect(basketReducer(start, { type: 'setQuantity', bookId: 'b1', quantity: Number.NaN })).toBe(start)
  })

  it('removes a line and clears the basket', () => {
    const start = [
      { ...dune, quantity: 1 },
      { ...emma, quantity: 2 },
    ]

    expect(basketReducer(start, { type: 'remove', bookId: 'b1' })).toEqual([{ ...emma, quantity: 2 }])
    expect(basketReducer(start, { type: 'clear' })).toEqual([])
  })
})

describe('totals', () => {
  const lines = [
    { ...dune, quantity: 2 },
    { ...emma, quantity: 1 },
  ]

  it('counts the copies', () => {
    expect(basketCount(lines)).toBe(3)
  })

  it('adds up the lines', () => {
    expect(basketTotal(lines)).toBeCloseTo(34.99, 2)
  })
})

describe('the basket of the browser', () => {
  beforeEach(() => localStorage.clear())

  it('is saved and loaded again', () => {
    const lines = [{ ...dune, quantity: 2 }]

    saveBasket(lines)

    expect(loadBasket()).toEqual(lines)
  })

  it('is empty when nothing is saved', () => {
    expect(loadBasket()).toEqual([])
  })

  it('is empty when the saved text is damaged', () => {
    localStorage.setItem('cat-demo-basket', '{not json')

    expect(loadBasket()).toEqual([])
  })

  it('drops lines that are not valid', () => {
    localStorage.setItem(
      'cat-demo-basket',
      JSON.stringify([{ ...dune, quantity: 1 }, { bookId: 'x' }, { ...emma, quantity: 99 }, 'text']),
    )

    expect(loadBasket()).toEqual([{ ...dune, quantity: 1 }])
  })
})
