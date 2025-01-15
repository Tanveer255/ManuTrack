import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import path from 'path';

// https://vitejs.dev/config/

export default defineConfig({
    plugins: [react()],
    server: {
        open: 'microsoft-edge', // Open the app in Edge
        port: 60118,
        proxy: {
            '/api': {
                target: 'https://localhost:7067', // Your backend URL
                changeOrigin: true, // Ensure the origin header is updated to match the target
                secure: false, // If using HTTPs locally, set to false for self-signed certificates
                rewrite: (path) => path.replace(/^\/api/, ''), // Optional: remove '/api' from the request path if needed
            },
        },
    },
    resolve: {
        alias: {
            '@': path.resolve(__dirname, 'src'), // Ensures '@' maps to the 'src' folder
        },
    },
});
