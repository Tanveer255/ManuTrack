import axios from 'axios';

const BASE_URL = 'https://localhost:7067';

const AppRoute = axios.create({
    baseURL: BASE_URL,
    headers: {
        'Accept': '*/*', // Accept any response content type
        'Content-Type': 'application/json', // Send data as JSON
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
