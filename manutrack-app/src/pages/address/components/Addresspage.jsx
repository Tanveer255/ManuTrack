// AddressPage.jsx
import React, { useState } from 'react';
import AddressTable from './AddressTable';
import addressService from '../api/companyService';
import addressTable from '../api/CompanyTable';

const AddressPage = () => {
    const [addresses, setAddresses] = useState([
        { id: 1, street: '123 Main St', city: 'Anytown', companyName: 'Acme Corp' },
        { id: 2, street: '456 Oak Ave', city: 'Sometown', companyName: 'Globex Industries' },
    ]);

    const handleEdit = (id) => {
        console.log(`Edit address with ID: ${id}`);
    };

    const handleDelete = (id) => {
        setAddresses(addresses.filter((address) => address.id !== id));
    };

    return (
        <div className="min-h-screen bg-gray-100 p-4">
            <h1 className="text-3xl font-semibold mb-6">Address Management</h1>
            <div className="mb-4">
                <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
                    Add Address
                </button>
            </div>
            <AddressTable addresses={addresses} onEdit={handleEdit} onDelete={handleDelete} />
        </div>
    );
};

export default AddressPage;