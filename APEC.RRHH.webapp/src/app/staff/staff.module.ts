import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { DepartamentService } from '../services/departament.service';
import { LanguageService } from '../services/language.service';
import { SharedModule } from '../shared/shared.module';
import { StaffComponent } from './staff.component';

const routes = [
    {
        path: '',
        component: StaffComponent
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
    declarations: [StaffComponent],
    providers: [DepartamentService, LanguageService]
})
export class StaffModule {
}
