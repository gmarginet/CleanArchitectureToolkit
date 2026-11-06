import { useAuth } from 'react-oidc-context'

/**
 * True when the logged in person has the admin role. Keycloak puts the roles in the ID token of this client as a
 * flat `roles` claim. This only decides what the screen shows. The services check the role on every call.
 */
export function useIsAdmin(): boolean {
  const roles = useAuth().user?.profile?.roles
  return Array.isArray(roles) && roles.includes('admin')
}
