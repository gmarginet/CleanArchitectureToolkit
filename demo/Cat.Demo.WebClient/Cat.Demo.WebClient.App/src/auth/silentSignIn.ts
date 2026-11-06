// A page refresh loses the token, because it lives in memory. This flag, kept for the tab only, says that the person
// was logged in, so the app asks Keycloak for a new token without showing the login page. The flag holds no secret.
const flagName = 'cat-demo-signed-in'

export function rememberSignedIn(): void {
  try {
    sessionStorage.setItem(flagName, '1')
  } catch {
    // Storage can be blocked. The person then logs in again after a refresh.
  }
}

export function forgetSignedIn(): void {
  try {
    sessionStorage.removeItem(flagName)
  } catch {
    // Nothing to forget when storage is blocked.
  }
}

export function wasSignedIn(): boolean {
  try {
    return sessionStorage.getItem(flagName) === '1'
  } catch {
    return false
  }
}

export interface SignInState {
  isLoading: boolean
  isAuthenticated: boolean
  hasError: boolean
  isNavigating: boolean
  wasSignedIn: boolean
}

/** True when the app should quietly ask Keycloak for a new token. */
export function shouldSignInSilently(state: SignInState): boolean {
  return state.wasSignedIn && !state.isLoading && !state.isAuthenticated && !state.hasError && !state.isNavigating
}
