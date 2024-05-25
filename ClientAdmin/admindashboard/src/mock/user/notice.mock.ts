import type { Message, Notice } from '@/interface/layout/notice.interface';

import axios from 'axios';
import { FC, useEffect } from 'react';

import { intercepter, mock } from '../config';

const mockNoticeList: Notice<'all'>[] = [];

axios.get<Message[]>('https://localhost:7241/api/Report/GetAllReports').then(res => {
  const cc = res.data.map((data: Message, index: number) => ({
    key: index.toString(),
    index: index.toString(),
    id: data.id,
    title: data.message || '',
    description: data.description || '',
    avatar: 'https://gw.alipayobjects.com/zos/rmsportal/ThXAXghbEsBCCSDihZxY.png',
    datetime: '2024-04-23',
    type: 'message',
    docId: data.docId,
    read: data.read,
  }));

  mockNoticeList.push(...cc);
  console.log(cc);
});

// export default db;
mock.mock('/user/notice', 'get', intercepter(mockNoticeList));
