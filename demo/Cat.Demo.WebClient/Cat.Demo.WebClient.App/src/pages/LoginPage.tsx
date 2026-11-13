import { useAuth } from 'react-oidc-context'
import { Navigate, useLocation } from 'react-router'
import { readReturnTo } from '../auth/loginRoute'

/** The page before the login. The button starts the Keycloak login and the person returns to the page they came from. */
export function LoginPage() {
  const auth = useAuth()
  const location = useLocation()
  const returnTo = readReturnTo(location.state)

  if (auth.isAuthenticated) {
    return <Navigate to={returnTo} replace />
  }

  return (
    <div className="row justify-content-center">
      <div className="col-md-8 col-lg-6">
        <div className="card">
          <div className="card-body">
            <h1 className="h3 card-title">Log in</h1>
            <p>Log in to place orders and to see your orders. The books and the basket are open to everyone.</p>
            <button
              type="button"
              className="btn btn-primary"
              disabled={auth.isLoading}
              onClick={() => void auth.signinRedirect({ state: { returnTo } })}
            >
              Log in
            </button>
            <hr />
            <p>New here? Register, then you are logged in at once.</p>
            <button
              type="button"
              className="btn btn-outline-primary"
              disabled={auth.isLoading}
              onClick={() => void auth.signinRedirect({ prompt: 'create', state: { returnTo } })}
            >
              Register
            </button>
          </div>
        </div>
      </div>
    </div>
  )
}
