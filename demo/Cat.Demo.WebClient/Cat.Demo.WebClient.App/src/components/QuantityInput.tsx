import { useState } from 'react'
import { maxQuantity } from '../basket/basketState'

interface QuantityInputProps {
  label: string
  quantity: number
  onChange: (quantity: number) => void
}

/**
 * A number box that lets the person empty it and type a new number. Every valid number goes to the basket at once.
 * When the person leaves the box, it shows the quantity of the basket again.
 */
export function QuantityInput({ label, quantity, onChange }: QuantityInputProps) {
  const [typed, setTyped] = useState<string>()

  return (
    <input
      type="number"
      className="form-control form-control-sm"
      style={{ width: '5rem' }}
      aria-label={label}
      min={1}
      max={maxQuantity}
      value={typed ?? String(quantity)}
      onChange={(event) => {
        setTyped(event.target.value)
        if (event.target.value !== '' && Number.isFinite(event.target.valueAsNumber)) {
          onChange(event.target.valueAsNumber)
        }
      }}
      onBlur={() => setTyped(undefined)}
    />
  )
}
