import { Component, OnInit } from '@angular/core';
import { Form, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/models/User';
import { DataService } from 'src/app/services/data.service';
import { Security } from 'src/app/util/security.util';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  public form: any = FormGroup;

  constructor(
    private data: DataService,
    private fb: FormBuilder,
    private router: Router
  ) {
    this.form = this.fb.group({
      email: [
        '',
        Validators.compose([Validators.minLength(3), Validators.required]),
      ],
      senha: ['', Validators.compose([Validators.required])],
    });
  }

  ngOnInit(): void {
    const token = Security.getToken();
  }

  setUser(user: User, token: string) {
    Security.set(user, token);
  }

  submit() {
    console.log('dado');

    this.data.authenticate(this.form.value).subscribe(
      (dado: any) => {
        this.setUser(this.form.value.email, dado);

        if (dado) {
          this.router.navigate(['/home']);
        } else {
          Security.clear();
          this.router.navigate(['/movie']);
        }
      },
      (err) => {
        alert(`Usuario ou senha incorreto`);
        window.location.reload();
      }
    );
  }

  token(): boolean {
    if (Security.hasToken()) {
      return true;
    } else {
      return false;
    }
  }

  logout() {
    Security.clear();
    this.router.navigate(['/']);
  }
}
