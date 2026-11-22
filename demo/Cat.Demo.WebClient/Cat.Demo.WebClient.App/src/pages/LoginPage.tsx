import { useTranslation } from 'react-i18next'
import { useAuth } from 'react-oidc-context'
import { Navigate, useLocation } from 'react-router'
import { readReturnTo } from '../auth/loginRoute'

/** The page before the login. The button starts the Keycloak login and the person returns to the page they came from. */
export function LoginPage() {
  const { t } = useTranslation()
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
            <h1 className="h3 card-title">{t('login.title')}</h1>
            <p>{t('login.intro')}</p>
            <button
              type="button"
              className="btn btn-primary"
              disabled={auth.isLoading}
              onClick={() => void auth.signinRedirect({ state: { returnTo } })}
            >
              {t('nav.logIn')}
            </button>
            <hr />
            <p>{t('login.newHere')}</p>
            <button
              type="button"
              className="btn btn-outline-primary"
              disabled={auth.isLoading}
              onClick={() => void auth.signinRedirect({ prompt: 'create', state: { returnTo } })}
            >
              {t('login.register')}
            </button>
          </div>
        </div>
      </div>
    </div>
  )
}
