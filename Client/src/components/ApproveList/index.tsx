import * as React from 'react';
import { useTheme } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableFooter from '@mui/material/TableFooter';
import TablePagination from '@mui/material/TablePagination';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import IconButton from '@mui/material/IconButton';
import FirstPageIcon from '@mui/icons-material/FirstPage';
import KeyboardArrowLeft from '@mui/icons-material/KeyboardArrowLeft';
import KeyboardArrowRight from '@mui/icons-material/KeyboardArrowRight';
import LastPageIcon from '@mui/icons-material/LastPage';
import moment from 'moment';
import { TableHead } from '@mui/material';
import "./style.scss"
import { CheckCircleOutline, DoDisturb, TaskAltSharp } from '@mui/icons-material';

interface TablePaginationActionsProps {
    count: number;
    page: number;
    rowsPerPage: number;
    onPageChange: (
        event: React.MouseEvent<HTMLButtonElement>,
        newPage: number,
    ) => void;
}

function TablePaginationActions(props: TablePaginationActionsProps) {
    const theme = useTheme();
    const { count, page, rowsPerPage, onPageChange } = props;

    const handleFirstPageButtonClick = (
        event: React.MouseEvent<HTMLButtonElement>,
    ) => {
        onPageChange(event, 0);
    };

    const handleBackButtonClick = (event: React.MouseEvent<HTMLButtonElement>) => {
        onPageChange(event, page - 1);
    };

    const handleNextButtonClick = (event: React.MouseEvent<HTMLButtonElement>) => {
        onPageChange(event, page + 1);
    };

    const handleLastPageButtonClick = (event: React.MouseEvent<HTMLButtonElement>) => {
        onPageChange(event, Math.max(0, Math.ceil(count / rowsPerPage) - 1));
    };

    return (
        <Box sx={{ flexShrink: 0, ml: 2.5 }}>
            <IconButton
                onClick={handleFirstPageButtonClick}
                disabled={page === 0}
                aria-label="first page"
            >
                {theme.direction === 'rtl' ? <LastPageIcon /> : <FirstPageIcon />}
            </IconButton>
            <IconButton
                onClick={handleBackButtonClick}
                disabled={page === 0}
                aria-label="previous page"
            >
                {theme.direction === 'rtl' ? <KeyboardArrowRight /> : <KeyboardArrowLeft />}
            </IconButton>
            <IconButton
                onClick={handleNextButtonClick}
                disabled={page >= Math.ceil(count / rowsPerPage) - 1}
                aria-label="next page"
            >
                {theme.direction === 'rtl' ? <KeyboardArrowLeft /> : <KeyboardArrowRight />}
            </IconButton>
            <IconButton
                onClick={handleLastPageButtonClick}
                disabled={page >= Math.ceil(count / rowsPerPage) - 1}
                aria-label="last page"
            >
                {theme.direction === 'rtl' ? <FirstPageIcon /> : <LastPageIcon />}
            </IconButton>
        </Box>
    );
}

function createData(id: number, creator: string, approver: string, date: Date, status: boolean) {
    return { id, creator, approver, date, status };
}

function createData2(id: number, creator: string, approver: string, date: Date) {
    return { id, creator, approver, date };
}

const rows1 = [
    createData(1, 'John', 'Alice', new Date(2024, 3, 1), true),
    createData(2, 'Alice', 'Bob', new Date(2024, 2, 28), false),
    createData(3, 'Emma', 'John', new Date(2024, 3, 2), true),
    createData(4, 'Bob', 'Emma', new Date(2024, 2, 30), true),
    createData(5, 'Sarah', 'Alice', new Date(2024, 2, 25), false),
    createData(6, 'Alice', 'John', new Date(2024, 3, 3), true),
].sort((a, b) => a.date.getTime() - b.date.getTime());

const rows2 = [
    createData2(1, 'John', 'Alice', new Date(2024, 3, 1)),
    createData2(2, 'Alice', 'Bob', new Date(2024, 2, 28)),
    createData2(3, 'Emma', 'John', new Date(2024, 3, 2)),
    createData2(4, 'Bob', 'Emma', new Date(2024, 2, 30)),
    createData2(5, 'Sarah', 'Alice', new Date(2024, 2, 25)),
    createData2(6, 'Alice', 'John', new Date(2024, 3, 3)),
].sort((a, b) => a.date.getTime() - b.date.getTime());

const rows3 = [
    createData(7, 'Alice', 'Emma', new Date(2024, 3, 5), false),
    createData(8, 'John', 'Sarah', new Date(2024, 3, 6), false),
    createData(9, 'Bob', 'John', new Date(2024, 3, 7), false),
    // Thêm các dữ liệu khác nếu cần
].sort((a, b) => a.date.getTime() - b.date.getTime());

