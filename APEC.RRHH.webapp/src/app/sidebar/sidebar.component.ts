import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';
import { UserProfile } from '../models/user-profile';
import { Role } from '../enums/role.enum';

declare var $: any;

export interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
    roles: any[];
}

const AllRoles = [Role.CandidateEmployee, Role.Administrator, Role.Employee, Role.Manager, Role.Supervisor];
const RolesWithoutCandidate = [ Role.Administrator, Role.Employee, Role.Manager, Role.Supervisor];
const AdministrationRole = [Role.Administrator];

export const ROUTES: RouteInfo[] = [
    { path: '/home', title: 'Inicio', icon: 'ti-home', class: '', roles: AllRoles},
    { path: '/profile', title: 'Perfil', icon: 'ti-user', class: '', roles: AllRoles },
    { path: '/staff', title: 'Personal', icon: 'ti-view-list-alt', class: '', roles: RolesWithoutCandidate },
    { path: '/interview', title: 'Entrevistas', icon: 'ti-clipboard', class: '', roles: AdministrationRole },
    { path: '/candidate', title: 'Gestion de candidatos', icon: 'ti-bookmark', class: '', roles: AdministrationRole },
    { path: '/departament', title: 'Departamentos', icon: 'ti-map', class: '', roles: RolesWithoutCandidate },
    { path: '/administration', title: 'Administracion', icon: 'ti-world', class: '', roles: AdministrationRole }
];

@Component({
    moduleId: module.id,
    selector: 'app-sidebar-cmp',
    templateUrl: 'sidebar.component.html',
})

export class SidebarComponent implements OnInit {
    public menuItems: any[];
    currentUser: UserProfile;

    constructor(private accountService: AccountService) {
    }

    ngOnInit() {
        this.currentUser = this.accountService.currentUser;
        this.menuItems = ROUTES.filter(menuItem => menuItem);
    }

    roleValid(roles) {
        return roles.some(role => role === this.currentUser.currentRole);
    }
}
