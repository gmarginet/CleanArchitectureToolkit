import { render, screen } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { MemoryRouter, Route, Routes } from 'react-router'
import { beforeEach, describe, expect, it, vi } from 'vitest'
import { toApiError } from '../api/errors'
import { OrderDetailPage } from './OrderDetailPage'
import { OrdersPage } from './OrdersPage'

vi.mock('react-oidc-context', () => ({ useAuth: vi.fn() }))
vi.mock('../api/orders', () => ({ useOrders: vi.fn(), useOrder: vi.fn(), useCancelOrder: vi.fn() }))
vi.mock('@tanstack/react-query', () => ({ useQueries: () => [{ data: { title: 'Dune' } }] }))
import { useAuth } from 'react-oidc-context'
import { useCancelOrder, useOrder, useOrders } from '../api/orders'

const signinRedirect = vi.fn()
const cancelMutate = vi.fn()

function login(isAuthenticated: boolean) {
  vi.mocked(useAuth).mockReturnValue({ isAuthenticated, isLoading: false, signinRedirect } as never)
}

function cancelState(value: object = {}) {
  vi.mocked(useCancelOrder).mockReturnValue({
    mutate: cancelMutate,
    isPending: false,
    isError: false,
    isSuccess: false,
    ...value,
  } as never)
}

describe('OrdersPage', () => {
  beforeEach(() => {
    signinRedirect.mockReset()
    login(true)
  })

  it('lists the orders newest first', () => {
    vi.mocked(useOrders).mockReturnValue({
      isSuccess: true,
      data: [
        { id: 'o1', orderNumber: 'A-1', status: 'Paid', placedAt: '2026-01-01T10:00:00Z', total: 10 },
        { id: 'o2', orderNumber: 'A-2', status: 'Cancelled', placedAt: '2026-02-01T10:00:00Z', total: '20' },
      ],
    } as never)
    render(<MemoryRouter><OrdersPage /></MemoryRouter>)

    const rows = screen.getAllByRole('row')
    expect(rows[1]).toHaveTextContent('A-2')
    expect(rows[2]).toHaveTextContent('A-1')
  })

  it('says so when there are no orders', () => {
    vi.mocked(useOrders).mockReturnValue({ isSuccess: true, data: [] } as never)
    render(<MemoryRouter><OrdersPage /></MemoryRouter>)

    expect(screen.getByText('You have no orders yet.')).toBeInTheDocument()
  })
})

describe('OrderDetailPage', () => {
  beforeEach(() => {
    cancelMutate.mockReset()
    login(true)
    cancelState()
  })

  function renderDetail() {
    render(
      <MemoryRouter initialEntries={['/orders/o1']}>
        <Routes>
          <Route path="orders/:id" element={<OrderDetailPage />} />
        </Routes>
      </MemoryRouter>,
    )
  }

  it('shows the lines with the book title and cancels on request', async () => {
    vi.mocked(useOrder).mockReturnValue({
      isSuccess: true,
      data: { id: 'o1', orderNumber: 'A-1', status: 'Paid', total: 25, lines: [{ bookId: 'b1', quantity: 2, unitPrice: 12.5 }] },
    } as never)
    renderDetail()

    expect(screen.getByRole('link', { name: 'Dune' })).toBeInTheDocument()
    await userEvent.click(screen.getByRole('button', { name: 'Cancel order' }))
    expect(cancelMutate).toHaveBeenCalled()
  })

  it('shows the error of a refused cancel', () => {
    vi.mocked(useOrder).mockReturnValue({ isSuccess: true, data: { id: 'o1', orderNumber: 'A-1', status: 'Shipped', lines: [] } } as never)
    cancelState({ isError: true, error: toApiError(409, { catErrors: [{ code: 'DEM-ORD-1', message: 'Too late.' }] }) })
    renderDetail()

    expect(screen.getByRole('alert')).toHaveTextContent('Too late.')
  })

  it('says so when the order does not exist', () => {
    vi.mocked(useOrder).mockReturnValue({ isError: true, error: toApiError(404, undefined) } as never)
    renderDetail()

    expect(screen.getByText('We could not find that order.')).toBeInTheDocument()
  })
})
