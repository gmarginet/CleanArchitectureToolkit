import { render, screen } from '@testing-library/react'
import { MemoryRouter, Route, Routes, useLocation } from 'react-router'
import { beforeEach, describe, expect, it, vi } from 'vitest'
import { RequireLogin } from './RequireLogin'
import { rememberSignedIn } from './silentSignIn'

vi.mock('react-oidc-context', () => ({ useAuth: vi.fn() }))
import { useAuth } from 'react-oidc-context'

function auth(value: object = {}) {
  vi.mocked(useAuth).mockReturnValue({ isAuthenticated: false, isLoading: false, ...value } as never)
}

function LoginProbe() {
  return <p data-testid="login-state">{(useLocation().state as { returnTo: string }).returnTo}</p>
}

function renderGuard() {
  render(
    <MemoryRouter initialEntries={['/orders?page=2']}>
      <Routes>
        <Route element={<RequireLogin />}>
          <Route path="orders" element={<p>The orders</p>} />
        </Route>
        <Route path="login" element={<LoginProbe />} />
      </Routes>
    </MemoryRouter>,
  )
}

describe('RequireLogin', () => {
  beforeEach(() => sessionStorage.clear())

  it('shows the page to a person who is signed in', () => {
    auth({ isAuthenticated: true })
    renderGuard()

    expect(screen.getByText('The orders')).toBeInTheDocument()
  })

  it('sends a visitor to the login page with the page to return to', () => {
    auth()
    renderGuard()

    expect(screen.getByTestId('login-state')).toHaveTextContent('/orders?page=2')
  })

  it('waits while the library loads', () => {
    auth({ isLoading: true })
    renderGuard()

    expect(screen.getByText('Loading')).toBeInTheDocument()
    expect(screen.queryByTestId('login-state')).not.toBeInTheDocument()
  })

  it('waits for the silent login after a page refresh', () => {
    rememberSignedIn()
    auth()
    renderGuard()

    expect(screen.getByText('Loading')).toBeInTheDocument()
  })

  it('stops waiting when the silent login failed', () => {
    rememberSignedIn()
    auth({ error: new Error('login required') })
    renderGuard()

    expect(screen.getByTestId('login-state')).toBeInTheDocument()
  })
})
