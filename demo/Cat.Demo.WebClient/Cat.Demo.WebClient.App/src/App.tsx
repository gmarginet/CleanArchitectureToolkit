// The AppHost sets VITE_GATEWAY_URL. The fallback is the gateway of a plain local run.
const gatewayUrl: string = import.meta.env.VITE_GATEWAY_URL ?? 'http://localhost:5100'

export default function App() {
  return (
    <main>
      <h1>CAT Bookshop</h1>
      <p>The shop talks to the gateway at {gatewayUrl}.</p>
    </main>
  )
}
