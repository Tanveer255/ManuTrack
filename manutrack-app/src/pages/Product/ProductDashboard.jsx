import React, { useState, useEffect } from 'react';
import axios from 'axios';

const ProductDashboard = () => {
    const [products, setProducts] = useState([]);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchProducts = async () => {
            try {
                const response = await axios.get('https://localhost:7067/Product'); // Adjust the URL if needed

                // Check if the response data is valid
                console.log('API Response:', response.data); // Verify what is coming from the backend

                if (response.status === 200) {
                    setProducts(response.data); // Assuming your response is an array of products
                } else {
                    setError('Failed to fetch products');
                }
            } catch (err) {
                console.error('Error fetching products:', err);
                setError('Failed to fetch products');
            }
        };

        fetchProducts();
    }, []);

    return (
        <div>
            <h1>Product Dashboard</h1>
            {error && <p className="text-red-500">{error}</p>}
            <div>
                {products.length > 0 ? (
                    products.map((product) => (
                        <div key={product.productId} className="product-card bg-gray-100 p-4 mb-4 rounded">
                            <h2 className="font-bold">{product.name}</h2>
                            <p>{product.description}</p>
                            <p>Price: ${product.unitCost}</p>
                        </div>
                    ))
                ) : (
                    <p>No products available</p>
                )}
            </div>
        </div>
    );
};

export default ProductDashboard;
