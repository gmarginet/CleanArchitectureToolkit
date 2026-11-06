/** One error of a failed answer, with its message template already filled in. */
export interface ApiErrorEntry {
  code?: string
  message: string
}

/** What the services send for a failed call: `application/problem+json` with the CAT errors and a trace id. */
interface ProblemBody {
  title?: string | null
  detail?: string | null
  catErrors?: { code?: string | null; message?: string | null; arguments?: unknown[] | null }[] | null
  catTraceId?: string | null
}

/** A failed call. `status` is 0 when no answer came at all, for example when the gateway is down. */
export class ApiError extends Error {
  status: number
  errors: ApiErrorEntry[]
  traceId?: string

  constructor(status: number, message: string, errors: ApiErrorEntry[] = [], traceId?: string) {
    super(message)
    this.name = 'ApiError'
    this.status = status
    this.errors = errors
    this.traceId = traceId
  }
}

/**
 * Fills the placeholders of a message template with the arguments of the error. The services write named
 * placeholders, such as `{OrderNumber}`, and the arguments fill them in the order the names first appear.
 * A numbered placeholder, such as `{0}`, takes the argument at that position.
 */
export function formatTemplate(template: string, args: unknown[] | null | undefined): string {
  const names: string[] = []
  return template.replace(/\{(\w+)\}/g, (match, name: string) => {
    let position: number
    if (/^\d+$/.test(name)) {
      position = Number(name)
    } else {
      if (!names.includes(name)) names.push(name)
      position = names.indexOf(name)
    }
    const value = args?.[position]
    return value === undefined || value === null ? match : String(value)
  })
}

const fallbackMessages: Record<number, string> = {
  0: 'The shop could not be reached. Try again in a moment.',
  401: 'Please log in to continue.',
  403: 'You are not allowed to do this.',
  404: 'We could not find that.',
  409: 'That is not possible right now.',
}

/**
 * Builds an ApiError from a failed answer. The body can be a problem object, text or nothing at all, because a
 * rejected call, such as a missing token, may answer with an empty body.
 */
export function toApiError(status: number, body: unknown): ApiError {
  const problem = typeof body === 'object' && body !== null ? (body as ProblemBody) : undefined
  const errors: ApiErrorEntry[] = (problem?.catErrors ?? [])
    .filter((entry) => entry.message)
    .map((entry) => ({
      code: entry.code ?? undefined,
      message: formatTemplate(entry.message as string, entry.arguments),
    }))
  const message =
    errors[0]?.message ??
    problem?.detail ??
    problem?.title ??
    fallbackMessages[status] ??
    `Something went wrong (${status}).`
  return new ApiError(status, message, errors, problem?.catTraceId ?? undefined)
}

interface Answer<T> {
  data?: T
  error?: unknown
  response: Response
}

/** Returns the data of a call, or throws an ApiError. A network failure becomes an ApiError with status 0. */
export async function unwrap<T>(request: Promise<Answer<T>>): Promise<T> {
  let answer: Answer<T>
  try {
    answer = await request
  } catch {
    throw toApiError(0, undefined)
  }
  if (answer.response.ok) {
    return answer.data as T
  }
  throw toApiError(answer.response.status, answer.error)
}
