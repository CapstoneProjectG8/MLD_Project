import type { Notice } from '@/interface/layout/notice.interface';

import { intercepter, mock } from '../config';

const mockNoticeList: Notice<'all'>[] = [
  {
    id: '000000001',
    avatar: 'https://gw.alipayobjects.com/zos/rmsportal/ThXAXghbEsBCCSDihZxY.png',
    title: '',
    datetime: '2023-08-09',
    type: 'notifiction',
  },
  {
    id: '000000002',
    avatar: 'https://gw.alipayobjects.com/zos/rmsportal/OKJXDXrmkNshAMvwtvhu.png',
    title: '',
    datetime: '2024-04-04',
    type: 'notification',
  },
  {
    id: '000000003',
    avatar: 'https://gw.alipayobjects.com/zos/rmsportal/kISTdvpyTAhtGxpovNWd.png',
    title: '',
    datetime: '2024-04-03',
    read: true,
    type: 'notification',
  },
  {
    id: '000000004',
    avatar: 'https://gw.alipayobjects.com/zos/rmsportal/GvqBnKhFgObvnSGkDsje.png',
    title: '',
    datetime: '2024-04-03',
    type: 'notification',
  },
  {
    id: '000000005',
    avatar: 'https://gw.alipayobjects.com/zos/rmsportal/ThXAXghbEsBCCSDihZxY.png',
    title: '',
    datetime: '2024-04-03',
    type: 'notification',
  },
  {
    id: '000000006',
    avatar: 'https://gw.alipayobjects.com/zos/rmsportal/fcHMVNCjPOsbUGdEduuv.jpeg',
    title: '',
    description: '',
    datetime: '2024-04-03',
    type: 'message',
    clickClose: true,
  },
  {
    id: '000000007',
    avatar: 'https://gw.alipayobjects.com/zos/rmsportal/fcHMVNCjPOsbUGdEduuv.jpeg',
    title: '',
    description: '',
    datetime: '2024-04-03',
    type: 'message',
    clickClose: true,
  },
  {
    id: '000000008',
    avatar: 'https://gw.alipayobjects.com/zos/rmsportal/fcHMVNCjPOsbUGdEduuv.jpeg',
    title: '',
    description: '',
    datetime: '2024-04-03',
    type: 'message',
    clickClose: true,
  },
  {
    id: '000000009',
    title: '',
    description: '',
    extra: '',
    status: 'todo',
    type: 'event',
  },
  {
    id: '000000010',
    title: '',
    description: '',
    extra: '',
    status: 'urgent',
    type: 'event',
  },
  {
    id: '000000011',
    title: '',
    description: '',
    extra: '',
    status: 'doing',
    type: 'event',
  },
  {
    id: '000000012',
    title: '',
    description: '',
    extra: '',
    status: 'processing',
    type: 'event',
  },
];

mock.mock('/user/notice', 'get', intercepter(mockNoticeList));
