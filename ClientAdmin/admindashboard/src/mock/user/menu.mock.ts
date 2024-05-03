import type { MenuList } from '@/interface/layout/menu.interface';

import { intercepter, mock } from '../config';

const mockMenuList: MenuList = [
  {
    code: 'permission',
    label: {
      zh_CN: 'Tài liệu 1',
      en_US: 'Documentation 1',
    },
    icon: 'documentation',
    path: '/documentation',
  },
  {
    code: 'permission',
    label: {
      zh_CN: 'Tài liệu 2',
      en_US: 'Documentation 2',
    },
    icon: 'documentation',
    path: '/documentation2',
  },
  {
    code: 'permission',
    label: {
      zh_CN: 'Tài liệu 3',
      en_US: 'Documentation 3',
    },
    icon: 'documentation',
    path: '/documentation3',
  },
  {
    code: 'permission',
    label: {
      zh_CN: 'Tài liệu 4',
      en_US: 'Documentation 4',
    },
    icon: 'documentation',
    path: '/documentation4',
  },
  {
    code: 'permission',
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
<<<<<<< HEAD
        code: 'mangementAccount',
=======
        code: 'account',
        label: {
          zh_CN: 'Tài khoản',
          en_US: 'Account',
        },
        path: '/permission/account',
      },
      {
        code: 'routePermission',
>>>>>>> main
        label: {
          zh_CN: 'Tài khoản',
          en_US: 'Account',
        },
        path: '/permission/account',
      },
    ],
  },
];

mock.mock('/user/menu', 'get', intercepter(mockMenuList));
