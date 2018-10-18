import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { en_US, NgZorroAntdModule, NZ_I18N } from 'ng-zorro-antd';
import { AppComponent } from './app.component';
import { AppRoutes } from './app.routing';
import { EmployeeComponent } from './employee/employee.component';
import { AdminComponent } from './layouts/admin/admin.component';
import { AuthComponent } from './layouts/auth/auth.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { ProfileComponent } from './profile/profile.component';
import { FooterModule } from './shared/footer/footer.module';
import { NavbarModule } from './shared/navbar/navbar.module';
import { SharedModule } from './shared/shared.module';
import { SidebarModule } from './sidebar/sidebar.module';
import { TableComponent } from './table/table.component';
import { UserComponent } from './user/user.component';


@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    TableComponent,
    AuthComponent,
    AdminComponent,
    NotFoundPageComponent,
    ProfileComponent,
    EmployeeComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(AppRoutes),
    SidebarModule,
    BrowserAnimationsModule,
    HttpClientModule,
    NavbarModule,
    FooterModule,
    SharedModule,
    NgZorroAntdModule
  ],
  providers: [
    { provide: NZ_I18N, useValue: en_US },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
