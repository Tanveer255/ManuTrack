import React from 'react';
import ReactDOM from 'react-dom';
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

ReactDOM.render(
    <ThemeProvider theme={theme}>
        <App />
    </ThemeProvider>,
    document.getElementById('root')
);
