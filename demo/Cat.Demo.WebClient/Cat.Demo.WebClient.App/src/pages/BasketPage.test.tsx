import { render, screen } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { MemoryRouter, Route, Routes, useLocation } from 'react-router'
import { beforeEach, describe, expect, it, vi } from 'vitest'
import { toApiError } from '../api/errors'
import { BasketProvider } from '../basket/BasketProvider'
import { saveBasket } from '../basket/basketState'
import { BasketPage } from './BasketPage'

vi.mock('react-oidc-context', () => ({ useAuth: vi.fn() }))
vi.mock('../api/orders', () => ({ usePlaceOrder: vi.fn() }))
import { useAuth } from 'react-oidc-context'
import { usePlaceOrder } from '../api/orders'

const signinRedirect = vi.fn()
const mutate = vi.fn()

function login(isAuthenticated: boolean) {
  vi.mocked(useAuth).mockReturnValue({ isAuthenticated, isLoading: false, signinRedirect } as never)
}

function order(value: object = {}) {
  vi.mocked(usePlaceOrder).mockReturnValue({
    mutate,
    isPending: false,
    isError: false,
    isSuccess: false,
    ...value,
  } as never)
}

function LoginProbe() {
  return <p data-testid="login-state">{(useLocation().state as { returnTo: string }).returnTo}</p>
}

function renderPage() {
  render(
    <MemoryRouter initialEntries={['/basket']}>
      <BasketProvider>
        <Routes>
          <Route path="basket" element={<BasketPage />} />
          <Route path="login" element={<LoginProbe />} />
        </Routes>
      </BasketProvider>
    </MemoryRouter>,
  )
}

describe('BasketPage', () => {
  beforeEach(() => {
    localStorage.clear()
    signinRedirect.mockReset()
    mutate.mockReset()
    login(true)
    order()
  })

  it('says so when the basket is empty', () => {
    renderPage()

    expect(screen.getByText(/Your basket is empty/)).toBeInTheDocument()
    expect(screen.queryByRole('button', { name: 'Place order' })).not.toBeInTheDocument()
  })

  it('shows the lines and the total', () => {
    saveBasket([
      { bookId: 'b1', title: 'Dune', price: 12.5, quantity: 2 },
      { bookId: 'b2', title: 'Emma', price: 10, quantity: 1 },
    ])

    renderPage()

    expect(screen.getByRole('link', { name: 'Dune' })).toHaveAttribute('href', '/books/b1')
    expect(screen.getByText('€25.00')).toBeInTheDocument()
    expect(screen.getByText('€35.00')).toBeInTheDocument()
  })

  it('changes a quantity and removes a line', async () => {
    saveBasket([{ bookId: 'b1', title: 'Dune', price: 12.5, quantity: 2 }])
    renderPage()

    const quantity = screen.getByRole('spinbutton', { name: 'Quantity of Dune' })
    await userEvent.clear(quantity)
    await userEvent.type(quantity, '4')
    expect(screen.getAllByText('€50.00')).toHaveLength(2) // the line total and the basket total

    await userEvent.click(screen.getByRole('button', { name: 'Remove' }))
    expect(screen.getByText(/Your basket is empty/)).toBeInTheDocument()
  })

  it('places the order with only the book and the quantity', async () => {
    saveBasket([{ bookId: 'b1', title: 'Dune', price: 12.5, quantity: 3 }])
    renderPage()

    await userEvent.click(screen.getByRole('button', { name: 'Place order' }))

    expect(mutate).toHaveBeenCalledWith([{ bookId: 'b1', quantity: 3 }], expect.any(Object))
  })

  it('sends a visitor to the login page and back to the basket', async () => {
    login(false)
    saveBasket([{ bookId: 'b1', title: 'Dune', price: 12.5, quantity: 1 }])
    renderPage()

    await userEvent.click(screen.getByRole('button', { name: 'Log in to place your order' }))

    expect(screen.getByTestId('login-state')).toHaveTextContent('/basket')
    expect(signinRedirect).not.toHaveBeenCalled()
    expect(mutate).not.toHaveBeenCalled()
  })

  it('disables the button while the order is placed', () => {
    saveBasket([{ bookId: 'b1', title: 'Dune', price: 12.5, quantity: 1 }])
    order({ isPending: true })

    renderPage()

    expect(screen.getByRole('button', { name: 'Placing the order' })).toBeDisabled()
  })

  it('shows the message and the code of a failed order and keeps the basket', () => {
    saveBasket([{ bookId: 'b1', title: 'Dune', price: 12.5, quantity: 1 }])
    order({
      isError: true,
      error: toApiError(400, {
        catErrors: [{ code: 'DEM-ORD-1006', message: 'The payment service is unavailable.' }],
      }),
    })

    renderPage()

    expect(screen.getByRole('alert')).toHaveTextContent('The payment service is unavailable.')
    expect(screen.getByText('DEM-ORD-1006')).toBeInTheDocument()
    expect(screen.getByRole('link', { name: 'Dune' })).toBeInTheDocument()
  })

  it('shows the order number and the status after a success', () => {
    order({ isSuccess: true, data: { orderNumber: '20261106-0001', status: 'Confirmed', total: '25' } })

    renderPage()

    expect(screen.getByRole('status')).toHaveTextContent('Order 20261106-0001 is Confirmed. The total is €25.00.')
  })
})
