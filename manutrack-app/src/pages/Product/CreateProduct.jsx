import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const CreateProduct = () => {
    const [product, setProduct] = useState({
        name: '',
        description: '',
        sku: '',
        unitCost: '',
        stockLevel: '',
        reorderLevel: '',
        leadTimeInDays: '',
    });

    const [error, setError] = useState(null);
    const navigate = useNavigate();

    // Handle input changes
    const handleChange = (e) => {
        const { name, value } = e.target;
        setProduct((prev) => ({
            ...prev,
            [name]: value,
        }));
    };

    // Handle form submission
    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post('https://localhost:7067/Product', product);

            if (response.status === 201) {
                console.log('Product created:', response.data);
                navigate('/productDashboard'); // Redirect to the product dashboard page
            } else {
                setError('Failed to create product');
            }
        } catch (error) {
            console.error('Error creating product:', error);
            setError('Failed to create product');
        }
    };

    return (
        <div className="container mx-auto p-6">
            <h1 className="text-2xl font-bold mb-4">Create New Product</h1>

            {error && <p className="text-red-500 mb-4">{error}</p>}

            <form onSubmit={handleSubmit} className="space-y-4">
                <div>
                    <label htmlFor="name" className="block font-medium">Product Name</label>
                    <input
                        type="text"
                        id="name"
                        name="name"
                        value={product.name}
                        onChange={handleChange}
                        className="w-full px-4 py-2 border rounded"
                    />
                </div>

                <div>
                    <label htmlFor="description" className="block font-medium">Description</label>
                    <textarea
                        id="description"
                        name="description"
                        value={product.description}
                        onChange={handleChange}
                        className="w-full px-4 py-2 border rounded"
                    />
                </div>

                <div>
                    <label htmlFor="sku" className="block font-medium">SKU</label>
                    <input
                        type="text"
                        id="sku"
                        name="sku"
                        value={product.sku}
                        onChange={handleChange}
                        className="w-full px-4 py-2 border rounded"
                    />
                </div>

                <div>
                    <label htmlFor="unitCost" className="block font-medium">Unit Cost</label>
                    <input
                        type="number"
                        id="unitCost"
                        name="unitCost"
                        value={product.unitCost}
                        onChange={handleChange}
                        className="w-full px-4 py-2 border rounded"
                    />
                </div>

                <div>
                    <label htmlFor="stockLevel" className="block font-medium">Stock Level</label>
                    <input
                        type="number"
                        id="stockLevel"
                        name="stockLevel"
                        value={product.stockLevel}
                        onChange={handleChange}
                        className="w-full px-4 py-2 border rounded"
                    />
                </div>

                <div>
                    <label htmlFor="reorderLevel" className="block font-medium">Reorder Level</label>
                    <input
                        type="number"
                        id="reorderLevel"
                        name="reorderLevel"
                        value={product.reorderLevel}
                        onChange={handleChange}
                        className="w-full px-4 py-2 border rounded"
                    />
                </div>

                <div>
                    <label htmlFor="leadTimeInDays" className="block font-medium">Lead Time (Days)</label>
                    <input
                        type="number"
                        id="leadTimeInDays"
                        name="leadTimeInDays"
                        value={product.leadTimeInDays}
                        onChange={handleChange}
                        className="w-full px-4 py-2 border rounded"
                    />
                </div>

                <div className="mt-4">
                    <button type="submit" className="w-full bg-blue-500 text-white px-4 py-2 rounded">
                        Create Product
                    </button>
                </div>
            </form>
        </div>
    );
};

export default CreateProduct;
