import axios from 'axios';

const BASE_URL = 'http://localhost:7067';

const AppRoute = axios.create({
    baseURL: BASE_URL,
    headers: {
        'Content-Type': 'application/json',
    },
});

// Generic GET method
export const getRequest = async (endpoint) => {
    try {
        const response = await AppRoute.get(endpoint);
        return response.data;
    } catch (error) {
        console.error(`GET ${endpoint} failed:`, error);
        throw error;
    }
};

// Generic POST method
export const postRequest = async (endpoint, data) => {
    try {
        const response = await AppRoute.post(endpoint, data);
        return response.data;
    } catch (error) {
        console.error(`POST ${endpoint} failed:`, error);
        throw error;
    }
};

// Generic DELETE method
export const deleteRequest = async (endpoint) => {
    try {
        await AppRoute.delete(endpoint);
    } catch (error) {
        console.error(`DELETE ${endpoint} failed:`, error);
        throw error;
    }
};

export default AppRoute;
