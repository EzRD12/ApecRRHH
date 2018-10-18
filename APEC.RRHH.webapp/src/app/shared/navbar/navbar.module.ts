import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from './navbar.component';
import { AccountService } from '../../services/account.service';

@NgModule({
    imports: [ RouterModule, CommonModule ],
    declarations: [ NavbarComponent ],
    exports: [ NavbarComponent ],
    providers: [AccountService]
})

export class NavbarModule {}
