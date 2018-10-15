import { Routes } from '@angular/router';
import { AdminComponent } from './layouts/admin/admin.component';
import { AuthComponent } from './layouts/auth/auth.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { TableComponent } from './table/table.component';
import { UserComponent } from './user/user.component';


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
                path: 'home',
                loadChildren: './dashboard/dashboard.module#DashboardModule',
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
                path: 'staff',
                loadChildren: './staff/staff.module#StaffModule',
            },
            {
                path: 'administration',
                loadChildren: './administration/administration.module#AdministrationModule',
            },
            {
                path: 'departament',
                loadChildren: './departament/departament.module#DepartamentModule',
            },
            {
                path: 'employee',
                loadChildren: './dashboard/dashboard.module#DashboardModule',
            }]
    }
    , {
        path: '',
        component: AuthComponent,
        children: [{
            path: 'pages',
            loadChildren: './pages/pages.module#PagesModule'
        }]
    },
    { path: '**', component: NotFoundPageComponent }
];
