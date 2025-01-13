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
            '/api': { // Proxy for API Gateway
                target: 'https://localhost:7067', // Ocelot API Gateway URL
                changeOrigin: true, // Changes the origin of the host header to the target URL
                secure: false, // Set to false if you're using self-signed SSL
                rewrite: (path) => path.replace(/^\/api/, '') // Remove '/gateway' from the proxied request
            }
        }


        },
        resolve: {
            alias: {
              '@': path.resolve(__dirname, 'src'), // Ensures '@' maps to the 'src' folder
            },
          },
});
