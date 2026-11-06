import { ApiError } from '../api/errors'
import styles from './ErrorMessage.module.css'

interface ErrorMessageProps {
  error: unknown
}

/** Shows the message and the code of a failed call. One component for every call. */
export function ErrorMessage({ error }: ErrorMessageProps) {
  const apiError = error instanceof ApiError ? error : undefined
  const entries = apiError?.errors ?? []

  return (
    <div role="alert" className={styles.error}>
      <p className={styles.message}>{apiError?.message ?? 'Something went wrong.'}</p>
      {entries.length > 0 && (
        <ul>
          {entries.map((entry, index) => (
            <li key={index}>
              {entry.code && <code>{entry.code}</code>} {entry.message}
            </li>
          ))}
        </ul>
      )}
      {apiError?.traceId && <p className={styles.trace}>Trace id: {apiError.traceId}</p>}
    </div>
  )
}
