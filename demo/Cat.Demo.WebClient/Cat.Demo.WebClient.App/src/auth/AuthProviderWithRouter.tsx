import { useEffect, useMemo, useRef, type ReactNode } from 'react'
import { AuthProvider, useAuth } from 'react-oidc-context'
import { useLocation, useNavigate } from 'react-router'
import { setAccessToken } from './accessToken'
import { createOidcSettings } from './oidcSettings'
import { forgetSignedIn, rememberSignedIn, shouldSignInSilently, wasSignedIn } from './silentSignIn'

/** Keeps the token for the API calls and signs in again, silently, after a page refresh. */
function AuthBridge() {
  const auth = useAuth()
  const location = useLocation()
  const asked = useRef(false)

  useEffect(() => {
    setAccessToken(auth.user?.access_token)
  }, [auth.user])

  useEffect(() => {
    if (auth.isAuthenticated) {
      rememberSignedIn()
    }
  }, [auth.isAuthenticated])

  useEffect(() => {
    // The silent attempt failed, for example because the Keycloak session ended. Stay logged out and do not loop.
    if (auth.error) {
      forgetSignedIn()
    }
  }, [auth.error])

  useEffect(() => {
    const quietly = shouldSignInSilently({
      isLoading: auth.isLoading,
      isAuthenticated: auth.isAuthenticated,
      hasError: auth.error !== undefined,
      isNavigating: auth.activeNavigator !== undefined,
      wasSignedIn: wasSignedIn(),
    })
    if (quietly && !asked.current) {
      asked.current = true
      void auth.signinRedirect({ prompt: 'none', state: { returnTo: location.pathname + location.search } })
    }
  }, [auth, location.pathname, location.search])

  return null
}

/** Puts the person back on the page they came from after the login. */
function returnTo(state: unknown): string {
  const target = (state as { returnTo?: string } | undefined)?.returnTo
  return target && target.startsWith('/') ? target : '/'
}

export function AuthProviderWithRouter({ children }: { children: ReactNode }) {
  const navigate = useNavigate()
  const settings = useMemo(() => createOidcSettings(), [])

  return (
    <AuthProvider
      {...settings}
      onSigninCallback={(user) => {
        void navigate(returnTo(user?.state), { replace: true })
      }}
    >
      <AuthBridge />
      {children}
    </AuthProvider>
  )
}
