import { Injectable } from "@angular/core"
import { HttpService } from '../services/httpservise'
import { Observable, from } from "rxjs"
import { map } from 'rxjs/operators'
import { User } from '../models/User'


@Injectable()
export class UserService {
   
    CreateGameID() {
        //LOCAL STORAGE
        if (!this.gameId) {
            this.gameId = this.user.id + this.getRandomInt(100);
        }

    }

    user: User = null;
    gameId = null;
    constructor(private httpService: HttpService) { }

    public LogIn(email: string, password: string): Observable<boolean> {
        return this.httpService.LogIn(email, password).pipe(
            map(result => {
                this.user = result;
                localStorage.setItem('user', JSON.stringify(this.user));
                return this.isLoggedIn();
            })
        );

    }

    public CreateGame(name: string): Observable<boolean> {
        return this.httpService.CreateGame(this.gameId, name);
    }

    public isLoggedIn(): boolean {
        if (!this.user) {
            this.user = JSON.parse(localStorage.getItem('user'));
        }
        return !!(this.user);
    }

    Do() : Observable<string> {
        return this.httpService.Do(this.gameId);
      }

    private getRandomInt(max: number) {
        return Math.floor(Math.random() * Math.floor(max));
    }
}