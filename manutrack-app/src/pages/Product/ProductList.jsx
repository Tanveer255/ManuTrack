//function ProductList() {
//  return (
//    <p>Hello world!</p>
//  );
//}

//export default ProductList;


import React from 'react';
import DataTable from '../components/common/DataTable';

const ProductList = () => {
    const columns = React.useMemo(
        () => [
            { Header: 'ID', accessor: 'id' },
            { Header: 'Name', accessor: 'name' },
            { Header: 'Age', accessor: 'age' },
        ],
        []
    );

    const data = React.useMemo(
        () => [
            { id: 1, name: 'John Doe', age: 28 },
            { id: 2, name: 'Jane Smith', age: 34 },
            { id: 3, name: 'Sam Green', age: 45 },
        ],
        []
    );

    return (
        <div>
            <h1>ProductList</h1>
            <DataTable columns={columns} data={data} />
        </div>
    );
};

export default ProductList;