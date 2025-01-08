import React from 'react';
import { Link } from 'react-router-dom';
import { Box, List, ListItem, ListItemText } from '@mui/material';

const Sidebar = () => {
    const menuItems = [
        { name: 'Dashboard', path: '/' },
        { name: 'Users', path: '/users' },
        { name: 'Settings', path: '/settings' },
        { name: 'products', path: '/product/productDashboard' },
    ];

    return (
        <Box sx={{ width: 250, bgcolor: 'bg-white', height: '100vh', color: 'white' }}>
            <List>
                {menuItems.map((item) => (
                    <ListItem button component={Link} to={item.path} key={item.name}>
                        <ListItemText primary={item.name} />
                    </ListItem>
                ))}
            </List>
        </Box>
    );
};

export default Sidebar;
