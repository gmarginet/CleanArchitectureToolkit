import { describe, expect, it } from 'vitest'
import { ApiError, formatTemplate, toApiError, unwrap } from './errors'

function answer(status: number, error?: unknown, data?: unknown) {
  return { data, error, response: new Response(null, { status }) }
}

describe('formatTemplate', () => {
  it('fills the arguments into the template', () => {
    expect(formatTemplate('Book {0} has {1} copies', ['Dune', 3])).toBe('Book Dune has 3 copies')
  })

  it('fills named placeholders in the order they appear', () => {
    expect(
      formatTemplate('Book {BookId} is out of stock. Order {OrderNumber} was cancelled.', ['b1', '20261106-0001']),
    ).toBe('Book b1 is out of stock. Order 20261106-0001 was cancelled.')
  })

  it('gives a name that appears twice the same argument', () => {
    expect(formatTemplate('{Name} meets {Other}. {Name} waves.', ['Ann', 'Bob'])).toBe('Ann meets Bob. Ann waves.')
  })

  it('skips the field name the validators put in front', () => {
    expect(formatTemplate('A book with ISBN {Isbn} already exists.', ['Book.Isbn', '978'])).toBe(
      'A book with ISBN 978 already exists.',
    )
  })

  it('keeps a placeholder when its argument is missing', () => {
    expect(formatTemplate('Book {0} and {1}', ['Dune'])).toBe('Book Dune and {1}')
  })
})

describe('toApiError', () => {
  it('uses the CAT errors of a problem body', () => {
    const error = toApiError(400, {
      title: 'Bad Request',
      catTraceId: 'trace-1',
      catErrors: [{ code: 'CAT-ORD-1006', message: 'The payment service is unavailable.', arguments: [] }],
    })

    expect(error.status).toBe(400)
    expect(error.message).toBe('The payment service is unavailable.')
    expect(error.errors).toEqual([{ code: 'CAT-ORD-1006', message: 'The payment service is unavailable.' }])
    expect(error.traceId).toBe('trace-1')
  })

  it('falls back to the detail and then to the title', () => {
    expect(toApiError(500, { detail: 'It broke.', title: 'Server error' }).message).toBe('It broke.')
    expect(toApiError(500, { title: 'Server error' }).message).toBe('Server error')
  })

  it('copes with an empty body', () => {
    expect(toApiError(401, '').message).toBe('Please log in to continue.')
    expect(toApiError(401, undefined).errors).toEqual([])
    expect(toApiError(418, undefined).message).toBe('Something went wrong (418).')
  })
})

describe('unwrap', () => {
  it('returns the data of a successful call', async () => {
    await expect(unwrap(Promise.resolve(answer(200, undefined, ['book'])))).resolves.toEqual(['book'])
  })

  it('throws an ApiError for a failed call', async () => {
    const failure = unwrap(Promise.resolve(answer(404, { title: 'Not Found' })))

    await expect(failure).rejects.toBeInstanceOf(ApiError)
    await expect(failure).rejects.toMatchObject({ status: 404, message: 'Not Found' })
  })

  it('turns a network failure into status 0', async () => {
    await expect(unwrap(Promise.reject(new TypeError('Failed to fetch')))).rejects.toMatchObject({ status: 0 })
  })
})
