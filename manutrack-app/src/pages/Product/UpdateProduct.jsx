import React, { useState } from 'react';

function EditItem({ item, items, setItems }) {
    const [isEditing, setIsEditing] = useState(false);
    const [editedText, setEditedText] = useState(item.text);

    const handleSave = () => {
        setItems(
            items.map((i) => (i.id === item.id ? { ...i, text: editedText } : i))
        );
        setIsEditing(false);
    };

    return isEditing ? (
        <span>
            <input
                type="text"
                value={editedText}
                onChange={(e) => setEditedText(e.target.value)}
            />
            <button onClick={handleSave}>Save</button>
        </span>
    ) : (
        <button onClick={() => setIsEditing(true)}>Edit</button>
    );
}

export default EditItem;
