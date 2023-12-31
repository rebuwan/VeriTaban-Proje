import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  CanActivateChild,
  Router,
  RouterStateSnapshot,
} from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate, CanActivateChild {

  constructor(
    private _router: Router
  ) {}

  canActivateChild(
    chieldRoute: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ) {
    return this.canActivate(chieldRoute, state);
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ) {

    if(!localStorage.getItem("accessToken")){
      this._router.navigateByUrl("/login");
      return false
    }

    return true;
  }
}
