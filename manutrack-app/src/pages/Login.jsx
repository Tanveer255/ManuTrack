import React, { useState } from 'react';
import { Box, TextField, Button, Typography } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const Login = () => {
    const [username, SetUsername] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const navigate = useNavigate();

    const handleLogin = async (e) => {
        e.preventDefault();
        setError(''); // Clear previous error messages
        try {
            const response = await axios.post('https://localhost:7067/Auth/login', {
                username,
                password,
            });

            if (response.status === 200) {
                localStorage.setItem('token', response.data.token);
                console.log('Token saved, navigating to dashboard...');
                navigate('/'); // Redirect to dashboard
            }

        } catch (err) {
            console.error('Login failed:', err);
            setError('Invalid email or password. Please try again.');
        }
    };

    return (
        <Box sx={{ width: 300, margin: '100px auto' }}>
            <Typography variant="h4" gutterBottom>Login</Typography>
            {error && <Typography color="error">{error}</Typography>}
            <form onSubmit={handleLogin}>
                <TextField
                    label="Email"
                    type="email"
                    fullWidth
                    margin="normal"
                    value={username}
                    onChange={(e) => SetUsername(e.target.value)}
                    required
                />
                <TextField
                    label="Password"
                    type="password"
                    fullWidth
                    margin="normal"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    required
                />
                <Button type="submit" variant="contained" color="primary" fullWidth disabled={true}>
                    Login
                </Button>
            </form>
        </Box>
    );
};

export default Login;
