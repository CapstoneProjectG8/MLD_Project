import { Suspense, lazy } from 'react';
import { Navigate } from 'react-router-dom';
import { RouteObject } from 'react-router';

import SidebarLayout from 'src/layouts/SidebarLayout';
import BaseLayout from 'src/layouts/BaseLayout';

import SuspenseLoader from 'src/components/Dashboard/SuspenseLoader';

const Loader = (Component) => (props) =>
  (
    <Suspense fallback={<SuspenseLoader />}>
      <Component {...props} />
    </Suspense>
  );


// Dashboards

const ELearning = Loader(lazy(() => import('src/content/dashboards/Crypto')));

// Applications

const Transactions = Loader(
  lazy(() => import('src/content/applications/Transactions'))
);
const UserProfile = Loader(
  lazy(() => import('src/content/applications/Users/profile'))
);
const UserSettings = Loader(
  lazy(() => import('src/content/applications/Users/settings'))
);

// Components


// Status

const Status404 = Loader(
  lazy(() => import('src/content/pages/Status/Status404'))
);
const Status500 = Loader(
  lazy(() => import('src/content/pages/Status/Status500'))
);
const StatusComingSoon = Loader(
  lazy(() => import('src/content/pages/Status/ComingSoon'))
);
const StatusMaintenance = Loader(
  lazy(() => import('src/content/pages/Status/Maintenance'))
);

const HomePage = Loader(
  lazy(() => import('./pages/HomePage'))
);

const ProfilePage = Loader(
  lazy(() => import('./pages/ProfilePage'))
);

const SubMenu1Page = Loader(
  lazy(() => import('./pages/SubMenu1'))
);

const SubMenu1DetailPage = Loader(
  lazy(() => import('./pages/SubMenu1Detail'))
);

const SubMenu2Page = Loader(
  lazy(() => import('./pages/SubMenu2'))
);

const SubMenu2DetailPage = Loader(
  lazy(() => import('./pages/SubMenu2Detail'))
);
const SubMenu3Page = Loader(
  lazy(() => import('./pages/SubMenu3'))
);

const SubMenu3DetailPage = Loader(
  lazy(() => import('./pages/SubMenu3Detail'))
);
const SubMenu4Page = Loader(
  lazy(() => import('./pages/SubMenu4'))
);

const SubMenu4DetailPage = Loader(
  lazy(() => import('./pages/SubMenu4Detail'))
);
const SubMenu5Page = Loader(
  lazy(() => import('./pages/SubMenu5'))
);

const SubMenu5DetailPage = Loader(
  lazy(() => import('./pages/SubMenu5Detail'))
);
const ScromPage = Loader(
  lazy(() => import('./pages/ScromPage'))
);

const ScromTypePage = Loader(
  lazy(() => import('./pages/ScromTypePage'))
);
const UploadScromPage = Loader(
  lazy(() => import('./pages/UploadScromPage'))
);

