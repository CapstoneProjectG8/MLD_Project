import type { MenuList } from '@/interface/layout/menu.interface';

import { intercepter, mock } from '../config';

const mockMenuList: MenuList = [
  {
    code: 'dashboard',
    label: {
      zh_CN: 'Bảng điều khiển',
      en_US: 'Dashboard',
    },
    icon: 'dashboard',
    path: '/dashboard',
  },
  {
    code: 'documentation',
    label: {
      zh_CN: 'Tài liệu 1',
      en_US: 'Documentation 1',
    },
    icon: 'documentation',
    path: '/documentation',
  },
  {
    code: 'documentation',
    label: {
      zh_CN: 'Tài liệu 2',
      en_US: 'Documentation 2',
    },
    icon: 'documentation',
    path: '/documentation2',
  },
  {
    code: 'documentation',
    label: {
      zh_CN: 'Tài liệu 3',
      en_US: 'Documentation 3',
    },
    icon: 'documentation',
    path: '/documentation3',
  },
  {
    code: 'documentation',
    label: {
      zh_CN: 'Tài liệu 4',
      en_US: 'Documentation 4',
    },
    icon: 'documentation',
    path: '/documentation4',
  },
  {
    code: 'documentation',
    label: {
      zh_CN: 'Tài liệu 5',
      en_US: 'Documentation 5',
    },
    icon: 'documentation',
    path: '/documentation5',
  },
  {
    code: 'guide',
    label: {
      zh_CN: 'Hướng dẫn',
      en_US: 'Guide',
    },
    icon: 'guide',
    path: '/guide',
  },
  {
    code: 'permission',
    label: {
      zh_CN: 'Phân quyền',
      en_US: 'Permission',
    },
    icon: 'permission',
    path: '/permission',
    children: [
      {
        code: 'routePermission',
        label: {
          zh_CN: 'Quyền truy cập',
          en_US: 'Route Permission',
        },
        path: '/permission/route',
      },
      {
        code: 'notFound',
        label: {
          zh_CN: '404',
          en_US: '404',
        },
        path: '/permission/404',
      },
    ],
  },
];

mock.mock('/user/menu', 'get', intercepter(mockMenuList));
