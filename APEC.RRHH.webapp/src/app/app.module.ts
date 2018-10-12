import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { en_US, NgZorroAntdModule, NZ_I18N } from 'ng-zorro-antd';
import { AdministrationComponent } from './administration/administration.component';
import { AppComponent } from './app.component';
import { AppRoutes } from './app.routing';
import { CandidateComponent } from './candidate/candidate.component';
import { DepartamentComponent } from './departament/departament.component';
import { EmployeeComponent } from './employee/employee.component';
import { IconsComponent } from './icons/icons.component';
import { AdminComponent } from './layouts/admin/admin.component';
import { AuthComponent } from './layouts/auth/auth.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { ProfileComponent } from './profile/profile.component';
import { FooterModule } from './shared/footer/footer.module';
import { NavbarModule } from './shared/navbar/navbar.module';
import { SidebarModule } from './sidebar/sidebar.module';
import { TableComponent } from './table/table.component';
import { UserComponent } from './user/user.component';


@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    TableComponent,
    IconsComponent,
    AuthComponent,
    AdminComponent,
    NotFoundPageComponent,
    ProfileComponent,
    CandidateComponent,
    EmployeeComponent,
    DepartamentComponent,
    AdministrationComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(AppRoutes),
    SidebarModule,
    HttpClientModule,
    NavbarModule,
    FooterModule,
    NgZorroAntdModule
  ],
  providers: [
    { provide: NZ_I18N, useValue: en_US },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
