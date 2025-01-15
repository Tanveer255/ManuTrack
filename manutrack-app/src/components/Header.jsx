import React from 'react';
import PropTypes from 'prop-types';

function Header({ title }) {
    return (
        <header className="bg-gray-800 text-white p-4">
            <h1>{title}</h1>
            <h1>header</h1>
        </header>
    );
}
export default Header;