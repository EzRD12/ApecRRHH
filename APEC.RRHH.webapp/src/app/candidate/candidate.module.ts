import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { CompetenceService } from '../services/competence.service';
import { DepartamentService } from '../services/departament.service';
import { EmployeeService } from '../services/employee.service';
import { JobService } from '../services/job.service';
import { LanguageService } from '../services/language.service';
import { SharedModule } from '../shared/shared.module';
import { CandidateComponent } from './candidate.component';
import { CandidateActiveComponent } from './candidate-active/candidate-active.component';
import { DashboardService } from '../services/dashboard.service';

const routes = [
    {
        path: '',
        component: CandidateComponent
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
    declarations: [CandidateComponent, CandidateActiveComponent],
    providers: [DepartamentService, LanguageService, JobService, CompetenceService, DashboardService]
})
export class CandidateModule {
}
