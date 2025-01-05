import React, { useState } from 'react';
import { Box, TextField, Button, Typography } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const Signup = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [name, setName] = useState('');
    const navigate = useNavigate();

    const handleSignup = async (e) => {
        e.preventDefault();
        try {
            await axios.post('/auth/signup', { name, email, password });
            navigate('/login');
        } catch (error) {
            console.error('Signup failed:', error);
        }
    };

    return (
        <Box sx={{ width: 300, margin: '100px auto' }}>
            <Typography variant="h4" gutterBottom>Signup</Typography>
            <form onSubmit={handleSignup}>
                <TextField
                    label="Name"
                    fullWidth
                    margin="normal"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />
                <TextField
                    label="Email"
                    type="email"
                    fullWidth
                    margin="normal"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
                <TextField
                    label="Password"
                    type="password"
                    fullWidth
                    margin="normal"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
                <Button type="submit" variant="contained" color="primary" fullWidth>
                    Signup
                </Button>
            </form>
        </Box>
    );
};

export default Signup;
