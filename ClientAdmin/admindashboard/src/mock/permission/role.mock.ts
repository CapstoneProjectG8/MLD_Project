import type { Role } from '@/interface/permission/role.interface';

import { intercepter, mock } from '../config';

const roles: Role[] = [
  {
    name: {
      zh_CN: 'Khách',
      en_US: 'Guest',
    },
    code: 'role_guest',
    id: 0,
    status: 'enabled',
  },
  {
    name: {
      zh_CN: 'Quản trị viên',
      en_US: 'Admin',
    },
    code: 'role_admin',
    id: 1,
    status: 'enabled',
  },
];

mock.mock('/permission/role', 'get', intercepter(roles));