const ApproveList = () => {
    const [page, setPage] = React.useState(0);
    const [rowsPerPage, setRowsPerPage] = React.useState(5);
    const [selectedList, setSelectedList] = React.useState<'completed' | 'rejected' | 'pending'>('completed');

    const handleChangePage = (
        event: React.MouseEvent<HTMLButtonElement> | null,
        newPage: number,
    ) => {
        setPage(newPage);
    };

    const handleChangeRowsPerPage = (
        event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
    ) => {
        setRowsPerPage(parseInt(event.target.value, 10));
        setPage(0);
    };

    return (
        <div>
            <div className="request-approve-switch">
                <span onClick={() => setSelectedList('completed')} className={`incompleted-approve ${selectedList === 'completed' ? "isClicked" : ""}`}>Đã duyệt</span>
                <span onClick={() => setSelectedList('rejected')} className={`rejected-approve ${selectedList === 'rejected' ? "isClicked" : ""}`}>Từ chối</span>
                <span onClick={() => setSelectedList('pending')} className={`pending-approve ${selectedList === 'pending' ? "isClicked" : ""}`}>Chờ duyệt</span>
            </div>
            {selectedList === 'completed' && (
                <RenderTable
                    rows={rows1}
                    page={page}
                    rowsPerPage={rowsPerPage}
                    emptyRows={rowsPerPage > 0 ? Math.max(0, (1 + page) * rowsPerPage - rows1.length) : 0}
                    handleChangePage={handleChangePage}
                    handleChangeRowsPerPage={handleChangeRowsPerPage}
                />
            )}
            {selectedList === 'rejected' && (
                <RenderTable
                    rows={rows2}
                    page={page}
                    rowsPerPage={rowsPerPage}
                    emptyRows={rowsPerPage > 0 ? Math.max(0, (1 + page) * rowsPerPage - rows2.length) : 0}
                    handleChangePage={handleChangePage}
                    handleChangeRowsPerPage={handleChangeRowsPerPage}
                />
            )}
            {selectedList === 'pending' && (
                <RenderTable
                    rows={rows3}
                    page={page}
                    rowsPerPage={rowsPerPage}
                    emptyRows={rowsPerPage > 0 ? Math.max(0, (1 + page) * rowsPerPage - rows3.length) : 0}
                    handleChangePage={handleChangePage}
                    handleChangeRowsPerPage={handleChangeRowsPerPage}
                />
            )}
        </div>
    );
}

const RenderTable = ({ rows, page, rowsPerPage, emptyRows, handleChangePage, handleChangeRowsPerPage }: any) => {
    return (
        <TableContainer component={Paper}>
            <Table aria-label="custom pagination table">
                <TableHead>
                    <TableRow sx={{ 'th': { border: 1 } }}>
                        <TableCell component="th" >
                            Người tạo
                        </TableCell>
                        <TableCell component="th" >
                            Người duyệt
                        </TableCell>
                        <TableCell align="center">
                            Ngày
                        </TableCell>
                        <TableCell align="center">
                            Trạng thái
                        </TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {(rowsPerPage > 0
                        ? rows.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                        : rows
                    ).map((row: any) => (
                        <TableRow key={row.id} sx={{ 'td': { border: 1 } }}>
                            <TableCell >
                                {row.creator}
                            </TableCell>
                            <TableCell>
                                {row.approver}
                            </TableCell>
                            <TableCell align="center">
                                {moment(row.date).format('DD-MM-YYYY')}
                            </TableCell>
                            <TableCell align="center">
                                {
                                    row.status ?
                                        <div style={{ display: 'flex', alignItems: "center", justifyContent: "center", backgroundColor: "#99FFFF", padding: "6px 12px", width: "130px", margin: "auto", cursor: 'pointer' }}> <CheckCircleOutline /> Chấp nhận</div>
                                        : <div style={{ display: 'flex', alignItems: "center", justifyContent: "center", backgroundColor: "#FF9999", padding: "6px 12px", width: "130px", margin: "auto", cursor: 'pointer' }}> <DoDisturb /> Từ chối</div>
                                }
                            </TableCell>
                        </TableRow>
                    ))}
                    {emptyRows > 0 && (
                        <TableRow style={{ height: 53 * emptyRows }}>
                            <TableCell colSpan={6} />
                        </TableRow>
                    )}
                </TableBody>
                <TableFooter>
                    <TableRow>
                        <TablePagination
                            rowsPerPageOptions={[5, 10, 25, { label: 'All', value: -1 }]}
                            colSpan={3}
                            count={rows.length}
                            rowsPerPage={rowsPerPage}
                            page={page}
                            slotProps={{
                                select: {
                                    inputProps: {
                                        'aria-label': 'rows per page',
                                    },
                                    native: true,
                                },
                            }}
                            onPageChange={handleChangePage}
                            onRowsPerPageChange={handleChangeRowsPerPage}
                            ActionsComponent={TablePaginationActions}
                        />
                    </TableRow>
                </TableFooter>
            </Table>
        </TableContainer>
    );
}

export default ApproveList;