import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { Router } from '@angular/router';
import { ToastNotificationService, ToastType } from '../../services/toast-notification.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  registerForm: FormGroup;
  constructor(private builder: FormBuilder,
    private accountService: AccountService,
    private router: Router,
    private toastNotificationService: ToastNotificationService) { }

  ngOnInit() {
    this.buildForm();
  }

  buildForm() {
    this.registerForm = this.builder.group({
      email: [null, [Validators.email]],
      password: [null, [Validators.required]],
      passwordConfirmation: [null, [Validators.required]],
      name: [null, [Validators.required, this.confirmationValidator]],
      lastName: [null, [Validators.required]],
      identificationType: [null, [Validators.required]],
      identification: [null, [Validators.required]],
      birthdate: [null, [Validators.required]],
    });
  }

  confirmationValidator = (control: FormControl): { [s: string]: boolean } => {
    if (!control.value) {
      return { required: true };
    } else if (control.value !== this.registerForm.controls.password.value) {
      return { confirm: true, error: true };
    }
  }

  register() {
    const user = this.registerForm.getRawValue();

    if (user.password !== user.passwordConfirmation) {
      this.displayToast('Inconsistencia en contraseñas', 'Las contraseñas insertadas no coinciden', ToastType.Error);
      return;
    }
    this.accountService.createUser(user).then((result) => {
      if (result.success) {
        this.displayToast('Registro completo', 'La operacion ha sido exitosa', ToastType.Success);
        this.displayToast('Complete la configuracion', 'Finalize el proceso de registro con la configuracion de su perfil',
         ToastType.Info);
        this.router.navigate(['profile']);
      } else {
        this.displayToast('Error', result.message, ToastType.Error);
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
