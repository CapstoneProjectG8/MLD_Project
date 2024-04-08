import { Card, CardContent, Grid, Typography } from '@mui/material';

const image1 = require('./icon/diemdanh.png');
const image2 = require('./icon/hocbadientu.png');
const image3 = require('./icon/kdcl.png');
const image4 = require('./icon/scn.png');
const image5 = require('./icon/pcgd.png');
const image6 = require('./icon/hanhkiem.png');
const image7 = require('./icon/hosogiaoduc.png');
const image8 = require('./icon/lichbaogiang.png');
const image9 = require('./icon/lichcongtac.png');
const image10 = require('./icon/nenep.png');
const image11 = require('./icon/nhansu.png');
const image12 = require('./icon/quanlygiaoan.png');
const image13 = require('./icon/quanlylophoc.png');
const image14 = require('./icon/quanlythanhtoan.png');
const image15 = require('./icon/tongket.png');
const image16 = require('./icon/vietnhanxet.png');
const image17 = require('./icon/diemdanh.png');
const image18 = require('./icon/sodaubai.png');
const image19 = require('./icon/sodiem.png');
const image20 = require('./icon/sohocba.png');
const image21 = require('./icon/thongkebaocao.png');




interface Data {
  id: number;
  image: string;
  description: string;
}

const data: Data[] = [
  {
    id: 1,
    image: image1, 
    description: "Điểm danh",
  },
  {
    id: 2,
    image: image2, 
    description: "Học bạ điện tử",
  },
  {
    id: 1,
    image: image3, 
    description: "Kiểm định chất lượng",
  },
  // {
  //   id: 2,
  //   image: image4,
  //   description: "Sổ chủ nhiệm",
  // },
  {
    id: 5,
    image: image5, 
    description: "PC giảng dạy",
  },
  {
    id: 6,
    image: image6, 
    description: "Hạnh kiểm",
  },
  {
    id: 7,
    image: image7, 
    description: "Hồ sơ giáo dục",
  },
  {
    id: 8,
    image: image8, 
    description: "Kế hoạch dạy học",
  },
  {
    id: 9,
    image: image9, 
    description: "Lịch công tác",
  },
  {
    id: 10,
    image: image10, 
    description: "Nề nếp",
  },
  {
    id: 11,
    image: image11,
    description: "Nhân sự giáo viên",
  },
  {
    id: 12,
    image: image12,
    description: "Quản lý giáo án",
  },
  {
    id: 13,
    image: image13, 
    description: "Quản lý lớp học",
  },
  {
    id: 21,
    image: image21, 
    description: "Thống kê báo cáo",
  },
  {
    id: 14,
    image: image14, 
    description: "Quản lý thanh toán",
  },
  // {
  //   id: 20,
  //   image: image20,
  //   description: "Xuất sổ học bạ",
  // },
  {
    id: 15,
    image: image15, 
    description: "Tổng kết",
  },
  {
    id: 16,
    image: image16, 
    description: "Nhận xét",
  },
  // {
  //   id: 17,
  //   image: image17,
  //   description: "Điểm danh",
  // },
  {
    id: 18,
    image: image18, 
    description: "Sổ đầu bài",
  },
  {
    id: 19,
    image: image19, 
    description: "Sổ điểm",
  },

];

function Icon() {
  return(
    <>
      <style>
        {`
          .MuiGrid-item img { 
            width: 70px;
            height: 70px;
            object-fit: cover; 
          } 
        `}
      </style>
      <div>
        <CardContent>
          <Grid container spacing={2}>
            {data.map((item) => (
              <Grid item xs={2} key={item.id}>
                <img src={item.image} alt={item.description} />
                <Typography variant="body2" component="p">
                  {item.description}
                </Typography>
              </Grid>
            ))}
          </Grid>
        </CardContent>

      </div>
    </>
  )
}

export default Icon;