import {Injectable} from '@angular/core'
import {CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router} from '@angular/router'
import { Observable } from 'rxjs';
import { UserService }from '../services/user.service'


@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private userService: UserService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean>|Promise<boolean>|boolean {
    let logged = this.userService.isLoggedIn();  
        if(!logged){
            this.router.navigate(['/login']);
        }
    return 
  }
}