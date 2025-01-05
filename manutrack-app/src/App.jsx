import React from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import Sidebar from './components/Sidebar';
import Dashboard from './pages/Dashboard';
import Users from './pages/Users';
import Settings from './pages/Settings';
import Login from './pages/Login';
import Signup from './pages/Signup';
import { isAuthenticated } from './auth/auth';

const App = () => {
    return (
        <Router>
            <Routes>
                <Route path="/login" element={<Login />} />
                <Route path="/signup" element={<Signup />} />
                <Route
                    path="/*"
                    element={
                        isAuthenticated() ? (
                            <div style={{ display: 'flex' }}>
                                <Sidebar />
                                <div style={{ flexGrow: 1, padding: '16px' }}>
                                    <Routes>
                                        <Route path="/" element={<Dashboard />} />
                                        <Route path="/users" element={<Users />} />
                                        <Route path="/settings" element={<Settings />} />
                                    </Routes>
                                </div>
                            </div>
                        ) : (
                            <Navigate to="/login" />
                        )
                    }
                />
            </Routes>
        </Router>
    );
};

export default App;
