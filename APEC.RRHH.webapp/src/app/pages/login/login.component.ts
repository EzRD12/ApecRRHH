import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { Router } from '@angular/router';
import { ToastNotificationService, ToastType } from '../../services/toast-notification.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  errorMessage: string;
  constructor(private formBuilder: FormBuilder,
    private accountService: AccountService,
    private router: Router,
    private toastNotificationService: ToastNotificationService) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  authenticate() {
    const email = this.loginForm.value.email;
    const password = this.loginForm.value.password;

    this.accountService.authenticate(email, password).then(result => {
      if (result.success) {
        this.router.navigate(['home']).then(() => {
          this.displayToast('Exito', 'Bienvenid@ sea ' + result.operationResult.fullName, ToastType.Success);
        });
      } else {
        this.errorMessage = result.message === 'InvalidCredentials' ? 'Credenciales invalidas' : result.message;
      }
    }).catch((error) => {
      if (error.error.message === 'InvalidCredentials') {
        this.errorMessage = 'Credenciales invalidas';
      } else {
        this.displayToast('Error', error.error.message, ToastType.Error);
      }
    });
  }

  displayToast(title: string, message: string, toastType: ToastType): void {
    this.toastNotificationService.show({
      title: title,
      message: message
    }, toastType);
  }

}
