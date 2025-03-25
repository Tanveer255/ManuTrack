import React, { useState, useEffect } from "react";
import companyService from "../../address/api/companyService"; // Make sure this file has the right service functions
import CompanyTable from "../CompanyTable.jsx";

const CompanyPage = () => {
    const [companies, setCompanies] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchCompanies = async () => {
            try {
                const data = await companyService.getCompanies();
                setCompanies(data);
                setLoading(false);
            } catch (err) {
                setError(err);
                setLoading(false);
            }
        };

        fetchCompanies();
    }, []);

    const handleDelete = async (id) => {
        try {
            await companyService.deleteCompany(id);
            setCompanies(companies.filter((company) => company.id !== id));
        } catch (err) {
            setError(err);
        }
    };

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error.message}</div>;

    return (
        <div className="min-h-screen bg-gray-100 p-4">
            <h1 className="text-3xl font-semibold mb-6">Company Management</h1>
            <CompanyTable companies={companies} onDelete={handleDelete} />
        </div>
    );
};

export default CompanyPage;
