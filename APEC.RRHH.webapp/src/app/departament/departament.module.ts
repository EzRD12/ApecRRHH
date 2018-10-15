import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { DepartamentService } from '../services/departament.service';
import { LanguageService } from '../services/language.service';
import { SharedModule } from '../shared/shared.module';
import { DepartamentJobsComponent } from './departament-jobs/departament-jobs.component';
import { DepartamentComponent } from './departament.component';
import { JobComponent } from './job/job.component';
import { JobService } from '../services/job.service';
import { CompetenceService } from '../services/competence.service';

const routes = [
    {
        path: '',
        component: DepartamentComponent
    },
    {
        path: ':id',
        component: DepartamentJobsComponent
    },
    {
        path: ':id/:id',
        component: JobComponent
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
    declarations: [DepartamentComponent, JobComponent, DepartamentJobsComponent],
    providers: [DepartamentService, LanguageService, JobService, CompetenceService]
})
export class DepartamentModule {
}
