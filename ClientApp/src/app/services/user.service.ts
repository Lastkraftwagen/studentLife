import { Injectable } from "@angular/core"
import { HttpService } from '../services/httpservise'
import { Observable, from } from "rxjs"
import { map } from 'rxjs/operators'
import { User } from '../models/User'


@Injectable()
export class UserService {

    private user: User = null;
    constructor(private httpService: HttpService) { }

    public LogIn(email: string, password: string): Observable<boolean> {
        return this.httpService.LogIn(email, password).pipe(
            map(result => {
                this.user = result;
                localStorage.setItem('user',JSON.stringify(this.user));
                return this.isLoggedIn();
            })
        );

    }

    public isLoggedIn(): boolean {
        if(!this.user){
            this.user = JSON.parse(localStorage.getItem('user'));
        }
        return !!(this.user);
    }
}