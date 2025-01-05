import React from 'react';

const Dashboard = () => {
    return (
        <div className="p-6">
            <h1 className="text-3xl font-semibold text-gray-900 mb-6">Dashboard</h1>

            {/* Stats Section */}
            <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
                {/* Card 1 */}
                <div className="bg-white p-6 rounded-lg shadow-lg">
                    <h2 className="text-xl font-medium text-gray-700">Total Users</h2>
                    <p className="text-3xl font-bold text-blue-500">1,254</p>
                </div>

                {/* Card 2 */}
                <div className="bg-white p-6 rounded-lg shadow-lg">
                    <h2 className="text-xl font-medium text-gray-700">Active Sessions</h2>
                    <p className="text-3xl font-bold text-green-500">321</p>
                </div>

                {/* Card 3 */}
                <div className="bg-white p-6 rounded-lg shadow-lg">
                    <h2 className="text-xl font-medium text-gray-700">Pending Orders</h2>
                    <p className="text-3xl font-bold text-red-500">88</p>
                </div>
            </div>

            {/* Recent Activity Section */}
            <div className="mt-8">
                <h2 className="text-2xl font-semibold text-gray-900 mb-4">Recent Activity</h2>
                <div className="bg-white p-6 rounded-lg shadow-lg">
                    <ul>
                        <li className="py-3 border-b border-gray-200">
                            <span className="font-semibold text-gray-700">Muhammad Tanveer</span> completed a task
                            <span className="text-sm text-gray-500"> 2 hours ago</span>
                        </li>
                        <li className="py-3 border-b border-gray-200">
                            <span className="font-semibold text-gray-700">Jane Smith</span> added a new product
                            <span className="text-sm text-gray-500"> 3 hours ago</span>
                        </li>
                        <li className="py-3">
                            <span className="font-semibold text-gray-700">Samuel Lee</span> updated their profile
                            <span className="text-sm text-gray-500"> 4 hours ago</span>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    );
};

export default Dashboard;
