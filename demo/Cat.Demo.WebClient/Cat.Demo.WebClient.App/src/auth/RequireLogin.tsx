import { useAuth } from 'react-oidc-context'
import { Navigate, Outlet, useLocation } from 'react-router'
import { wasSignedIn } from './silentSignIn'
import { loginPath, loginState } from './loginRoute'

/**
 * Guards the pages that need a login. A visitor without a login goes to the login page and returns here after it.
 * While the app still asks Keycloak for a token, quietly after a page refresh, the guard waits.
 */
export function RequireLogin() {
  const auth = useAuth()
  const location = useLocation()

  if (auth.isAuthenticated) {
    return <Outlet />
  }

  const waiting = auth.isLoading || auth.activeNavigator !== undefined || (wasSignedIn() && !auth.error)
  if (waiting) {
    return <p>Loading</p>
  }

  return <Navigate to={loginPath} replace state={loginState(location.pathname + location.search)} />
}
