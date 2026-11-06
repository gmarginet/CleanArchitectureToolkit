// The access token lives in memory only. A page refresh loses it, and the app signs in again silently,
// see `AuthBridge`.
let accessToken: string | undefined

export function setAccessToken(token: string | undefined): void {
  accessToken = token
}

export function getAccessToken(): string | undefined {
  return accessToken
}
