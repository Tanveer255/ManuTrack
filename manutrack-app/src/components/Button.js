import React from 'react';
import PropTypes from 'prop-types';
import { Button as FlowbiteButton } from 'flowbite-react';

const Button = ({ text, onClick, type = 'button', color = 'blue', size = 'md', disabled = false }) => {
    return (
        <FlowbiteButton
            type={type}
            color={color}
            size={size}
            onClick={onClick}
            disabled={disabled}
            className="w-full"
        >
            {text}
        </FlowbiteButton>
    );
};

Button.propTypes = {
    text: PropTypes.string.isRequired,
    onClick: PropTypes.func.isRequired,
    type: PropTypes.oneOf(['button', 'submit', 'reset']),
    color: PropTypes.oneOf(['blue', 'gray', 'green', 'red', 'yellow', 'purple']),
    size: PropTypes.oneOf(['xs', 'sm', 'md', 'lg']),
    disabled: PropTypes.bool,
};

export default Button;
