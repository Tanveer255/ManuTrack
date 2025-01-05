import React, { useState, useEffect } from 'react';

const Users = () => {
    // Dummy data for users (You can replace this with an API call)
    const [users, setUsers] = useState([
        { id: 1, name: 'M Tanveer', email: 'tanveerofficial244@gmail.com.com' },
        { id: 2, name: 'Jane Smith', email: 'janesmith@example.com' },
        { id: 3, name: 'Samuel Lee', email: 'samuellee@example.com' },
    ]);

    // This can be an API call for fetching users from your backend
    useEffect(() => {
        // Fetch users data (or make an API request here)
        // setUsers(response.data); // Uncomment when you fetch from an API
    }, []);

    return (
        <div className="p-6">
            <h1 className="text-3xl font-semibold text-gray-900 mb-6">Users List</h1>

            {/* Users Table */}
            <div className="overflow-x-auto">
                <table className="min-w-full bg-white shadow-md rounded-lg">
                    <thead className="bg-gray-100">
                        <tr>
                            <th className="py-3 px-6 text-left text-gray-600">Name</th>
                            <th className="py-3 px-6 text-left text-gray-600">Email</th>
                            <th className="py-3 px-6 text-left text-gray-600">Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {users.map((user) => (
                            <tr key={user.id} className="border-b hover:bg-gray-50">
                                <td className="py-3 px-6 text-gray-700">{user.name}</td>
                                <td className="py-3 px-6 text-gray-700">{user.email}</td>
                                <td className="py-3 px-6 text-gray-700">
                                    <button className="text-blue-500 hover:text-blue-700 mr-4">
                                        View
                                    </button>
                                    <button className="text-yellow-500 hover:text-yellow-700 mr-4">
                                        Edit
                                    </button>
                                    <button className="text-red-500 hover:text-red-700">
                                        Delete
                                    </button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default Users;
