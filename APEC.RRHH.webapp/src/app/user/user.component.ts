import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Competence } from '../models/competence';
import { Language } from '../models/language';
import { Preparation } from '../models/preparation';
import { UserProfile } from '../models/user-profile';
import { WorkExperience } from '../models/work-experience';
import { AccountService } from '../services/account.service';
import { CompetenceService } from '../services/competence.service';
import { LanguageService } from '../services/language.service';
import { ToastNotificationService, ToastType } from '../services/toast-notification.service';

@Component({
    selector: 'user-cmp',
    moduleId: module.id,
    templateUrl: 'user.component.html'
})

export class UserComponent implements OnInit {

    updateUserForm: FormGroup;
    user: UserProfile;
    preparations: Preparation[] = [];
    workExperiences: WorkExperience[] = [];
    competences: Competence[] = [];
    userCompetences = 0;
    userLanguages = 0;
    userPreparations = 0;
    languages: Language[] = [];
    isDataLoading = true;

    constructor(private accountService: AccountService,
        private formBuilder: FormBuilder,
        private competenceService: CompetenceService,
        private languageService: LanguageService,
        private toastNotificationService: ToastNotificationService) {

    }

    ngOnInit() {
        this.buildForm();
        const currentUser = this.accountService.currentUser;
        this.accountService.getUser(currentUser.id).then((userProfile) => {
            this.setUserSetting(userProfile);
            this.isDataLoading = false;
        });

        this.competenceService.getCompetencesAvailables().then((data) => {
            this.competences = data.operationResult;
        });
        this.languageService.getLanguagesAvailables().then((data) => {
            this.languages = data.operationResult;
        });
    }

    private setUserSetting(userProfile: UserProfile) {
        this.user = userProfile;
        this.updateUserForm.patchValue(this.user);
        this.preparations = this.user.preparations;
        this.userCompetences = this.user.competences.length;
        this.userLanguages = this.user.languages.length;
        this.userPreparations = this.user.preparations.length;
        this.workExperiences = this.user.workExperiences;
    }

    updateUser() {
        if (this.updateUserForm.invalid) {
            this.displayToast('Error en formulario', 'Favor verifique que la informacion suministrada este correctamente',
                ToastType.Warning);
            return;
        }

        const userUpdated = this.updateUserForm.getRawValue();

        if (userUpdated.password !== userUpdated.passwordConfirmation) {
            this.displayToast('Error en formulario', 'La confirmacion de contraseña no coincide',
                ToastType.Warning);
            return;
        }
        userUpdated.preparations = this.preparations;
        userUpdated.workExperiences = this.workExperiences;
        userUpdated.id = this.user.id;
        userUpdated.currentRole = this.user.currentRole;
        console.log(userUpdated);
        this.accountService.updateUser(userUpdated).then(result => {
            this.setUserSetting(result.operationResult);
            this.displayToast('Actualizacion de usuario', 'Operacion exitosa', ToastType.Success);
        }).catch(error => console.log(error));
    }

    buildForm() {
        this.updateUserForm = this.formBuilder.group({
            email: [null, [Validators.email]],
            password: [null, [Validators.required]],
            passwordConfirmation: [null, [Validators.required]],
            name: [null, [Validators.required]],
            lastName: [null, [Validators.required]],
            identificationType: [null, [Validators.required]],
            identification: [1, [Validators.required]],
            birthdate: [null, [Validators.required]],
            competences: new FormControl(),
            languages: new FormControl()
        });
    }

    displayToast(title: string, message: string, toastType: ToastType): void {
        this.toastNotificationService.show({
            title: title,
            message: message
        }, toastType);
    }
}
