// src/services/companyService.js
import api from '../utils/xiosInstanse';


const companyService = {
    getAddress: async () => {
        try {
            const response = await api.get('/companies');
            return response.data;
        } catch (error) {
            console.error('Error fetching companies:', error);
            throw error; // Rethrow or handle error as needed
        }
    },

    getAddress: async (id) => {
        try {
            const response = await api.get(`/companies/GetAddressesByCompany/${id}`);
            return response.data;
        } catch (error) {
            console.error(`Error fetching company with ID ${id}:`, error);
            throw error;
        }
    },

    createAddress: async (companyData) => {
        try {
            const response = await api.post('/companies', companyData);
            return response.data;
        } catch (error) {
            console.error('Error creating company:', error);
            throw error;
        }
    },

    updateAddress: async (id, companyData) => {
        try {
            const response = await api.put(`/companies/${id}`, companyData);
            return response.data;
        } catch (error) {
            console.error(`Error updating company with ID ${id}:`, error);
            throw error;
        }
    },

    deleteAddress: async (id) => {
        try {
            await api.delete(`/companies/${id}`);
        } catch (error) {
            console.error(`Error deleting company with ID ${id}:`, error);
            throw error;
        }
    },
};

export default companyService;