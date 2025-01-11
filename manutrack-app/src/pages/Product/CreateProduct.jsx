import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { postRequest } from '../../AppRoute';

const CreateProduct = () => {
    const navigate = useNavigate();

    const [product, setProduct] = useState({
        name: '',
        description: '',
        sku: '',
        unitOfMeasure: '',
        unitCost: 0,
        stockLevel: 0,
        reorderLevel: 0,
        leadTimeInDays: 0,
        options: [],
        variants: [],
    });

    const [currentOption, setCurrentOption] = useState({ name: '', values: '' }); // Track current option input

    // Handle form input changes
    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setProduct({ ...product, [name]: value });
    };

    // Add option to product
    const handleAddOption = () => {
        if (currentOption.name && currentOption.values) {
            const valuesArray = currentOption.values.split(',').map((v) => v.trim());
            setProduct({
                ...product,
                options: [...product.options, { name: currentOption.name, values: valuesArray }],
            });
            setCurrentOption({ name: '', values: '' });
        }
    };

    // Generate variants based on options
    const generateVariants = () => {
        if (product.options.length === 0) return;

        const combinations = createCombinations(product.options.map((opt) => opt.values));
        const variants = combinations.map((comb, index) => ({
            variantId: index + 1,
            optionValues: comb,
            sku: `${product.sku}-${comb.join('-')}`,
            price: product.unitCost,
            stockLevel: product.stockLevel,
        }));

        setProduct({ ...product, variants });
    };

    // Helper function to create combinations of option values
    const createCombinations = (arrays) => {
        if (arrays.length === 0) return [[]];
        const [first, ...rest] = arrays;
        const restCombinations = createCombinations(rest);
        return first.flatMap((value) => restCombinations.map((comb) => [value, ...comb]));
    };

    // Handle form submission
    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await postRequest('/product', product); // Adjust endpoint as needed
            alert('Product created successfully');
            navigate('/');
        } catch (error) {
            alert('Failed to create product');
        }
    };

    return (
        <div className="p-6 bg-white shadow rounded">
            <button onClick={() => navigate('/')} className="px-4 py-2 bg-gray-600 text-white rounded mb-4">
                Back to Dashboard
            </button>
            <h2 className="text-xl font-bold mb-4">Add New Product</h2>
            <form onSubmit={handleSubmit}>
                <div className="mb-4">
                    <label className="block text-sm font-medium mb-1">Name</label>
                    <input
                        type="text"
                        name="name"
                        value={product.name}
                        onChange={handleInputChange}
                        className="w-full border px-3 py-2 rounded"
                        required
                    />
                </div>
                <div className="mb-4">
                    <label className="block text-sm font-medium mb-1">Description</label>
                    <textarea
                        name="description"
                        value={product.description}
                        onChange={handleInputChange}
                        className="w-full border px-3 py-2 rounded"
                    />
                </div>
                {/* Other product fields */}
                <div className="mb-4">
                    <label className="block text-sm font-medium mb-1">SKU</label>
                    <input
                        type="text"
                        name="sku"
                        value={product.sku}
                        onChange={handleInputChange}
                        className="w-full border px-3 py-2 rounded"
                        required
                    />
                </div>
                <div className="mb-4">
                    <label className="block text-sm font-medium mb-1">Unit Cost</label>
                    <input
                        type="number"
                        name="unitCost"
                        value={product.unitCost}
                        onChange={handleInputChange}
                        className="w-full border px-3 py-2 rounded"
                        required
                    />
                </div>

                {/* Option input */}
                <div className="mb-4">
                    <h3 className="text-lg font-medium mb-2">Options</h3>
                    <div className="flex gap-2 mb-2">
                        <input
                            type="text"
                            placeholder="Option Name (e.g., Color)"
                            value={currentOption.name}
                            onChange={(e) => setCurrentOption({ ...currentOption, name: e.target.value })}
                            className="border px-3 py-2 rounded w-1/2"
                        />
                        <input
                            type="text"
                            placeholder="Values (comma-separated, e.g., Red,Blue,Green)"
                            value={currentOption.values}
                            onChange={(e) => setCurrentOption({ ...currentOption, values: e.target.value })}
                            className="border px-3 py-2 rounded w-1/2"
                        />
                        <button type="button" onClick={handleAddOption} className="px-4 py-2 bg-blue-600 text-white rounded">
                            Add Option
                        </button>
                    </div>
                    <ul className="list-disc ml-5">
                        {product.options.map((opt, index) => (
                            <li key={index}>
                                {opt.name}: {opt.values.join(', ')}
                            </li>
                        ))}
                    </ul>
                </div>

                {/* Generate variants button */}
                <div className="mb-4">
                    <button
                        type="button"
                        onClick={generateVariants}
                        className="px-4 py-2 bg-green-600 text-white rounded"
                    >
                        Generate Variants
                    </button>
                </div>

                {/* Display generated variants */}
                {product.variants.length > 0 && (
                    <div className="mb-4">
                        <h3 className="text-lg font-medium mb-2">Generated Variants</h3>
                        <ul className="list-disc ml-5">
                            {product.variants.map((variant, index) => (
                                <li key={index}>
                                    {variant.optionValues.join(' / ')} - SKU: {variant.sku}
                                </li>
                            ))}
                        </ul>
                    </div>
                )}

                <button type="submit" className="px-6 py-2 bg-blue-600 text-white rounded">
                    Submit Product
                </button>
            </form>
        </div>
    );
};

export default CreateProduct;
