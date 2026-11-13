import { render, screen } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { MemoryRouter, Route, Routes, useLocation } from 'react-router'
import { beforeEach, describe, expect, it, vi } from 'vitest'
import { BasketProvider } from '../basket/BasketProvider'
import { Layout } from './Layout'

vi.mock('react-oidc-context', () => ({ useAuth: vi.fn() }))
import { useAuth } from 'react-oidc-context'

const signinRedirect = vi.fn()
const signoutRedirect = vi.fn()

function auth(value: object) {
  vi.mocked(useAuth).mockReturnValue({
    isLoading: false,
    isAuthenticated: false,
    signinRedirect,
    signoutRedirect,
    ...value,
  } as never)
}

function LoginProbe() {
  return <p data-testid="login-state">{(useLocation().state as { returnTo: string }).returnTo}</p>
}

function renderLayout(path = '/books/b1?x=1') {
  render(
    <MemoryRouter initialEntries={[path]}>
      <BasketProvider>
        <Routes>
          <Route element={<Layout />}>
            <Route path="login" element={path === '/login' ? <p>Login page</p> : <LoginProbe />} />
            <Route path="*" element={<p>A page</p>} />
          </Route>
        </Routes>
      </BasketProvider>
    </MemoryRouter>,
  )
}

describe('Layout', () => {
  beforeEach(() => {
    signinRedirect.mockReset()
    signoutRedirect.mockReset()
    sessionStorage.clear()
    localStorage.clear()
  })

  it('shows the number of copies in the basket', () => {
    localStorage.setItem(
      'cat-demo-basket',
      JSON.stringify([
        { bookId: 'b1', title: 'Dune', price: 12.5, quantity: 2 },
        { bookId: 'b2', title: 'Emma', price: 9.99, quantity: 1 },
      ]),
    )
    auth({})
    renderLayout()

    expect(screen.getByRole('link', { name: 'Basket (3)' })).toHaveAttribute('href', '/basket')
  })

  it('sends a visitor to the login page, with the page to return to', async () => {
    auth({})
    renderLayout()

    await userEvent.click(screen.getByRole('button', { name: 'Log in' }))

    expect(screen.getByTestId('login-state')).toHaveTextContent('/books/b1?x=1')
    expect(signinRedirect).not.toHaveBeenCalled()
  })

  it('shows no login button on the login page itself', () => {
    auth({})
    renderLayout('/login')

    expect(screen.queryByRole('button', { name: 'Log in' })).not.toBeInTheDocument()
  })

  it('shows the name of the person and a logout', async () => {
    auth({ isAuthenticated: true, user: { profile: { name: 'Alice Anderson', preferred_username: 'alice' } } })
    renderLayout()

    expect(screen.getByText('Alice Anderson')).toBeInTheDocument()
    expect(screen.queryByRole('button', { name: 'Log in' })).not.toBeInTheDocument()

    await userEvent.click(screen.getByRole('button', { name: 'Log out' }))

    expect(signoutRedirect).toHaveBeenCalled()
  })

  it('falls back to the user name when there is no name', () => {
    auth({ isAuthenticated: true, user: { profile: { preferred_username: 'alice' } } })
    renderLayout()

    expect(screen.getByText('alice')).toBeInTheDocument()
  })

  it('disables the login while the library loads', () => {
    auth({ isLoading: true })
    renderLayout()

    expect(screen.getByRole('button', { name: 'Log in' })).toBeDisabled()
  })

  it('shows a failed login but not a refused silent login', () => {
    auth({ error: Object.assign(new Error('Keycloak is down'), { error: 'server_error' }) })
    renderLayout()
    expect(screen.getByRole('alert')).toHaveTextContent('Login failed: Keycloak is down')
  })

  it('stays quiet when the silent login is refused', () => {
    auth({ error: Object.assign(new Error('login required'), { error: 'login_required' }) })
    renderLayout()
    expect(screen.queryByRole('alert')).not.toBeInTheDocument()
  })
})
