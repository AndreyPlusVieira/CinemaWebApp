import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Security } from 'src/app/util/security.util';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  constructor(private router: Router) {}

  ngOnInit(): void {
    const token = Security.getToken();
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
