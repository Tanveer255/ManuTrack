import React from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import Sidebar from './components/Sidebar';
import Dashboard from './pages/Dashboard';
import ProductDashboard from './pages/Product/ProductDashboard';
import Users from './pages/Users';
import Settings from './pages/Settings';
import Login from './pages/Login';
import Signup from './pages/Signup';
import { isAuthenticated } from './auth/auth';
import './index.css';
import CreateProduct from './pages/Product/CreateProduct';

// Layout for authenticated routes (with sidebar)
const AuthenticatedLayout = () => (
    <div className="flex">
        <Sidebar />
        <div className="flex-grow p-4">
            <Routes>
                <Route path="/" element={<Dashboard />} />
                <Route path="/Product/productDashboard" element={<ProductDashboard />} />
                <Route path="/create-product" element={<CreateProduct />} />
                <Route path="/users" element={<Users />} />
                <Route path="/settings" element={<Settings />} />
            </Routes>
        </div>
    </div>
);

const App = () => {
    return (
        <Router>
            <Routes>
                {/* Unauthenticated routes */}
                <Route path="/login" element={<Login />} />
                <Route path="/signup" element={<Signup />} />

                {/* Authenticated routes */}
                <Route
                    path="/*"
                    element={isAuthenticated() ? <AuthenticatedLayout /> : <Navigate to="/login" />}
                />
            </Routes>
        </Router>
    );
};

export default App;
