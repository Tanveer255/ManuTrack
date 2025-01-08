import React from 'react';

function DeleteItem({ item, items, setItems }) {
    const handleDelete = () => {
        setItems(items.filter((i) => i.id !== item.id));
    };

    return <button onClick={handleDelete}>Delete</button>;
}

export default DeleteItem;
