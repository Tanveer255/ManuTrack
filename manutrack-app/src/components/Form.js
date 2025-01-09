import React, { useState } from 'react';
import PropTypes from 'prop-types';

const Form = ({ fields, onSubmit, buttonText = 'Submit' }) => {
    const [formData, setFormData] = useState(
        fields.reduce((acc, field) => ({ ...acc, [field.name]: '' }), {})
    );

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        onSubmit(formData);
    };

    return (
        <form onSubmit={handleSubmit} className="space-y-6 bg-white p-6 rounded-lg shadow-md max-w-lg mx-auto">
            {fields.map((field, index) => (
                <div key={index} className="form-group">
                    <label htmlFor={field.name} className="block text-sm font-medium text-gray-700 mb-1">
                        {field.label}
                    </label>
                    <input
                        type={field.type}
                        id={field.name}
                        name={field.name}
                        value={formData[field.name]}
                        onChange={handleChange}
                        placeholder={field.placeholder}
                        required={field.required}
                        className="form-input block w-full border border-gray-300 rounded-lg p-2 focus:ring-blue-500 focus:border-blue-500"
                    />
                </div>
            ))}
            <button
                type="submit"
                className="w-full bg-blue-600 text-white py-2 px-4 rounded-lg hover:bg-blue-700 transition duration-300"
            >
                {buttonText}
            </button>
        </form>
    );
};

Form.propTypes = {
    fields: PropTypes.arrayOf(
        PropTypes.shape({
            name: PropTypes.string.isRequired,
            label: PropTypes.string.isRequired,
            type: PropTypes.oneOf(['text', 'email', 'password', 'number']).isRequired,
            placeholder: PropTypes.string,
            required: PropTypes.bool,
        })
    ).isRequired,
    onSubmit: PropTypes.func.isRequired,
    buttonText: PropTypes.string,
};

export default Form;
