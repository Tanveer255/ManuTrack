import path from "path"
import react from "@vitejs/plugin-react"
import { defineConfig } from "vite"

export default defineConfig({
  plugins: [react()],
  resolve: {
    alias: {
      "@": path.resolve(__dirname, "./src"),
      },

    },
    server: {
        port: 5173,
        proxy: {
            '/api': {
                target: 'https://localhost:7067',
                changeOrigin: true,
                secure: false,
            },
        },
    }
})
