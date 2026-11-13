import type { ReactNode } from 'react'
import { useAuth } from 'react-oidc-context'
import { Link, NavLink, Outlet, useLocation, useNavigate } from 'react-router'
import { loginPath, loginState } from '../auth/loginRoute'
import { forgetSignedIn } from '../auth/silentSignIn'
import { useIsAdmin } from '../auth/useIsAdmin'
import { useBasket } from '../basket/useBasket'

/** The refusal of a silent login, because the Keycloak session ended, is not an error to show. */
function isSilentRefusal(error: Error): boolean {
  const code = (error as { error?: string }).error
  return code === 'login_required' || code === 'interaction_required'
}

/** A link that looks like a button. The button of the page the person is on is filled. */
function NavButton({ to, end, children }: { to: string; end?: boolean; children: ReactNode }) {
  return (
    <NavLink
      to={to}
      end={end}
      className={({ isActive }) => `btn btn-sm ${isActive ? 'btn-primary' : 'btn-outline-primary'}`}
    >
      {children}
    </NavLink>
  )
}

export function Layout() {
  const auth = useAuth()
  const basket = useBasket()
  const isAdmin = useIsAdmin()
  const location = useLocation()
  const navigate = useNavigate()
  const user = auth.user?.profile
  const name = user?.name ?? user?.preferred_username ?? 'Signed in'

  return (
    <>
      <header className="navbar bg-body-tertiary border-bottom">
        <div className="container flex-wrap gap-2">
          <Link to="/" className="navbar-brand fw-bold">
            CAT Bookshop
          </Link>
          <nav className="d-flex flex-wrap align-items-center gap-3">
            <NavButton to="/" end>
              Books
            </NavButton>
            <NavButton to="/basket">Basket ({basket.count})</NavButton>
            {auth.isAuthenticated && <NavButton to="/orders">Orders</NavButton>}
            {isAdmin && <NavButton to="/admin/books/new">New book</NavButton>}
            {auth.isAuthenticated ? (
              <>
                <span className="fw-semibold">{name}</span>
                <button
                  type="button"
                  className="btn btn-outline-secondary btn-sm"
                  onClick={() => {
                    forgetSignedIn()
                    void auth.signoutRedirect()
                  }}
                >
                  Log out
                </button>
              </>
            ) : (
              location.pathname !== loginPath && (
                <button
                  type="button"
                  className="btn btn-success btn-sm"
                  disabled={auth.isLoading}
                  onClick={() =>
                    void navigate(loginPath, { state: loginState(location.pathname + location.search) })
                  }
                >
                  Log in
                </button>
              )
            )}
          </nav>
        </div>
      </header>
      {auth.error && !isSilentRefusal(auth.error) && (
        <div className="container mt-3">
          <p role="alert" className="alert alert-danger mb-0">
            Login failed: {auth.error.message}
          </p>
        </div>
      )}
      <main className="container py-4">
        <Outlet />
      </main>
    </>
  )
}
