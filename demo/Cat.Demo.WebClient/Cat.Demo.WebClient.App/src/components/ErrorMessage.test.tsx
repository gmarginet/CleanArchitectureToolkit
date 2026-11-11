import { render, screen } from '@testing-library/react'
import { describe, expect, it } from 'vitest'
import { toApiError } from '../api/errors'
import { ErrorMessage } from './ErrorMessage'

describe('ErrorMessage', () => {
  it('shows the message, the code and the trace id', () => {
    const error = toApiError(400, {
      catTraceId: 'trace-7',
      catErrors: [{ code: 'DEM-ORD-1006', message: 'The payment service is unavailable.' }],
    })

    render(<ErrorMessage error={error} />)

    expect(screen.getByRole('alert')).toHaveTextContent('The payment service is unavailable.')
    expect(screen.getByText('DEM-ORD-1006')).toBeInTheDocument()
    expect(screen.getByText('Trace id: trace-7')).toBeInTheDocument()
  })

  it('shows a plain message for an error that is not an ApiError', () => {
    render(<ErrorMessage error={new Error('boom')} />)

    expect(screen.getByRole('alert')).toHaveTextContent('Something went wrong.')
  })
})
