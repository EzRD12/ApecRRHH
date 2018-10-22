import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { SharedModule } from '../shared/shared.module';
import { InterviewComponent } from './interview.component';
import { PendingComponent } from './pending/pending.component';
import { DashboardService } from '../services/dashboard.service';
import { HistoricalComponent } from './historical/historical.component';
import { InterviewService } from '../services/interview.service';
import { RequestedComponent } from './requested/requested.component';
import { JobService } from '../services/job.service';
import { ToastNotificationService } from '../services/toast-notification.service';

const routes = [
    {
        path: '',
        component: InterviewComponent
    }];

@NgModule({
    imports: [
        CommonModule,
        NgZorroAntdModule,
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        FormsModule,
        SharedModule
    ],
    declarations: [InterviewComponent, PendingComponent, HistoricalComponent, RequestedComponent],
    providers: [DashboardService, InterviewService, JobService, ToastNotificationService]
})
export class InterviewModule {
}
