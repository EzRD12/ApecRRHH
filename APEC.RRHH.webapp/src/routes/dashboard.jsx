import Dashboard from 'views/Dashboard/Dashboard';
import UserProfile from 'views/UserProfile/UserProfile';
import TableList from 'views/TableList/TableList';
import Typography from 'views/Typography/Typography';
import Icons from 'views/Icons/Icons';
import Maps from 'views/Maps/Maps';
import Notifications from 'views/Notifications/Notifications';
import Upgrade from 'views/Upgrade/Upgrade';

const dashboardRoutes = [
  {
    path: '/dashboard',
    name: 'Inicio',
    icon: 'pe-7s-graph',
    component: Dashboard
  },
  { path: '/icons', name: 'Perfil', icon: 'pe-7s-user', component: Icons },
  {
    path: '/user',
    name: 'Personal',
    icon: 'pe-7s-users',
    component: UserProfile
  },
  {
    path: '/table',
    name: 'Vacantes',
    icon: 'pe-7s-note2',
    component: TableList
  },
  {
    path: '/typography',
    name: 'Candidatos',
    icon: 'pe-7s-news-paper',
    component: Typography
  },
  {
    path: '/maps',
    name: 'Administracion',
    icon: 'pe-7s-config',
    component: Maps
  },
  {
    path: '/notifications',
    name: 'Notifications',
    icon: 'pe-7s-bell',
    component: Notifications
  },
  { redirect: true, path: '/', to: '/dashboard', name: 'Dashboard' }
];

export default dashboardRoutes;
