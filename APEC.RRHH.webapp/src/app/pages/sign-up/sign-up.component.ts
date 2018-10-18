import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  registerForm: FormGroup;
  constructor(private builder: FormBuilder,
              private accountService: AccountService,
              private router: Router) { }

  ngOnInit() {
  }

  buildForm() {
    this.registerForm = this.builder.group({
      email: [null, [Validators.email]],
      password: [null, [Validators.required]],
      name: [null, [Validators.required, this.confirmationValidator]],
      lastName: [null, [Validators.required]],
      identificationType: [null, [Validators.required]],
      identification: [null, [Validators.required]],
      birthDate: [null, [Validators.required]],
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
    this.accountService.createUser(user).then((result) => {
      if (result.success) {
        this.router.navigate(['/profile']);
      } else {
        console.log(result.message);
      }
    });
  }

}
