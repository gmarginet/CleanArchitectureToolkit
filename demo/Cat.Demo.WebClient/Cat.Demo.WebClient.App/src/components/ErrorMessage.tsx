import { ApiError } from '../api/errors'

interface ErrorMessageProps {
  error: unknown
}

/** Shows the message and the code of a failed call. One component for every call. */
export function ErrorMessage({ error }: ErrorMessageProps) {
  const apiError = error instanceof ApiError ? error : undefined
  const entries = apiError?.errors ?? []

  return (
    <div role="alert" className="alert alert-danger my-3">
      {entries.length === 0 && <p className="fw-semibold mb-1">{apiError?.message ?? 'Something went wrong.'}</p>}
      {entries.length > 0 && (
        <ul className="fw-semibold mb-1">
          {entries.map((entry, index) => (
            <li key={index}>
              {entry.code && <code>{entry.code}</code>} {entry.message}
            </li>
          ))}
        </ul>
      )}
      {apiError?.traceId && <p className="small mb-0 opacity-75">Trace id: {apiError.traceId}</p>}
    </div>
  )
}
