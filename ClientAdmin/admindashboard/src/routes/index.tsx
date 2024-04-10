import type { FC } from 'react';
import type { RouteObject } from 'react-router';

import { lazy } from 'react';
import { Navigate } from 'react-router';
import { useRoutes } from 'react-router-dom';

import Dashboard from '@/pages/dashboard';
import LayoutPage from '@/pages/layout';
import LoginPage from '@/pages/login';

import WrapperRouteComponent from './config';

const NotFound = lazy(() => import(/* webpackChunkName: "404'"*/ '@/pages/404'));
const Documentation = lazy(() => import(/* webpackChunkName: "404'"*/ '@/pages/doucumentation'));
const Documentation2 = lazy(() => import(/* webpackChunkName: "404'"*/ '@/pages/doucumentation2'));
const Documentation3 = lazy(() => import(/* webpackChunkName: "404'"*/ '@/pages/doucumentation3'));
const Documentation4 = lazy(() => import(/* webpackChunkName: "404'"*/ '@/pages/doucumentation4'));
const Documentation5 = lazy(() => import(/* webpackChunkName: "404'"*/ '@/pages/doucumentation5'));
const Guide = lazy(() => import(/* webpackChunkName: "guide'"*/ '@/pages/guide'));
const RoutePermission = lazy(() => import(/* webpackChunkName: "route-permission"*/ '@/pages/permission/route'));

const routeList: RouteObject[] = [
  {
    path: '/login',
    element: <WrapperRouteComponent element={<LoginPage />} titleId="title.login" />,
  },
  {
    path: '/',
    element: <WrapperRouteComponent element={<LayoutPage />} titleId="" />,
    children: [
      {
        path: '',
        element: <Navigate to="dashboard" />,
      },
      {
        path: 'dashboard',
        element: <WrapperRouteComponent element={<Dashboard />} titleId="title.dashboard" />,
      },
      {
        path: 'documentation',
        element: <WrapperRouteComponent element={<Documentation />} titleId="title.documentation" />,
      },
      {
        path: 'documentation2',
        element: <WrapperRouteComponent element={<Documentation2 />} titleId="title.documentation" />,
      },
      {
        path: 'documentation3',
        element: <WrapperRouteComponent element={<Documentation3 />} titleId="title.documentation" />,
      },
      {
        path: 'documentation4',
        element: <WrapperRouteComponent element={<Documentation4 />} titleId="title.documentation" />,
      },
      {
        path: 'documentation5',
        element: <WrapperRouteComponent element={<Documentation5 />} titleId="title.documentation" />,
      },
      {
        path: 'guide',
        element: <WrapperRouteComponent element={<Guide />} titleId="title.guide" />,
      },
      {
        path: 'permission/route',
        element: <WrapperRouteComponent element={<RoutePermission />} titleId="title.permission.route" auth />,
      },

      {
        path: '*',
        element: <WrapperRouteComponent element={<NotFound />} titleId="title.notFount" />,
      },
    ],
  },
];

const RenderRouter: FC = () => {
  const element = useRoutes(routeList);

  return element;
};

export default RenderRouter;