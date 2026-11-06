import react from '@vitejs/plugin-react'
import { defineConfig } from 'vite'

// The AppHost sets PORT. The fixed fallback keeps `npm run dev` on the address that the gateway allows for CORS.
const port = Number(process.env.PORT ?? 5104)

export default defineConfig({
  plugins: [react()],
  server: { port, strictPort: true },
})
