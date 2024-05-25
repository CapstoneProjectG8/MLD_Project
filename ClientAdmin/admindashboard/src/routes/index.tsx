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
const AccountPermission = lazy(() => import(/* webpackChunkName: "route-permission"*/ '@/pages/account'));
const Profile = lazy(() => import(/* webpackChunkName: "guide'"*/ '@/pages/profile'));
const Class = lazy(() => import(/* webpackChunkName: "guide'"*/ '@/pages/Class'));
const Curriculum = lazy(() => import(/* webpackChunkName: "guide'"*/ '@/pages/Curriculum'));
const Category = lazy(() => import(/* webpackChunkName: "guide'"*/ '@/pages/Category'));
const Equipment = lazy(() => import(/* webpackChunkName: "guide'"*/ '@/pages/TeachingEquipment'));
const Planner = lazy(() => import(/* webpackChunkName: "guide'"*/ '@/pages/TeachingPlanner'));
const Subject = lazy(() => import(/* webpackChunkName: "guide'"*/ '@/pages/Subject'));
const Grade = lazy(() => import(/* webpackChunkName: "guide'"*/ '@/pages/Grade'));
const Department = lazy(() => import(/* webpackChunkName: "guide'"*/ '@/pages/SpecializedDepartment'));
const Room = lazy(() => import(/* webpackChunkName: "guide'"*/ '@/pages/SubjectRoom'));

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
        path: 'dashboard',
        element: <WrapperRouteComponent element={<Dashboard />} titleId="title.dashboard" />,
      },
      {
        path: 'profile',
        element: <WrapperRouteComponent element={<Profile />} titleId="title.account" />,
      },
      {
        path: 'documentation',
        element: <WrapperRouteComponent element={<Documentation />} titleId="title.documentation" auth />,
      },
      {
        path: 'documentation2',
        element: <WrapperRouteComponent element={<Documentation2 />} titleId="title.documentation" auth />,
      },
      {
        path: 'documentation3',
        element: <WrapperRouteComponent element={<Documentation3 />} titleId="title.documentation" auth />,
      },
      {
        path: 'documentation4',
        element: <WrapperRouteComponent element={<Documentation4 />} titleId="title.documentation" auth />,
      },
      {
        path: 'documentation5',
        element: <WrapperRouteComponent element={<Documentation5 />} titleId="title.documentation" auth />,
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
        path: 'permission/account',
        element: <WrapperRouteComponent element={<AccountPermission />} titleId="title.permission.route" auth />,
      },
      {
        path: 'class',
        element: <WrapperRouteComponent element={<Class />} titleId="title.permission.button" auth />,
      },
      {
        path: 'curriculumDistribution',
        element: <WrapperRouteComponent element={<Curriculum />} titleId="title.permission.button" auth />,
      },
      {
        path: 'formCategory',
        element: <WrapperRouteComponent element={<Category />} titleId="title.permission.button" auth />,
      },
      {
        path: 'teachingEquipment',
        element: <WrapperRouteComponent element={<Equipment />} titleId="title.permission.button" auth />,
      },
      {
        path: 'teachingPlanner',
        element: <WrapperRouteComponent element={<Planner />} titleId="title.permission.button" auth />,
      },
      {
        path: 'subject',
        element: <WrapperRouteComponent element={<Subject />} titleId="title.permission.button" auth />,
      },
      {
        path: 'grade',
        element: <WrapperRouteComponent element={<Grade />} titleId="title.permission.button" auth />,
      },
      {
        path: 'specializedDepartment',
        element: <WrapperRouteComponent element={<Department />} titleId="title.permission.button" auth />,
      },
      {
        path: 'subjectRoom',
        element: <WrapperRouteComponent element={<Room />} titleId="title.permission.button" auth />,
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
