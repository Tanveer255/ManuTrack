import React, { useState } from 'react';

const Settings = () => {
    // State for form data (You can add more settings here)
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [notifications, setNotifications] = useState(true);

    // Handle form submission (replace with API call if needed)
    const handleSubmit = (e) => {
        e.preventDefault();
        // Handle the form submission logic, such as updating the user profile or preferences
        console.log('Settings updated:', { username, email, notifications });
    };

    return (
        <div className="p-6">
            <h1 className="text-3xl font-semibold text-gray-900 mb-6">Settings</h1>

            {/* Settings Form */}
            <form onSubmit={handleSubmit} className="space-y-6">
                {/* Username Field */}
                <div>
                    <label htmlFor="username" className="block text-lg font-medium text-gray-700">
                        Username
                    </label>
                    <input
                        type="text"
                        id="username"
                        name="username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        className="mt-2 p-3 w-full border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
                        placeholder="Enter your username"
                    />
                </div>

                {/* Email Field */}
                <div>
                    <label htmlFor="email" className="block text-lg font-medium text-gray-700">
                        Email Address
                    </label>
                    <input
                        type="email"
                        id="email"
                        name="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        className="mt-2 p-3 w-full border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
                        placeholder="Enter your email"
                    />
                </div>

                {/* Notifications Toggle */}
                <div>
                    <label className="block text-lg font-medium text-gray-700">
                        Receive Notifications
                    </label>
                    <div className="mt-2">
                        <label
                            htmlFor="notifications"
                            className="inline-flex items-center cursor-pointer"
                        >
                            <span className="mr-2 text-gray-700">No</span>
                            <input
                                type="checkbox"
                                id="notifications"
                                name="notifications"
                                checked={notifications}
                                onChange={(e) => setNotifications(e.target.checked)}
                                className="toggle-checkbox w-10 h-6 bg-gray-300 rounded-full border-2 border-gray-300 appearance-none checked:bg-blue-500"
                            />
                            <span className="ml-2 text-gray-700">Yes</span>
                        </label>
                    </div>
                </div>

                {/* Submit Button */}
                <div>
                    <button
                        type="submit"
                        className="w-full p-3 bg-blue-600 text-white rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500"
                    >
                        Save Changes
                    </button>
                </div>
            </form>
        </div>
    );
};

export default Settings;
