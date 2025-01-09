import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import path from 'path';

// https://vitejs.dev/config/

export default defineConfig({
    plugins: [react()],
    server: {
            open: 'microsoft-edge', // Open the app in Edge
            port: 60118,

        },
        resolve: {
            alias: {
              '@': path.resolve(__dirname, 'src'), // Ensures '@' maps to the 'src' folder
            },
          },
});
