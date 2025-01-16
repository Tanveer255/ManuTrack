import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import { postRequest, getRequest } from '../../AppRoute';

const CreateProduct = () => {
    const navigate = useNavigate();

    const [product, setProduct] = useState({
        id: '',
        isDeleted: false,
        createdAt: '',
        updatedAt: '',
        title: '',
        bodyHtml: '',
        vendor: '',
        productType: '',
        tags: '',
        status: '',
        adminGraphqlApiId: '',
        productId: '',
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
        imageFiles: [],
    });

    const [currentOption, setCurrentOption] = useState({ name: '', values: '' });
    const [currentImage, setCurrentImage] = useState(null);
    const [units, setUnits] = useState([]);

    //const handleInputChange = (e) => {
    //    const { name, value } = e.target;
    //    setProduct({ ...product, [name]: value });
    //};
    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setProduct((prevProduct) => ({
            ...prevProduct,
            [name]: value,
        }));
    };

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

    const createCombinations = (arrays) => {
        if (arrays.length === 0) return [[]];
        const [first, ...rest] = arrays;
        const restCombinations = createCombinations(rest);
        return first.flatMap((value) => restCombinations.map((comb) => [value, ...comb]));
    };

    const fetchUnits = async () => {
        try {
            const response = await axios.get('/api/UnitOfMeasure');
            if (Array.isArray(response.data)) {
                setUnits(response.data);
            } else {
                setUnits([]);
            }
        } catch (error) {
            console.error('Failed to fetch Unit of Measure:', error);
            setUnits([]);
        }
    };

    const handleImageUpload = (e) => {
        const file = e.target.files[0];
        setCurrentImage(file);
    };

    const addImageFile = () => {
        if (currentImage) {
            setProduct({
                ...product,
                imageFiles: [...product.imageFiles, currentImage],
            });
            setCurrentImage(null);
        }
    };

    useEffect(() => {
        fetchUnits();
    }, []);

    // Handle form submission
    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await postRequest('/api/product', product); // Adjust endpoint as needed
            alert('Product created successfully');
            navigate('/');
        } catch (error) {
            alert('Failed to create product');
        }
    };

    //const handleSubmit = async (e) => {
    //    e.preventDefault();
    //    try {
    //        const formData = new FormData();
    //        formData.append('product', JSON.stringify(product));
    //        product.imageFiles.forEach((file, index) => {
    //            formData.append(`imageFiles[${index}]`, file);
    //        });

    //        await axios.post('https://localhost:7067/api/product', formData, {
    //            headers: {
    //                'Content-Type': 'multipart/form-data',
    //            },
    //        });

    //        alert('Product created successfully');
    //        navigate('/');
    //    } catch (error) {
    //        alert('Failed to create product');
    //        console.error(error);
    //    }
    //};

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
                    <label className="block text-sm font-medium mb-1">Unit of Measure</label>
                    <select
                        name="unitOfMeasure"
                        value={product.unitOfMeasure}
                        onChange={handleInputChange}
                        className="w-full border px-3 py-2 rounded"
                        required
                    >
                        <option value="" disabled>
                            Select Unit of Measure
                        </option>
                        {units.map((unit) => (
                            <option key={unit.code} value={unit.code}>
                                {unit.name}
                            </option>
                        ))}
                    </select>
                </div>
                <div className="mb-4">
                    <label className="block text-sm font-medium mb-1">Tags</label>
                    <input
                        type="text"
                        name="tags"
                        value={product.tags}
                        onChange={handleInputChange}
                        className="w-full border px-3 py-2 rounded"
                        placeholder="Comma-separated tags"
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
                        <button
                            type="button"
                            onClick={handleAddOption}
                            className="px-4 py-2 bg-blue-600 text-white rounded"
                        >
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
                    <button
                        type="button"
                        onClick={generateVariants}
                        className="px-4 py-2 bg-green-600 text-white rounded mt-2"
                    >
                        Generate Variants
                    </button>
                </div>
                <div className="mb-4">
                    <label className="block text-sm font-medium mb-1">Stock Level</label>
                    <input
                        type="number"
                        name="stockLevel"
                        value={product.stockLevel}
                        onChange={handleInputChange}
                        className="w-full border px-3 py-2 rounded"
                        required
                    />
                </div>
                <div className="mb-4">
                    <label className="block text-sm font-medium mb-1">Upload Image</label>
                    <input type="file" onChange={handleImageUpload} className="w-full border px-3 py-2 rounded" />
                    <button
                        type="button"
                        onClick={addImageFile}
                        className="px-4 py-2 bg-green-600 text-white rounded mt-2"
                    >
                        Add Image
                    </button>
                </div>
                <div className="mt-4">
                    <button type="submit" className="px-4 py-2 bg-blue-600 text-white rounded">
                        Create Product
                    </button>
                </div>
            </form>
        </div>
    );
};

export default CreateProduct;
