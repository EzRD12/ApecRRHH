import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { DashboardComponent } from './dashboard.component';

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
        ReactiveFormsModule
    ],
    declarations: [DashboardComponent],
    exports: [DashboardComponent]
})
export class DashboardModule {
}
