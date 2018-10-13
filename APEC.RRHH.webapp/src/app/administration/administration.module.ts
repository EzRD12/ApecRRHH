import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { CompetenceService } from '../services/competence.service';
import { AdministrationComponent } from './administration.component';
import { CompetenceComponent } from './competence/competence.component';
import { LanguageComponent } from './language/language.component';
import { LanguageService } from '../services/language.service';
import { SharedModule } from '../shared/shared.module';

const routes = [
    {
        path: '',
        component: AdministrationComponent,
        children: [
            {
                path: 'competence',
                component: CompetenceComponent
            },
            {
                path: 'language',
                component: LanguageComponent
            },
        ]
    }
];

@NgModule({
    imports: [
        CommonModule,
        NgZorroAntdModule,
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        FormsModule,
        SharedModule
    ],
    declarations: [AdministrationComponent, CompetenceComponent, LanguageComponent],
    providers: [CompetenceService, LanguageService]
})
export class AdministrationModule {
}
