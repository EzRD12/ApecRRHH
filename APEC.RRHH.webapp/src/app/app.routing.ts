import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { IconsComponent } from './icons/icons.component';
import { TableComponent } from './table/table.component';
import { UserComponent } from './user/user.component';
import { AdminComponent } from './layouts/admin/admin.component';
import { AuthComponent } from './layouts/auth/auth.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';


export const AppRoutes: Routes = [
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full',
    },
    {
        path: '',
        component: AdminComponent,
        children: [
            {
                path: '',
                redirectTo: 'home',
                pathMatch: 'full',
            },
            {
                path: 'home',
                component: DashboardComponent
            },
            {
                path: 'profile',
                component: UserComponent
            },
            {
                path: 'candidate',
                component: TableComponent
            },
            {
                path: 'administration',
                component: DashboardComponent
            },
            {
                path: 'departament',
                component: IconsComponent
            },
            {
                path: 'employee',
                component: DashboardComponent
            }]
    }
    , {
        path: '',
        component: AuthComponent,
        children: [{
            path: 'pages',
            loadChildren: './pages/pages.module#PagesModule'
        }]
    }
];
