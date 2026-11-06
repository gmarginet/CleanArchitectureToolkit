import { useAuth } from 'react-oidc-context'
import { Link, Outlet, useLocation } from 'react-router'
import { forgetSignedIn } from '../auth/silentSignIn'
import { useIsAdmin } from '../auth/useIsAdmin'
import { useBasket } from '../basket/useBasket'
import styles from './Layout.module.css'

/** The refusal of a silent login, because the Keycloak session ended, is not an error to show. */
function isSilentRefusal(error: Error): boolean {
  const code = (error as { error?: string }).error
  return code === 'login_required' || code === 'interaction_required'
}

export function Layout() {
  const auth = useAuth()
  const basket = useBasket()
  const isAdmin = useIsAdmin()
  const location = useLocation()
  const user = auth.user?.profile
  const name = user?.name ?? user?.preferred_username ?? 'Signed in'

  return (
    <>
      <header className={styles.header}>
        <Link to="/" className={styles.brand}>
          CAT Bookshop
        </Link>
        <nav className={styles.nav}>
          <Link to="/">Books</Link>
          <Link to="/basket">Basket ({basket.count})</Link>
          {auth.isAuthenticated && <Link to="/orders">Orders</Link>}
          {isAdmin && <Link to="/admin/books/new">New book</Link>}
          {auth.isAuthenticated ? (
            <>
              <span className={styles.user}>{name}</span>
              <button
                type="button"
                onClick={() => {
                  forgetSignedIn()
                  void auth.signoutRedirect()
                }}
              >
                Log out
              </button>
            </>
          ) : (
            <button
              type="button"
              disabled={auth.isLoading}
              onClick={() =>
                void auth.signinRedirect({ state: { returnTo: location.pathname + location.search } })
              }
            >
              Log in
            </button>
          )}
        </nav>
      </header>
      {auth.error && !isSilentRefusal(auth.error) && (
        <p role="alert" className={styles.loginError}>
          Login failed: {auth.error.message}
        </p>
      )}
      <main className={styles.main}>
        <Outlet />
      </main>
    </>
  )
}
