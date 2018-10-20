import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { AccountService } from '../services/account.service';
import { SharedModule } from '../shared/shared.module';
import { UserComponent } from './user.component';
import { PreparationComponent } from './preparation/preparation.component';
import { WorkExperiencesComponent } from './work-experiences/work-experiences.component';
import { ToastNotificationService } from '../services/toast-notification.service';
import { CompetenceService } from '../services/competence.service';
import { LanguageService } from '../services/language.service';

const routes = [
    {
        path: '',
        component: UserComponent
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
    declarations: [UserComponent, PreparationComponent, WorkExperiencesComponent],
    providers: [AccountService, ToastNotificationService, CompetenceService, LanguageService]
})
export class UserModule {
}
