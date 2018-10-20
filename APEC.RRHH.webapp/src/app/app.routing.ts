import { Routes } from '@angular/router';
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
                path: 'home',
                loadChildren: './dashboard/dashboard.module#DashboardModule',
            },
            {
                path: 'profile',
                loadChildren: './user/user.module#UserModule',
            },
            {
                path: 'candidate',
                loadChildren: './candidate/candidate.module#CandidateModule',
            },
            {
                path: 'interview',
                loadChildren: './interview/interview.module#InterviewModule',
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
