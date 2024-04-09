import React, { useState } from 'react'
import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, FormControlLabel, Paper, Radio, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import './style.scss'
import { Add, Remove } from '@mui/icons-material';
import DocViewer, { DocViewerRenderers } from "@cyntler/react-doc-viewer";
import { useLocation } from 'react-router-dom';

interface Row {
    stt: number | null;
    chuDe: string;
    yeuCau: string;
    soTiet: number | null;
    thoiDiem: string;
    diaDiem: string;
    chuTri: string;
    phoiHop: string;
    dieuKien: string;
}

const SubMenu2DetailAd = () => {
    const location = useLocation()
    const [rows1, setRows1] = useState<Row[]>([{ stt: null, chuDe: '', yeuCau: '', soTiet: null, thoiDiem: '', diaDiem: '', chuTri: '', phoiHop: '', dieuKien: '' }]);
    const [rows2, setRows2] = useState<Row[]>([{ stt: null, chuDe: '', yeuCau: '', soTiet: null, thoiDiem: '', diaDiem: '', chuTri: '', phoiHop: '', dieuKien: '' }]);
    const [login, setLogin] = useState(false);
    const [open, setOpen] = useState(false);
    const [openReport, setOpenReport] = useState(false);

    const [truong, setTruong] = useState('');
    const [to, setTo] = useState('');
    const [startYear, setStartYear] = useState('');
    const [endYear, setEndYear] = useState('');
    const [khoiLop1, setKhoiLop1] = useState('');
    const [soHocSinh1, setSoHocSinh1] = useState('');
    const [khoiLop2, setKhoiLop2] = useState('');
    const [soHocSinh2, setSoHocSinh2] = useState('');
    const [khoiLop3, setKhoiLop3] = useState('');
    const [soHocSinh3, setSoHocSinh3] = useState('');
    const [toTruong, setToTruong] = useState('');
    const [hieuTruong, setHieuTruong] = useState('');
    const [dayOfWeek, setDayOfWeek] = useState('');
    const [dayOfMonth, setDayOfMonth] = useState('');
    const [month, setMonth] = useState('');
    const [year, setYear] = useState('');

    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const handleClickOpenReport = () => {
        setOpenReport(true);
    };

    const handleCloseReport = () => {
        setOpenReport(false);
    };

    const docs = [{ uri: require("./phuluc2.pdf") }]

    const handleAddRow1 = () => {
        const newRow = {
            stt: null,
            chuDe: '',
            yeuCau: '',
            soTiet: null,
            thoiDiem: '',
            diaDiem: '',
            chuTri: '',
            phoiHop: '',
            dieuKien: ''
        };
        setRows1([...rows1, newRow]);
    };
    const handleAddRow2 = () => {
        const newRow = {
            stt: null,
            chuDe: '',
            yeuCau: '',
            soTiet: null,
            thoiDiem: '',
            diaDiem: '',
            chuTri: '',
            phoiHop: '',
            dieuKien: ''
        };
        setRows2([...rows2, newRow]);
    };
    const handleRemoveRow1 = () => {
        if (rows1.length > 1) {
            const updatedRows = [...rows1];
            updatedRows.pop();
            setRows1(updatedRows);
        }
    };

    const handleRemoveRow2 = () => {
        if (rows2.length > 1) {
            const updatedRows = [...rows2];
            updatedRows.pop();
            setRows2(updatedRows);
        }
    };
    return (
        <div className='sub-menu-container'>
            {
                location.pathname?.includes("edit") ?
                    <div>
                        <div className='sub-menu-content'>
                            <div className="sub-menu-content-header">
                                <strong className='phu-luc'>Phụ lục II</strong>
                                <div className="sub-menu-content-header-title">
                                    <strong className="sub-menu-content-header-title-main">
                                        KHUNG KẾ HOẠCH TỔ CHỨC CÁC HOẠT ĐỘNG GIÁO DỤC CỦA TỔ CHUYÊN MÔN
                                    </strong>
                                    <div className="sub-menu-content-header-title-sub">
                                        <i>(Kèm theo Công văn số 5512/BGDĐT-GDTrH ngày 18 tháng 12 năm 2020 của Bộ GDĐT)</i>
                                    </div>
                                </div>
                                <div className="sub-menu-content-header-infomation">
                                    <div className='sub-menu-content-header-infomation-detail' >
                                        <div style={{ display: "flex" }}> <div><strong>TRƯỜNG: </strong><input type="text" placeholder='...........' onChange={e => setTruong(e.target.value)} /></div></div>
                                        <div style={{ display: "flex" }}> <div><strong>TỔ: </strong><input type="text" placeholder='...........' onChange={e => setTo(e.target.value)} /></div></div>
                                    </div>
                                    <div className='sub-menu-content-header-infomation-slogan'>
                                        <div> <strong>CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</strong></div>
                                        <div> <strong>Độc lập - Tự do - Hạnh phúc</strong></div>
                                    </div>
                                </div>
                            </div>

                            <div className="sub-menu-content-title">
                                <div><strong>KẾ HOẠCH TỔ CHỨC CÁC HOẠT ĐỘNG GIÁO DỤC CỦA TỔ CHUYÊN MÔN</strong></div>
                                <div>(Năm học 20<input type="text" placeholder='...........' style={{ width: "15px" }} onChange={e => setStartYear(e.target.value)} /> - 20<input type="text" placeholder='...........' style={{ width: "15px" }} onChange={e => setEndYear(e.target.value)} />)</div>
                            </div>

                            <div className='sub-menu-content-main'>
                                <div className="sub-menu-content-main-feature">
                                    <div className="sub-menu-content-main-feature-item">
                                        <div><strong>1. Khối lớp: </strong><input type="number" placeholder='..............' style={{ width: "50px" }} onChange={e => setKhoiLop1(e.target.value)} /></div>
                                        <div><strong>Số học sinh: </strong><input type="number" placeholder='..............' style={{ width: "50px" }} onChange={e => setSoHocSinh1(e.target.value)} /></div>
                                    </div>
                                    <div className="sub-menu-content-main-feature-table">
                                        <TableContainer component={Paper} className="table-list-sub-menu">
                                            <Table sx={{ minWidth: 450, fontSize: '12px', border: 1 }} aria-label="simple table" >
                                                <TableHead>
                                                    <TableRow sx={{ 'th': { border: 1 } }}>
                                                        <TableCell align="center">STT</TableCell>
                                                        <TableCell align="center">Chủ đề <br />(1)</TableCell>
                                                        <TableCell align="center">Yêu cầu cần đạt <br />(2)</TableCell>
                                                        <TableCell align="center">Số tiết <br />(3)</TableCell>
                                                        <TableCell align="center">Thời điểm <br />(4)</TableCell>
                                                        <TableCell align="center">Địa điểm <br />(5)</TableCell>
                                                        <TableCell align="center">Chủ trì <br />(6)</TableCell>
                                                        <TableCell align="center">Phối hợp <br />(7)</TableCell>
                                                        <TableCell align="center">Điều kiện thực hiên <br />(8)</TableCell>
                                                    </TableRow>
                                                </TableHead>
                                                <TableBody>
                                                    {rows1.map((row, index) => (
                                                        <TableRow key={index} sx={{ 'td': { border: 1 } }}>
                                                            <TableCell align="center">{index + 1}</TableCell>
                                                            <TableCell align="center">
                                                                <textarea
                                                                    value={row.chuDe}
                                                                    onChange={(e) => {
                                                                        const newValue = e.target.value;
                                                                        const updatedRows = [...rows1];
                                                                        updatedRows[index].chuDe = newValue;
                                                                        setRows1(updatedRows);
                                                                    }}
                                                                />
                                                            </TableCell>
                                                            <TableCell align="center">
                                                                <textarea
                                                                    value={row.yeuCau ?? null}
                                                                    onChange={(e) => {
                                                                        const newValue = e.target.value;
                                                                        const updatedRows = [...rows1];
                                                                        updatedRows[index].yeuCau = newValue;
                                                                        setRows1(updatedRows);
                                                                    }}
                                                                />
                                                            </TableCell>
                                                            <TableCell align="center">
                                                                <textarea
                                                                    value={row.soTiet ?? ''}
                                                                    onChange={(e) => {
                                                                        const newValue = parseInt(e.target.value);
                                                                        const updatedRows = [...rows1];
                                                                        updatedRows[index].soTiet = newValue;
                                                                        setRows1(updatedRows);
                                                                    }}
                                                                />
                                                            </TableCell>
                                                            <TableCell align="center">
                                                                <textarea
                                                                    value={row.thoiDiem}
                                                                    onChange={(e) => {
                                                                        const newValue = e.target.value;
                                                                        const updatedRows = [...rows1];
                                                                        updatedRows[index].thoiDiem = newValue;
                                                                        setRows1(updatedRows);
                                                                    }}
                                                                />
                                                            </TableCell>
                                                            <TableCell align="center">
                                                                <textarea
                                                                    value={row.diaDiem}
                                                                    onChange={(e) => {
                                                                        const newValue = e.target.value;
                                                                        const updatedRows = [...rows1];
                                                                        updatedRows[index].diaDiem = newValue;
                                                                        setRows1(updatedRows);
                                                                    }}
                                                                />
                                                            </TableCell>
                                                            <TableCell align="center">
                                                                <textarea
                                                                    value={row.chuTri}
                                                                    onChange={(e) => {
                                                                        const newValue = e.target.value;
                                                                        const updatedRows = [...rows1];
                                                                        updatedRows[index].chuTri = newValue;
                                                                        setRows1(updatedRows);
                                                                    }}
                                                                />
                                                            </TableCell>
                                                            <TableCell align="center">
                                                                <textarea
                                                                    value={row.phoiHop}
                                                                    onChange={(e) => {
                                                                        const newValue = e.target.value;
                                                                        const updatedRows = [...rows1];
                                                                        updatedRows[index].phoiHop = newValue;
                                                                        setRows1(updatedRows);
                                                                    }}
                                                                />
                                                            </TableCell>
                                                            <TableCell align="center">
                                                                <textarea
                                                                    value={row.dieuKien}
                                                                    onChange={(e) => {
                                                                        const newValue = e.target.value;
                                                                        const updatedRows = [...rows1];
                                                                        updatedRows[index].dieuKien = newValue;
                                                                        setRows1(updatedRows);
                                                                    }}
                                                                />
                                                            </TableCell>
                                                        </TableRow>
                                                    ))}
                                                </TableBody>
                                            </Table>
                                        </TableContainer>
                                        <div className='add-row-button'>
                                            <Add style={{ color: "black" }} className='add-row-icon' onClick={handleAddRow1} />
                                            <Remove style={{ color: "black" }} className='add-row-icon' onClick={handleRemoveRow1} />
                                        </div>
                                    </div>

                                </div>
                                <div className="sub-menu-content-main-feature">
                                    <div className="sub-menu-content-main-feature-item">
                                        <div><strong>2. Khối lớp: </strong><input type="number" placeholder='..............' style={{ width: "50px" }} onChange={e => setKhoiLop2(e.target.value)} /></div>
                                        <div><strong>Số học sinh: </strong><input type="number" placeholder='..............' style={{ width: "50px" }} onChange={e => setSoHocSinh2(e.target.value)} /></div>
                                    </div>
                                    <div className="sub-menu-content-main-feature-table">
                                        <TableContainer component={Paper} className="table-list-sub-menu">
                                            <Table sx={{ minWidth: 450, fontSize: '12px', border: 1 }} aria-label="simple table" >
                                                <TableHead>
                                                    <TableRow sx={{ 'th': { border: 1 } }}>
                                                        <TableCell align="center">STT</TableCell>
                                                        <TableCell align="center">Chủ đề <br />(1)</TableCell>
                                                        <TableCell align="center">Yêu cầu cần đạt <br />(2)</TableCell>
                                                        <TableCell align="center">Số tiết <br />(3)</TableCell>
                                                        <TableCell align="center">Thời điểm <br />(4)</TableCell>
                                                        <TableCell align="center">Địa điểm <br />(5)</TableCell>
                                                        <TableCell align="center">Chủ trì <br />(6)</TableCell>
                                                        <TableCell align="center">Phối hợp <br />(7)</TableCell>
                                                        <TableCell align="center">Điều kiện thực hiên <br />(8)</TableCell>
                                                    </TableRow>
                                                </TableHead>
                                                <TableBody>
                                                    {rows2.map((row, index) => (
                                                        <TableRow key={index} sx={{ 'td': { border: 1 } }}>
                                                            <TableCell align="center">{index + 1}</TableCell>
                                                            <TableCell align="center">
                                                                <textarea
                                                                    value={row.chuDe}
                                                                    onChange={(e) => {
                                                                        const newValue = e.target.value;
                                                                        const updatedRows = [...rows2];
                                                                        updatedRows[index].chuDe = newValue;
                                                                        setRows2(updatedRows);
                                                                    }}
                                                                />
                                                            </TableCell>
                                                            <TableCell align="center">
                                                                <textarea
                                                                    value={row.yeuCau ?? null}
                                                                    onChange={(e) => {
                                                                        const newValue = e.target.value;
                                                                        const updatedRows = [...rows2];
                                                                        updatedRows[index].yeuCau = newValue;
                                                                        setRows2(updatedRows);
                                                                    }}
                                                                />
                                                            </TableCell>
                                                            <TableCell align="center">
                                                                <textarea
                                                                    value={row.soTiet ?? ''}
                                                                    onChange={(e) => {
                                                                        const newValue = parseInt(e.target.value);
                                                                        const updatedRows = [...rows2];
                                                                        updatedRows[index].soTiet = newValue;
                                                                        setRows2(updatedRows);
                                                                    }}
                                                                />
                                                            </TableCell>
                                                            <TableCell align="center">
                                                                <textarea
                                                                    value={row.thoiDiem}
                                                                    onChange={(e) => {
                                                                        const newValue = e.target.value;
                                                                        const updatedRows = [...rows2];
                                                                        updatedRows[index].thoiDiem = newValue;
                                                                        setRows2(updatedRows);
                                                                    }}
                                                                />
                                                            </TableCell>
                                                            <TableCell align="center">
                                                                <textarea
                                                                    value={row.diaDiem}
                                                                    onChange={(e) => {
                                                                        const newValue = e.target.value;
                                                                        const updatedRows = [...rows2];
                                                                        updatedRows[index].diaDiem = newValue;
                                                                        setRows2(updatedRows);
                                                                    }}
                                                                />
                                                            </TableCell>
                                                            <TableCell align="center">
                                                                <textarea
                                                                    value={row.chuTri}
                                                                    onChange={(e) => {
                                                                        const newValue = e.target.value;
                                                                        const updatedRows = [...rows2];
                                                                        updatedRows[index].chuTri = newValue;
                                                                        setRows2(updatedRows);
                                                                    }}
                                                                />
                                                            </TableCell>
                                                            <TableCell align="center">
                                                                <textarea
                                                                    value={row.phoiHop}
                                                                    onChange={(e) => {
                                                                        const newValue = e.target.value;
                                                                        const updatedRows = [...rows2];
                                                                        updatedRows[index].phoiHop = newValue;
                                                                        setRows2(updatedRows);
                                                                    }}
                                                                />
                                                            </TableCell>
                                                            <TableCell align="center">
                                                                <textarea
                                                                    value={row.dieuKien}
                                                                    onChange={(e) => {
                                                                        const newValue = e.target.value;
                                                                        const updatedRows = [...rows2];
                                                                        updatedRows[index].dieuKien = newValue;
                                                                        setRows2(updatedRows);
                                                                    }}
                                                                />
                                                            </TableCell>
                                                        </TableRow>
                                                    ))}
                                                </TableBody>
                                            </Table>
                                        </TableContainer>
                                        <div className='add-row-button'>
                                            <Add style={{ color: "black" }} className='add-row-icon' onClick={handleAddRow2} />
                                            <Remove style={{ color: "black" }} className='add-row-icon' onClick={handleRemoveRow2} />
                                        </div>
                                    </div>
                                </div>
                                <div className="sub-menu-content-main-feature">
                                    <div className="sub-menu-content-main-feature-item">
                                        <div><strong>3. Khối lớp: </strong><input type="number" placeholder='..............' style={{ width: "50px" }} onChange={e => setKhoiLop3(e.target.value)} /></div>
                                        <div><strong>Số học sinh: </strong><input type="number" placeholder='..............' style={{ width: "50px" }} onChange={e => setSoHocSinh3(e.target.value)} /></div>
                                    </div>
                                </div>
                                <div className="sub-menu-content-main-note">
                                    <div><i>(1) Tên chủ đề tham quan, cắm trại, sinh hoạt tập thể, câu lạc bộ, hoạt động phục vụ cộng đồng.</i></div>
                                    <div><i>(2) Yêu cầu (mức độ) cần đạt của hoạt động giáo dục đối với các đối tượng tham gia.</i></div>
                                    <div><i>(3) Số tiết được sử dụng để thực hiện hoạt động.</i></div>
                                    <div><i>(4) Thời điểm thực hiện hoạt động (tuần/tháng/năm).</i></div>
                                    <div><i>(5) Địa điểm tổ chức hoạt động (phòng thí nghiệm, thực hành, phòng đa năng, sân chơi, bãi tập, cơ sở sản xuất, kinh doanh, tại di sản, tại thực địa...).</i></div>
                                    <div><i>(6) Đơn vị, cá nhân chủ trì tổ chức hoạt động.</i></div>
                                    <div><i>(7) Đơn vị, cá nhân phối hợp tổ chức hoạt động.</i></div>
                                    <div><i>(8) Cơ sở vật chất, thiết bị giáo dục, học liệu…</i></div>
                                </div>
                                <div className="sub-menu-content-main-signature">
                                    <div className='to-truong'>
                                        <div><strong>TỔ TRƯỞNG</strong></div>
                                        <div><i>(Ký và ghi rõ họ tên)</i></div>
                                        <br /> <br />
                                        <div>
                                            <input type="text" placeholder='................................................................' style={{ width: "150px" }} onChange={e => setToTruong(e.target.value)} />
                                        </div>
                                    </div>
                                    <div className="hieu-truong">
                                        <div>
                                            <input type="text" placeholder='.....................' style={{ width: "60px" }} onChange={e => setDayOfWeek(e.target.value)} />
                                            , ngày   <input type="number" placeholder='.....' style={{ width: "30px" }} onChange={e => setDayOfMonth(e.target.value)} />
                                            , tháng   <input type="number" placeholder='.....' style={{ width: "30px" }} onChange={e => setMonth(e.target.value)} />
                                            , năm 20   <input type="number" placeholder='.....' style={{ width: "30px" }} onChange={e => setYear(e.target.value)} />
                                        </div>
                                        <div>
                                            <strong>HIỆU TRƯỞNG</strong>
                                        </div>
                                        <div><i>(Ký và ghi rõ họ tên)</i></div>
                                        <br /><br />
                                        <div>
                                            <input type="text" placeholder='................................................................' style={{ width: "150px" }} onChange={e => setHieuTruong(e.target.value)} />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="sub-menu-content-action">
                            <Button onClick={handleClickOpen} >Xác nhận xét duyệt</Button>
                        </div>
                    </div> : <>
                        <DocViewer documents={docs} pluginRenderers={DocViewerRenderers}
                            config={{
                                header: {
                                    disableHeader: true,
                                    disableFileName: true,
                                    retainURLParams: true,
                                },
                                pdfVerticalScrollByDefault: true,
                            }}
                        />
                        <div className="sub-menu-infomation">
                            <div className="sub-menu-row">
                                <div><i>(Tài liệu chưa được thẩm định)</i></div>
                            </div>
                            <div className="sub-menu-row">
                                <div><strong>Nguồn: </strong> https://baigiang.violet.vn</div>
                                <div className='right-action' onClick={handleClickOpenReport}><strong><u className='underline-blue'>Báo tài liệu có sai sót</u></strong></div>
                            </div>
                            <div className="sub-menu-row">
                                <div><strong>Người gửi: </strong> <u className='underline-blue'>Sam Dung</u></div>
                                <div className='right-action'><strong><u className='underline-blue'>Nhắn tin cho tác giả</u></strong></div>
                            </div>
                            <div className="sub-menu-row">
                                <div><strong>Ngày gửi: </strong> 10h:34' 14-01-2024</div>
                                <div className='right-action'>
                                    <div className='share-facebook'>
                                        <img src="/facebook-circle-svgrepo-com.svg" alt="SVG" />
                                        <span>Chia sẻ</span>
                                        <span>0</span>
                                    </div>
                                </div>
                            </div>
                            <div className="sub-menu-row">
                                <div><strong>Dung lượng: </strong> 19/9 KB</div>
                            </div>
                            <div className="sub-menu-row">
                                <div><strong>Số lượt tải: </strong>25</div>
                                <div className='right-action'></div>
                            </div>
                            <div className="sub-menu-row">
                                <div><strong>Số lượt thích: </strong> 0 người</div>
                                <div className='right-action'></div>
                            </div>
                        </div>
                        <div>
                            <div className="sub-menu-action">
                                <div className="verify">
                                    <span>Tình trạng thẩm định:</span>
                                    <div style={{ display: "flex", columnGap: "10px" }}>
                                        <div className='action-button'>Chấp thuận</div>
                                        <div className='action-button'>Từ chối</div>
                                    </div>
                                </div>
                            </div>
                            <div className="sub-menu-note">
                                Ghi chú <br />
                                <textarea name="" id="" rows={8} ></textarea>
                            </div>
                        </div></>
            }
            <Dialog
                open={open}
                onClose={handleClose}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description"

            >
                <DialogTitle id="alert-dialog-title" style={{ textAlign: "center", fontWeight: 600 }}>
                    Bạn có chắc chắn không
                </DialogTitle>
                <DialogContent>
                    <DialogContentText id="alert-dialog-description" style={{ textAlign: "center", fontWeight: 600 }}>
                        Bạn có chắc muốn đưa phụ lục này vào xét duyệt
                    </DialogContentText>
                </DialogContent>
                <DialogActions >
                    <Button onClick={handleClose} style={{ color: "#000", fontWeight: 600 }} >Hủy bỏ</Button>
                    <Button onClick={handleClose} className='button-mui' autoFocus>
                        Đồng ý
                    </Button>
                </DialogActions>
            </Dialog>
            <Dialog
                open={openReport}
                onClose={handleCloseReport}
                maxWidth={"md"}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description"

            >
                <DialogTitle id="alert-dialog-title" style={{ textAlign: "center", fontWeight: 600 }}>
                    Báo cáo tài liệu
                </DialogTitle>

                {
                    login ? (
                        <>
                            <DialogContent>
                                <DialogContentText id="alert-dialog-description" style={{ textAlign: "left", backgroundColor: "#D9D9D9", borderRadius: "20px", padding: "20px" }}>
                                    <div className="report-row">
                                        <div className='report-title'>Tài liệu</div>
                                        <div className='report-detail'>
                                            Giáo án tài liệu A
                                        </div>
                                    </div>
                                    <div className="report-row">
                                        <div className='report-title'>
                                            Lý do báo cáo
                                        </div>
                                        <div className='report-detail' style={{ display: "flex", flexDirection: "column" }}>
                                            <FormControlLabel value="" control={<Radio />} label="Có lỗi kỹ thuật ..." />
                                            <FormControlLabel value="" control={<Radio />} label="Không dùng để dạy học" />
                                            <FormControlLabel value="" control={<Radio />} label="Vi phạm bản quyền" />
                                            <FormControlLabel value="" control={<Radio />} label="Lý do khác" />
                                        </div>
                                    </div>
                                    <div className="report-row">
                                        <div className='report-title'>Chi tiết lỗi</div>
                                        <div className='report-detail'>
                                            <span style={{ whiteSpace: "nowrap" }}>Đề nghị cung cấp lý do và chỉ ra các điểm không chính xác</span>
                                            <br />
                                            <textarea name="" id="" rows={10} />
                                        </div>
                                    </div>
                                </DialogContentText>
                            </DialogContent>
                            <DialogActions >
                                <Button onClick={handleCloseReport} style={{ color: "#000", fontWeight: 600 }} > Quay lại trang</Button>
                                <Button onClick={handleCloseReport} className='button-mui' autoFocus>
                                    Gửi báo cáo
                                </Button>
                            </DialogActions></>
                    ) : (
                        <>
                            <DialogContent>
                                <DialogContentText id="alert-dialog-description" style={{ textAlign: "left", fontWeight: 600, marginBottom: "12px" }}>
                                    Bạn cần đăng nhập để thực hiện chức năng
                                </DialogContentText>
                            </DialogContent>
                            <DialogActions >
                                <Button onClick={handleCloseReport} style={{ color: "#000", fontWeight: 600 }} >Hủy bỏ</Button>
                                <Button onClick={() => setLogin(true)} className='button-mui' autoFocus>
                                    Đăng nhập
                                </Button>
                            </DialogActions>
                        </>
                    )
                }
            </Dialog>
        </div >
    )
}

export default SubMenu2DetailAd