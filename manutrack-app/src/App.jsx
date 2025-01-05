import React from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import Sidebar from './components/Sidebar';
import Dashboard from './pages/Dashboard';
import Users from './pages/Users';
import Settings from './pages/Settings';
import Login from './pages/Login';
import Signup from './pages/Signup';
import { isAuthenticated } from './auth/auth';
import './index.css';

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
                            <div className="flex">
                                <Sidebar />
                                <div className="flex-grow p-4">
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
