import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import TableComponent from "../../components/TableComponent"; // Import the reusable table component

const ProductDashboard = () => {
    const navigate = useNavigate();
    const [products, setProducts] = useState([]);

    const handleAddProduct = () => {
        navigate("/create-product");
    };

    // Fetch products from API
    const fetchProducts = async () => {
        try {
            const response = await axios.get("/api/Product"); // Adjust your endpoint accordingly
            setProducts(response.data); // Assuming response.data is the array of products
        } catch (error) {
            console.error("Error fetching products:", error);
        }
    };

    useEffect(() => {
        fetchProducts();
    }, []);

    const productColumns = [
        { header: "Product ID", field: "productId" },
        { header: "Name", field: "name" },
        { header: "SKU", field: "sku" },
        { header: "Unit of Measure", field: "unitOfMeasure" },
        { header: "Unit Cost", field: "unitCost" },
        { header: "Stock Level", field: "stockLevel" },
        { header: "Status", field: "status" },
    ];

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-4">Product Dashboard</h1>
            <button
                onClick={handleAddProduct}
                className="px-4 py-2 bg-blue-600 text-white rounded mb-4"
            >
                Add Product
            </button>

            {/* Reusable Table Component */}
            <TableComponent
                columns={productColumns}
                data={products}
                keyField="productId"
            />
        </div>
    );
};

export default ProductDashboard;
