import { render, screen } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { MemoryRouter, Route, Routes } from 'react-router'
import { beforeEach, describe, expect, it, vi } from 'vitest'
import { loginState } from '../auth/loginRoute'
import { LoginPage } from './LoginPage'

vi.mock('react-oidc-context', () => ({ useAuth: vi.fn() }))
import { useAuth } from 'react-oidc-context'

const signinRedirect = vi.fn()

function auth(value: object = {}) {
  vi.mocked(useAuth).mockReturnValue({ isAuthenticated: false, isLoading: false, signinRedirect, ...value } as never)
}

function renderPage(state?: unknown) {
  render(
    <MemoryRouter initialEntries={[{ pathname: '/login', state }]}>
      <Routes>
        <Route path="login" element={<LoginPage />} />
        <Route path="orders" element={<p>The orders</p>} />
        <Route path="/" element={<p>The books</p>} />
      </Routes>
    </MemoryRouter>,
  )
}

describe('LoginPage', () => {
  beforeEach(() => signinRedirect.mockReset())

  it('starts the login and asks to return to the page the person came from', async () => {
    auth()
    renderPage(loginState('/orders'))

    await userEvent.click(screen.getByRole('button', { name: 'Log in' }))

    expect(signinRedirect).toHaveBeenCalledWith({ state: { returnTo: '/orders' } })
  })

  it('opens the registration form and asks to return to the page the person came from', async () => {
    auth()
    renderPage(loginState('/basket'))

    await userEvent.click(screen.getByRole('button', { name: 'Register' }))

    expect(signinRedirect).toHaveBeenCalledWith({ prompt: 'create', state: { returnTo: '/basket' } })
  })

  it('returns to the book list when no page is known', async () => {
    auth()
    renderPage()

    await userEvent.click(screen.getByRole('button', { name: 'Log in' }))

    expect(signinRedirect).toHaveBeenCalledWith({ state: { returnTo: '/' } })
  })

  it('disables the button while the library loads', () => {
    auth({ isLoading: true })
    renderPage()

    expect(screen.getByRole('button', { name: 'Log in' })).toBeDisabled()
  })

  it('shows no demo users', () => {
    auth()
    renderPage()

    expect(screen.queryByText(/alice|bob|admin/i)).not.toBeInTheDocument()
  })

  it('sends a person who is signed in on to the page they came from', () => {
    auth({ isAuthenticated: true })
    renderPage(loginState('/orders'))

    expect(screen.getByText('The orders')).toBeInTheDocument()
  })
})
