// src/services/companyService.js
import api from '../utils/xiosInstanse';

const companyService = {
    getCompanies: async () => {
        try {
            const response = await api.get('/companies/GetCompanies');
            return response.data;
        } catch (error) {
            console.error('Error fetching companies:', error);
            throw error; // Rethrow or handle error as needed
        }
    },

    getCompany: async (id) => {
        try {
            const response = await api.get(`/GetCompany/${id}`);
            return response.data;
        } catch (error) {
            console.error(`Error fetching company with ID ${id}:`, error);
            throw error;
        }
    },

    createCompany: async (companyData) => {
        try {
            const response = await api.post('/companies/PostCompany', companyData);
            return response.data;
        } catch (error) {
            console.error('Error creating company:', error);
            throw error;
        }
    },

    updateCompany: async (id, companyData) => {
        try {
            const response = await api.put(`/companies/PostCompany/${id}`, companyData);
            return response.data;
        } catch (error) {
            console.error(`Error updating company with ID ${id}:`, error);
            throw error;
        }
    },

    deleteCompany: async (id) => {
        try {
            await api.delete(`/companies/${id}`);
        } catch (error) {
            console.error(`Error deleting company with ID ${id}:`, error);
            throw error;
        }
    },
};

export default companyService;