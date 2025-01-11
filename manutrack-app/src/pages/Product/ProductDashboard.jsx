import React from 'react';
import { useNavigate } from 'react-router-dom';

const ProductDashboard = () => {
    const navigate = useNavigate();

    const handleAddProduct = () => {
        navigate('/create-product');
    };

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-4">Product Dashboard</h1>
            <button
                onClick={handleAddProduct}
                className="px-4 py-2 bg-blue-600 text-white rounded"
            >
                Add Product
            </button>
            {/** Add your product list or other components here */}
        </div>
    );
};

export default ProductDashboard;
