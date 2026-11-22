import type { ReactNode } from 'react'
import { useTranslation } from 'react-i18next'
import { useAuth } from 'react-oidc-context'
import { Link, NavLink, Outlet, useLocation, useNavigate } from 'react-router'
import { loginPath, loginState } from '../auth/loginRoute'
import { forgetSignedIn } from '../auth/silentSignIn'
import { useIsAdmin } from '../auth/useIsAdmin'
import { useBasket } from '../basket/useBasket'
import { LanguageSelector } from './LanguageSelector'

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
  const { t } = useTranslation()
  const auth = useAuth()
  const basket = useBasket()
  const isAdmin = useIsAdmin()
  const location = useLocation()
  const navigate = useNavigate()
  const user = auth.user?.profile
  const name = user?.name ?? user?.preferred_username ?? t('nav.signedIn')

  return (
    <>
      <header className="navbar bg-body-tertiary border-bottom">
        <div className="container flex-wrap gap-2">
          <Link to="/" className="navbar-brand fw-bold">
            {t('app.name')}
          </Link>
          <nav className="d-flex flex-wrap align-items-center gap-3">
            <NavButton to="/" end>
              {t('nav.books')}
            </NavButton>
            <NavButton to="/basket">{t('nav.basket', { count: basket.count })}</NavButton>
            {auth.isAuthenticated && <NavButton to="/orders">{t('nav.orders')}</NavButton>}
            {isAdmin && <NavButton to="/admin/books/new">{t('nav.newBook')}</NavButton>}
            {isAdmin && <NavButton to="/admin/categories">{t('nav.categories')}</NavButton>}
            <LanguageSelector />
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
                  {t('nav.logOut')}
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
                  {t('nav.logIn')}
                </button>
              )
            )}
          </nav>
        </div>
      </header>
      {auth.error && !isSilentRefusal(auth.error) && (
        <div className="container mt-3">
          <p role="alert" className="alert alert-danger mb-0">
            {t('nav.loginFailed', { message: auth.error.message })}
          </p>
        </div>
      )}
      <main className="container py-4">
        <Outlet />
      </main>
    </>
  )
}
