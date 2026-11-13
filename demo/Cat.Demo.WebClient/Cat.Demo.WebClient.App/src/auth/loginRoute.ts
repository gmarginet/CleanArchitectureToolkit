/** The route of the login page. */
export const loginPath = '/login'

/** What a page passes to the login page, in the router state, so the person returns to where they came from. */
export interface LoginRouteState {
  returnTo: string
}

/** Builds the router state for the login page. */
export function loginState(returnTo: string): LoginRouteState {
  return { returnTo }
}

/** Reads the page to return to. Only a path in this app counts, anything else gives the book list. */
export function readReturnTo(state: unknown): string {
  const target = (state as Partial<LoginRouteState> | null | undefined)?.returnTo
  return typeof target === 'string' && target.startsWith('/') && !target.startsWith('//') && !target.startsWith(loginPath)
    ? target
    : '/'
}
