import { Injectable } from "@angular/core"
import { HttpService } from '../services/httpservise'
import { Observable, from } from "rxjs"
import { map } from 'rxjs/operators'
import { User } from '../models/User'
import { Player } from "../models/Player"
import { SavedGame } from "../models/SavedGame"
import { Record } from "../models/Record"


@Injectable()
export class UserService {
   
    
    user: User = null;
    gameId: string = null;
    constructor(private httpService: HttpService) { }

    public LogIn(email: string, password: string): Observable<boolean> {
        return this.httpService.LogIn(email, password).pipe(
            map(result => {
                if (result !== null) {
                    this.user = result;
                    localStorage.setItem('user', JSON.stringify(this.user));
                }
                return this.isLoggedIn();
            })
        );

    }
    GetRecords(): Observable<Record[]> {
        return this.httpService.GetRecords();
      }
    LoadGame(selectedId: number): Observable<boolean> {
        this.CreateGameID();
        return this.httpService.LoadGame(this.getUser().id, selectedId, this.gameId);
      }

    public CreateGame(player: Player): Observable<Player> {
        this.CreateGameID();
        return this.httpService.CreateGame(this.gameId, player);
    }

    public getUser(){
        if(this.user) return this.user;
        this.user = JSON.parse(localStorage.getItem('user'));
        return this.user;
    }

    public isLoggedIn(): boolean {
        if (!this.user) {
            this.user = JSON.parse(localStorage.getItem('user'));
        }
        return !!(this.user);
    }

    public isGameCreated(): boolean {
        if (!this.gameId) {
            this.gameId = localStorage.getItem('Id');
        }
        return !!(this.gameId);
    }

    public Do(): Observable<string> {
        return this.httpService.Do(this.gameId);
    }
    public GetSavedGames(): Observable<SavedGame[]> {
        return this.httpService.GetSavedGames(this.user.id);
    }

    private CreateGameID() {
        //LOCAL STORAGE
        if (!this.gameId) {
            this.gameId = this.user.id + this.getRandomInt(100);
            localStorage.setItem('Id', this.gameId);
        }

        // this.gameId = '1';
        // localStorage.setItem('Id', this.gameId);

    }

    private getRandomInt(max: number) {
        return Math.floor(Math.random() * Math.floor(max));
    }
}