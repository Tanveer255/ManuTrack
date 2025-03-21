// CompanyPage.jsx
import React, { useState } from 'react';
import CompanyTable from './CompanyTable';

const CompanyPage = () => {
    const [companies, setCompanies] = useState([
        { id: 1, name: 'Acme Corp', contact: 'John Doe', addressCount: 3 },
        { id: 2, name: 'Globex Industries', contact: 'Jane Smith', addressCount: 1 },
    ]);

    const handleEdit = (id) => {
        console.log(`Edit company with ID: ${id}`);
    };

    const handleDelete = (id) => {
        setCompanies(companies.filter((company) => company.id !== id));
    };

    return (
        <div className="min-h-screen bg-gray-100 p-4">
            <h1 className="text-3xl font-semibold mb-6">Company Management</h1>
            <div className="mb-4">
                <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
                    Add Company
                </button>
            </div>
            <CompanyTable companies={companies} onEdit={handleEdit} onDelete={handleDelete} />
        </div>
    );
};

export default CompanyPage;