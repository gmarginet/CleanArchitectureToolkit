import { render, screen } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { MemoryRouter } from 'react-router'
import { beforeEach, describe, expect, it, vi } from 'vitest'
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

function renderLayout(path = '/books/b1?x=1') {
  render(
    <MemoryRouter initialEntries={[path]}>
      <Layout />
    </MemoryRouter>,
  )
}

describe('Layout', () => {
  beforeEach(() => {
    signinRedirect.mockReset()
    signoutRedirect.mockReset()
    sessionStorage.clear()
  })

  it('offers a login that returns to the same page', async () => {
    auth({})
    renderLayout()

    await userEvent.click(screen.getByRole('button', { name: 'Log in' }))

    expect(signinRedirect).toHaveBeenCalledWith({ state: { returnTo: '/books/b1?x=1' } })
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
