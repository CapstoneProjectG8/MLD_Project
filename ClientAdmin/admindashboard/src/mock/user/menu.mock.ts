import type { MenuList } from '@/interface/layout/menu.interface';

import { intercepter, mock } from '../config';

const mockMenuList: MenuList = [
  {
    code: 'documentation',
    label: {
      zh_CN: 'Tài liệu',
      en_US: 'Documentation',
    },
    icon: 'documentation',
    path: '/document',
    children: [
      {
        code: 'permission',
        label: {
          zh_CN: 'Tài liệu 1',
          en_US: 'Documentation 1',
        },
        path: '/documentation',
      },
      {
        code: 'permission',
        label: {
          zh_CN: 'Tài liệu 2',
          en_US: 'Documentation 2',
        },
        path: '/documentation2',
      },
      {
        code: 'permission',
        label: {
          zh_CN: 'Tài liệu 3',
          en_US: 'Documentation 3',
        },
        path: '/documentation3',
      },
      {
        code: 'permission',
        label: {
          zh_CN: 'Tài liệu 4',
          en_US: 'Documentation 4',
        },
        path: '/documentation4',
      },
      {
        code: 'permission',
        label: {
          zh_CN: 'Tài liệu 5',
          en_US: 'Documentation 5',
        },
        path: '/documentation5',
      },
    ],
  },
  {
    code: 'common',
    label: {
      zh_CN: 'Chung',
      en_US: 'Common',
    },
    icon: 'dashboard',
    path: '/permission',
    children: [
      {
        code: 'permission',
        label: {
          zh_CN: 'Lớp học',
          en_US: 'Class',
        },
        path: '/class',
      },
      {
        code: 'permission',
        label: {
          zh_CN: 'Curriculum Distribution',
          en_US: 'Curriculum Distribution',
        },
        path: '/curriculumDistribution',
      },
      {
        code: 'permission',
        label: {
          zh_CN: 'Teaching Equipment',
          en_US: 'Teaching Equipment',
        },
        path: '/teachingEquipment',
      },
      {
        code: 'permission',
        label: {
          zh_CN: 'Teaching Planner',
          en_US: 'Teaching Planner',
        },
        path: '/teachingPlanner',
      },
      {
        code: 'permission',
        label: {
          zh_CN: 'Subject',
          en_US: 'Subject',
        },
        path: '/subject',
      },
      {
        code: 'permission',
        label: {
          zh_CN: 'Grade',
          en_US: 'Grade',
        },
        path: '/grade',
      },
      {
        code: 'permission',
        label: {
          zh_CN: 'Specialized Department',
          en_US: 'Specialized Department',
        },
        path: '/specializedDepartment',
      },
      {
        code: 'permission',
        label: {
          zh_CN: 'Subject Room',
          en_US: 'Subject Room',
        },
        path: '/subjectRoom',
      },
    ],
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
        code: 'mangementAccount',
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
