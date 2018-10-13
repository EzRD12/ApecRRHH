import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  constructor(private formBuilder: FormBuilder,
    private accountService: AccountService,
    private router: Router) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  authenticate() {
    console.log('some?');
    const email = this.loginForm.value.email;
    const password = this.loginForm.value.password;

    this.accountService.authenticate(email, password).then(result => {
      if (result.success) {
        this.router.navigate(['home']).then(() => {
        });
      }
    }).catch( (error) => console.log(error));

  }

}
