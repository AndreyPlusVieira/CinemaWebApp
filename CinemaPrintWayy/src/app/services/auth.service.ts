import { Injectable } from '@angular/core';
import {
  Router,
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { Security } from '../util/security.util';

@Injectable()
export class AuthService implements CanActivate {
  constructor(private router: Router) {}

  canActivate():
    | boolean
    | UrlTree
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree> {
    const token = Security.getToken();
    if (!token) {
      this.router.navigate(['/login']);
      return false;
    } else {
      return true;
    }
  }
}
