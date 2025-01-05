import React, { useEffect, useState } from 'react';
import axios from 'axios';

const ProductDashboard = () => {
    const [products, setProducts] = useState([]);
    const [isLoading, setIsLoading] = useState(true);

    // Fetch products when the component mounts
    useEffect(() => {
        const fetchProducts = async () => {
            try {
                const response = await axios.get('https://localhost:7067/Product');
                setProducts(response.data);
                debugger;
            } catch (error) {
                console.error('Error fetching products:', error);
            } finally {
                setIsLoading(false);
            }
        };

        fetchProducts();
    }, []);

    // Handle Delete product
    const handleDelete = async (id) => {
        try {
            await axios.delete(`http://localhost:7067/Product/${id}`);
            setProducts(products.filter(product => product.productId !== id));
        } catch (error) {
            console.error('Error deleting product:', error);
        }
    };

    return (
        <div className="p-6">
            <h1 className="text-3xl font-semibold text-gray-900 mb-6">Product Dashboard</h1>

            {/* Add Product Button */}
            <div className="mb-4">
                <button className="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700">
                    Add New Product
                </button>
            </div>

            {/* Loading Spinner */}
            {isLoading ? (
                <div className="flex justify-center">
                    <div className="w-16 h-16 border-4 border-blue-600 border-t-transparent border-solid rounded-full animate-spin"></div>
                </div>
            ) : (
                <div className="overflow-x-auto">
                    <table className="min-w-full bg-white shadow-md rounded-lg">
                        <thead className="bg-gray-100">
                            <tr>
                                <th className="py-3 px-6 text-left text-gray-600">Product Name</th>
                                <th className="py-3 px-6 text-left text-gray-600">Description</th>
                                <th className="py-3 px-6 text-left text-gray-600">Price</th>
                                <th className="py-3 px-6 text-left text-gray-600">Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                            {products.map((product) => (
                                <tr key={product.productId} className="border-b hover:bg-gray-50">
                                    <td className="py-3 px-6 text-gray-700">{product.name}</td>
                                    <td className="py-3 px-6 text-gray-700">{product.description}</td>
                                    <td className="py-3 px-6 text-gray-700">${product.unitCost}</td>
                                    <td className="py-3 px-6 text-gray-700">
                                        <button
                                            className="text-yellow-500 hover:text-yellow-700 mr-4"
                                            onClick={() => alert('Edit product functionality here')}
                                        >
                                            Edit
                                        </button>
                                        <button
                                            className="text-red-500 hover:text-red-700"
                                            onClick={() => handleDelete(product.productId)}
                                        >
                                            Delete
                                        </button>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            )}
        </div>
    );
};

export default ProductDashboard;
