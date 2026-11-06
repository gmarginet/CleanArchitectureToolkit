import { InMemoryWebStorage, WebStorageStateStore, type UserManagerSettings } from 'oidc-client-ts'

// The AppHost sets VITE_AUTHORITY. The fallback is the Keycloak of a plain local run.
export const authority: string = import.meta.env.VITE_AUTHORITY ?? 'http://localhost:8180/realms/cat-demo'

/**
 * Login with authorization code and PKCE against the `cat-demo-web` client of the realm.
 * The user, with its tokens, is kept in memory. Only the state of a login in progress uses session storage,
 * because it has to survive the trip to Keycloak and back.
 */
export function createOidcSettings(origin: string = window.location.origin): UserManagerSettings {
  return {
    authority,
    client_id: 'cat-demo-web',
    redirect_uri: `${origin}/`,
    post_logout_redirect_uri: `${origin}/`,
    scope: 'openid profile email',
    userStore: new WebStorageStateStore({ store: new InMemoryWebStorage() }),
  }
}
