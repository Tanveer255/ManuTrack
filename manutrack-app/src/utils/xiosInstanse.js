import axios from "axios";

const axiosInstanse = axios.create({
    baseURL: 'https://localhost:7067', // e.g., 'http://localhost:5000/api'
    headers: {
        'Content-Type': 'application/json',
        // Add other common headers (e.g., authorization)
    },
});

export default axiosInstanse;