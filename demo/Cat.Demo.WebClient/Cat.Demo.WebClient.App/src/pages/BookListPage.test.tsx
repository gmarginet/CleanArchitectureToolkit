import { QueryClient, QueryClientProvider } from '@tanstack/react-query'
import { render, screen } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { MemoryRouter, useLocation } from 'react-router'
import { beforeEach, describe, expect, it, vi } from 'vitest'
import { toApiError } from '../api/errors'
import { BasketProvider } from '../basket/BasketProvider'
import { BookListPage } from './BookListPage'

vi.mock('../api/books', () => ({ useBooks: vi.fn(), useCategories: vi.fn() }))
import { useBooks, useCategories } from '../api/books'

const books = [
  { id: 'b1', isbn: '111', title: 'Dune', author: 'Frank Herbert', categoryName: 'Science fiction', price: 12.5 },
  { id: 'b2', isbn: '222', title: 'Emma', author: 'Jane Austen', categoryName: 'Classics', price: null },
]

function Location() {
  return <div data-testid="location">{useLocation().search}</div>
}

function renderPage(initial = '/') {
  render(
    <QueryClientProvider client={new QueryClient()}>
      <MemoryRouter initialEntries={[initial]}>
        <BasketProvider>
          <BookListPage />
        </BasketProvider>
        <Location />
      </MemoryRouter>
    </QueryClientProvider>,
  )
}

function answer(value: object) {
  return { isPending: false, isError: false, isSuccess: false, ...value } as never
}

describe('BookListPage', () => {
  beforeEach(() => {
    vi.mocked(useCategories).mockReturnValue(
      answer({ isSuccess: true, data: [{ id: 'c1', name: 'Classics' }] }),
    )
  })

  it('shows the books with their prices', () => {
    vi.mocked(useBooks).mockReturnValue(answer({ isSuccess: true, data: books }))

    renderPage()

    expect(screen.getByRole('link', { name: 'Dune' })).toHaveAttribute('href', '/books/b1')
    expect(screen.getByText('€12.50')).toBeInTheDocument()
    expect(screen.getByText('No price yet')).toBeInTheDocument()
  })

  it('says so when nothing was found', () => {
    vi.mocked(useBooks).mockReturnValue(answer({ isSuccess: true, data: [] }))

    renderPage()

    expect(screen.getByText('No books found.')).toBeInTheDocument()
  })

  it('shows the error of a failed call', () => {
    vi.mocked(useBooks).mockReturnValue(answer({ isError: true, error: toApiError(0, undefined) }))

    renderPage()

    expect(screen.getByRole('alert')).toHaveTextContent('The shop could not be reached.')
  })

  it('puts the search text in the address and asks for it', async () => {
    vi.mocked(useBooks).mockReturnValue(answer({ isSuccess: true, data: books }))
    renderPage()

    await userEvent.type(screen.getByRole('searchbox', { name: 'Search' }), 'dune')
    await userEvent.click(screen.getByRole('button', { name: 'Search' }))

    expect(screen.getByTestId('location')).toHaveTextContent('?text=dune')
    expect(useBooks).toHaveBeenLastCalledWith({ text: 'dune', categoryId: '' })
  })

  it('shows the search text of the address in the search box', () => {
    vi.mocked(useBooks).mockReturnValue(answer({ isSuccess: true, data: books }))

    renderPage('/?text=clean')

    expect(screen.getByRole('searchbox', { name: 'Search' })).toHaveValue('clean')
    expect(useBooks).toHaveBeenLastCalledWith({ text: 'clean', categoryId: '' })
  })

  it('adds a book to the basket, and not a book without a price', async () => {
    localStorage.clear()
    vi.mocked(useBooks).mockReturnValue(answer({ isSuccess: true, data: books }))
    renderPage()
    const [dune, emma] = screen.getAllByRole('button', { name: 'Add to basket' })

    expect(emma).toBeDisabled()
    await userEvent.click(dune)
    await userEvent.click(dune)

    expect(JSON.parse(localStorage.getItem('cat-demo-basket') ?? '[]')).toEqual([
      { bookId: 'b1', title: 'Dune', price: 12.5, quantity: 2 },
    ])
  })

  it('filters by category', async () => {
    vi.mocked(useBooks).mockReturnValue(answer({ isSuccess: true, data: books }))
    renderPage()

    await userEvent.selectOptions(screen.getByRole('combobox', { name: 'Category' }), 'c1')

    expect(screen.getByTestId('location')).toHaveTextContent('?category=c1')
    expect(useBooks).toHaveBeenLastCalledWith({ text: '', categoryId: 'c1' })
  })
})
