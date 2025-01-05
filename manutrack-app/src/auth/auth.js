// auth.js (new helper file)
export const isAuthenticated = () => {
    return !!localStorage.getItem('token');
};