const UploadPhuLuc4Page = Loader(
  lazy(() => import('./pages/UploadPhuLuc4Page'))
);
const LoginPage = Loader(
  lazy(() => import('src/components/Login/Login'))
);
const SubMenu1DetailAd = Loader(
  lazy(() => import('src/content/pages/Components/SubMenu1Detail'))
);
const SubMenu2DetailAd = Loader(
  lazy(() => import('src/content/pages/Components/SubMenu2Detail'))
);
const SubMenu3DetailAd = Loader(
  lazy(() => import('src/content/pages/Components/SubMenu3Detail'))
);
const SubMenu4DetailAd = Loader(
  lazy(() => import('src/content/pages/Components/SubMenu4Detail'))
);
const SubMenu5DetailAd = Loader(
  lazy(() => import('src/content/pages/Components/SubMenu5Detail'))
);
const routes: RouteObject[] = [
  {
    path: 'error',
    element: <BaseLayout />,
    children: [
      {
        path: 'status',
        children: [
          {
            path: '',
            element: <Navigate to="404" replace />
          },
          {
            path: '404',
            element: <Status404 />
          },
          {
            path: '500',
            element: <Status500 />
          },
          {
            path: 'maintenance',
            element: <StatusMaintenance />
          },
          {
            path: 'coming-soon',
            element: <StatusComingSoon />
          }
        ]
      },
      {
        path: '*',
        element: <Status404 />
      }
    ]
  },
  {
    path: '/', // Updated - Direct root to dashboards/crypto
    element: <Navigate to="home" replace />
  },
  {
    path: 'home',
    element: <HomePage />
  },
  {
    path: 'profile',
    element: <ProfilePage />
  },
  {
    path: 'sub-menu-1',
    element: <SubMenu1Page />
  },
  {
    path: 'sub-menu-1/detail-edit',
    element: <SubMenu1DetailPage />
  },
  {
    path: 'sub-menu-1/detail-view',
    element: <SubMenu1DetailPage />
  },
  {
    path: 'sub-menu-2',
    element: <SubMenu2Page />
  },
  {
    path: 'sub-menu-2/detail-edit',
    element: <SubMenu2DetailPage />
  },
  {
    path: 'sub-menu-2/detail-view',
    element: <SubMenu2DetailPage />
  },
  {
    path: 'sub-menu-3',
    element: <SubMenu3Page />
  },
  {
    path: 'sub-menu-3/detail-edit',
    element: <SubMenu3DetailPage />
  },
  {
    path: 'sub-menu-3/detail-view',
    element: <SubMenu3DetailPage />
  },
  {
    path: 'sub-menu-4',
    element: <SubMenu4Page />
  },
  {
    path: 'sub-menu-4/detail-edit',
    element: <SubMenu4DetailPage />
  },
  {
    path: 'sub-menu-4/detail-view',
    element: <SubMenu4DetailPage />
  },
  {
    path: 'sub-menu-5',
    element: <SubMenu5Page />
  },
  {
    path: 'sub-menu-5/detail-edit',
    element: <SubMenu5DetailPage />
  },
  {
    path: 'sub-menu-5/detail-view',
    element: <SubMenu5DetailPage />
  },
  {
    path: 'bai-giang-scrom',
    element: <ScromPage />,
    children: [
      {
        path: ':type',
        element: <ScromTypePage />
      }
    ]
  },
  {
    path: 'upload-bai-giang',
    element: <UploadScromPage />
  },
  {
    path: 'upload-sub-menu-4',
    element: <UploadPhuLuc4Page />
  },
  {
    path: 'login',
    element: <LoginPage />
  },
  {
    path: 'dashboards',
    element: <SidebarLayout />,
    children: [
      {
        path: '',
        element: <Navigate to="elearning" replace />
      },
      {
        path: 'elearning',
        element: <ELearning />
      }
    ]
  },{
    path: 'components',
    element: <SidebarLayout />,
    children: [
      {
        path: 'phuluc1',
        element: <SubMenu1DetailAd />
      },
      {
        path: 'phuluc2',
        element: <SubMenu2DetailAd />
      },
      {
        path: 'phuluc3',
        element: <SubMenu3DetailAd />
      },
      {
        path: 'phuluc4',
        element: <SubMenu4DetailAd />
      },
      {
        path: 'phuluc5',
        element: <SubMenu5DetailAd />
      },
    ]
  },

  {
    path: 'management',
    element: <SidebarLayout />,
    children: [
      {
        path: '',
        element: <Navigate to="transactions" replace />
      },
      {
        path: 'transactions',
        element: <Transactions />
      },
      {
        path: 'profile',
        children: [
          {
            path: '',
            element: <Navigate to="details" replace />
          },
          {
            path: 'details',
            element: <UserProfile />
          },
          {
            path: 'settings',
            element: <UserSettings />
          }
        ]
      }
    ]
  },
  {
    path: '/components',
    element: <SidebarLayout />,
    children: [
      {
        path: '',
        element: <Navigate to="" replace />
      }
    ]
  }
];

export default routes;
