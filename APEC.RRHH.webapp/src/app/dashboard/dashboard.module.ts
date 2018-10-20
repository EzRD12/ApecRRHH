import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { AccountService } from '../services/account.service';
import { DashboardService } from '../services/dashboard.service';
import { SharedModule } from '../shared/shared.module';
import { DashboardComponent } from './dashboard.component';
import { JobService } from '../services/job.service';
import { ToastNotificationService } from '../services/toast-notification.service';

const routes = [
    {
        path: '',
        component: DashboardComponent
    }
];

@NgModule({
    entryComponents: [DashboardComponent],
    imports: [
        CommonModule,
        NgZorroAntdModule,
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        SharedModule
    ],
    declarations: [DashboardComponent],
    providers: [DashboardService, AccountService, JobService, ToastNotificationService],
    exports: [DashboardComponent]
})
export class DashboardModule {
}
