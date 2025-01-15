import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import { ThemeProvider, createTheme } from '@mui/material/styles';
import './index.css';

// Create a custom theme
const theme = createTheme({
    palette: {
        primary: {
            main: '#1976d2', // Customize primary color
        },
        secondary: {
            main: '#dc004e', // Customize secondary color
        },
    },
    typography: {
        fontFamily: 'Arial, sans-serif', // Customize font family
    },
});

// Use createRoot for React 18
const root = ReactDOM.createRoot(document.getElementById('root'));

// Conditionally wrap in StrictMode only in development
const isDevelopment = process.env.NODE_ENV === 'development';

root.render(
    <ThemeProvider theme={theme}>
        {isDevelopment ? (
            <React.StrictMode>
                <App />
            </React.StrictMode>
        ) : (
            <App />
        )}
    </ThemeProvider>
);
