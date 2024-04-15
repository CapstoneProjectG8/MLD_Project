import { FC, useMemo, useState } from 'react';

import { Typography } from 'antd';

import { LocaleFormatter } from '@/locales';
import { useLocation } from 'react-router-dom';

const { Title, Paragraph } = Typography;

const div = <div style={{ height: 200 }}>2333</div>;

interface Row1 {
  stt: number | null;
  thietBiDayHoc: string;
  soLuong: number | null;
  baiThiNghiem: string;
  ghiChu: string;
}

interface Row2 {
  stt: number | null;
  tenPhong: string;
  soLuong: number | null;
  phamViNoiDung: string;
  ghiChu: string;
}

interface Row3 {
  stt: number | null;
  baiHoc: string;
  soTiet: number | null;
  yeuCau: string;
}

interface Row4 {
  stt: number | null;
  chuyenDe: string;
  soTiet: number | null;
  yeuCau: string;
}

const DocumentationPage1: FC = () => {
  const location = useLocation();
  const [rows1, setRows1] = useState<Row1[]>([{
      stt: null,
      thietBiDayHoc: '',
      soLuong: null,
      baiThiNghiem: '',
      ghiChu: '',
    },
  ]);
  const [rows2, setRows2] = useState<Row2[]>([{
      stt: null,
      tenPhong: '',
      soLuong: null,
      phamViNoiDung: '',
      ghiChu: '',
    },
  ]);
  const [rows3, setRows3] = useState<Row3[]>([{ stt: null, baiHoc: '', soTiet: null, yeuCau: '' }]);
  const [rows4, setRows4] = useState<Row4[]>([{ stt: null, chuyenDe: '', soTiet: null, yeuCau: '' }]);
  const [login, setLogin] = useState(false);
  const [open, setOpen] = useState(false);
  const [openAccept, setOpenAccept] = useState(false);
  const [openDeny, setOpenDeny] = useState(false);
  const [openReport, setOpenReport] = useState(false);

  const [truong, setTruong] = useState('');
  const [to, setTo] = useState('');
  const [hoadDong, setHoatDong] = useState('');
  const [khoiLop, setKhoiLop] = useState('');
  const [startYear, setStartYear] = useState('');
  const [endYear, setEndYear] = useState('');
  const [soLop, setSoLop] = useState('');
  const [soHocSinh, setSoHocSinh] = useState('');
  const [soHocSinhChuyenDe, setSoHocSinhChuyenDe] = useState('');
  const [soGiaoVien, setSoGiaoVien] = useState('');
  const [caoDang, setCaoDang] = useState('');
  const [daiHoc, setDaiHoc] = useState('');
  const [trenDaiHoc, setTrenDaiHoc] = useState('');
  const [tot, setTot] = useState('');
  const [kha, setKha] = useState('');
  const [chuaDat, setChuaDat] = useState('');

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };
  const handleClickOpenAccept = () => {
    setOpenAccept(true);
  };

  const handleCloseAccept = () => {
    setOpenAccept(false);
  };

  const handleClickOpenDeny = () => {
    setOpenDeny(true);
  };

  const handleCloseDeny = () => {
    setOpenDeny(false);
  };

  const handleClickOpenReport = () => {
    setOpenReport(true);
  };

  const handleCloseReport = () => {
    setOpenReport(false);
  };

  // const docs = useMemo(() => [
  //   { uri: require("./phuluc1.pdf") },
  // ], []);

  const handleAddRow1 = () => {
    const newRow = {
      stt: null,
      thietBiDayHoc: '',
      soLuong: null,
      baiThiNghiem: '',
      ghiChu: ''
    };
    setRows1([...rows1, newRow]);
  };
  const handleAddRow2 = () => {
    const newRow = {
      stt: null,
      tenPhong: '',
      soLuong: null,
      phamViNoiDung: '',
      ghiChu: ''
    };
    setRows2([...rows2, newRow]);
  };
  const handleAddRow3 = () => {
    const newRow = {
      stt: null,
      baiHoc: '',
      soTiet: null,
      yeuCau: '',
    };
    setRows3([...rows3, newRow]);
  };
  const handleAddRow4 = () => {
    const newRow = {
      stt: null,
      chuyenDe: '',
      soTiet: null,
      yeuCau: '',
    };
    setRows4([...rows4, newRow]);
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

  const handleRemoveRow3 = () => {
    if (rows1.length > 1) {
      const updatedRows = [...rows3];
      updatedRows.pop();
      setRows3(updatedRows);
    }
  };

  const handleRemoveRow4 = () => {
    if (rows1.length > 1) {
      const updatedRows = [...rows4];
      updatedRows.pop();
      setRows4(updatedRows);
    }
  };

  const displayRow1 = () => {
    setOpen(false)
  };

  return (
    <div>
      <Typography className="innerText">
        <div>Đang test theo kiểu anh An nhưng lỗi</div>
      </Typography>
    </div>
  );
};

export default DocumentationPage1;
