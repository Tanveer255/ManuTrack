import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const ProductDashboard = () => {
    const navigate = useNavigate();
    const [products, setProducts] = useState([]);

    const handleAddProduct = () => {
        navigate('/create-product');
    };

    // Fetch products from API
    const fetchProducts = async () => {
        try {
            const response = await axios.get('/api/Product'); // Adjust your endpoint accordingly
            setProducts(response.data); // Assuming response.data is the array of products
        } catch (error) {
            console.error('Error fetching products:', error);
        }
    };

    useEffect(() => {
        fetchProducts();
    }, []);

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-4">Product Dashboard</h1>
            <button
                onClick={handleAddProduct}
                className="px-4 py-2 bg-blue-600 text-white rounded mb-4"
            >
                Add Product
            </button>

            {/* Product Table */}
            <table className="min-w-full table-auto border-collapse">
                <thead>
                    <tr>
                        <th className="px-4 py-2 border-b">Product ID</th>
                        <th className="px-4 py-2 border-b">Name</th>
                        <th className="px-4 py-2 border-b">SKU</th>
                        <th className="px-4 py-2 border-b">Unit of Measure</th>
                        <th className="px-4 py-2 border-b">Unit Cost</th>
                        <th className="px-4 py-2 border-b">Stock Level</th>
                        <th className="px-4 py-2 border-b">Status</th>
                    </tr>
                </thead>
                <tbody>
                    {products.map((product) => (
                        <tr key={product.productId}>
                            <td className="px-4 py-2 border-b">{product.productId}</td>
                            <td className="px-4 py-2 border-b">{product.name}</td>
                            <td className="px-4 py-2 border-b">{product.sku}</td>
                            <td className="px-4 py-2 border-b">{product.unitOfMeasure}</td>
                            <td className="px-4 py-2 border-b">{product.unitCost}</td>
                            <td className="px-4 py-2 border-b">{product.stockLevel}</td>
                            <td className="px-4 py-2 border-b">{product.status}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default ProductDashboard;
