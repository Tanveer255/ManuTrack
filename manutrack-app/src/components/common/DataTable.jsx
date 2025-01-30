import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from '@shadcn/ui';

const DataTable = ({ columns, data }) => {
    return (
        <Table>
            <TableHeader>
                <TableRow>
                    {columns.map((column) => (
                        <TableHead key={column.accessor}>{column.header}</TableHead>
                    ))}
                </TableRow>
            </TableHeader>
            <TableBody>
                {data.map((row, rowIndex) => (
                    <TableRow key={rowIndex}>
                        {columns.map((column) => (
                            <TableCell key={column.accessor}>{row[column.accessor]}</TableCell>
                        ))}
                    </TableRow>
                ))}
            </TableBody>
        </Table>
    );
};

export default DataTable;