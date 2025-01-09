import React from 'react';
import Form from '../components/Form';

const App = () => {
    const formFields = [
        { name: 'username', label: 'Username', type: 'text', placeholder: 'Enter username', required: true },
        { name: 'email', label: 'Email', type: 'email', placeholder: 'Enter email', required: true },
        { name: 'password', label: 'Password', type: 'password', placeholder: 'Enter password', required: true },
    ];

    const handleFormSubmit = (data) => {
        console.log('Form Data:', data);
        alert('Form submitted successfully!');
    };

    return (
        <div className="min-h-screen flex items-center justify-center bg-gray-100">
            <div>
                <h1 className="text-2xl font-bold text-center mb-6">Tailwind & Flowbite Form</h1>
                <Form fields={formFields} onSubmit={handleFormSubmit} buttonText="Register" />
            </div>
        </div>
    );
};

export default App;
