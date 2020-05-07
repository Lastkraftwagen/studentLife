import { Injectable } from "@angular/core"
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http"
import { Observable, from } from "rxjs"
import { map } from 'rxjs/operators'
import { User } from "../models/User";
import { Player } from "../models/Player";
import { EventModel } from "../models/EventModel";
import { EventResponse } from "../models/EventResponse";

@Injectable()
export class HttpService {
   
    
    constructor(private httpClient: HttpClient) { }

    public LogIn(email: string, password: string): Observable<User> {
        let payload = this.createHttpParams('email', email).set('password', password);
        return this.httpClient.post<User>("https://localhost:44393/api/LogIn", payload);
    }

    public CreateGame(Id: string, player: Player): Observable<Player> {
        let headers = new HttpHeaders({
            'Access-Control-Allow-Origin': `*`,
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        });
        let options = {
            headers: headers
        };
        let formData = {
            id: Id,
            player: player
        }
        return this.httpClient.post<Player>("https://localhost:44393/api/StartGame", formData);
    }

    GetCurrentTime(gameId: string): Observable<import("../models/Time").Time> {
        let payload = this.createHttpParams('gameId', gameId);
        return this.httpClient.post<import("../models/Time").Time>("https://localhost:44393/api/GetTime", payload);
      }

    public GetEvents(Id: string, player: Player): Observable<EventModel[]> {
        let headers = new HttpHeaders({
            'Access-Control-Allow-Origin': `*`,
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        });
        let options = {
            headers: headers
        };
        let formData = {
            id: Id,
            player: player
        }
        return this.httpClient.post<EventModel[]>("https://localhost:44393/api/GetEvents", formData);
    }

    SelectEvent(gameId: string, id: number): Observable<EventResponse> {
        let headers = new HttpHeaders({
            'Access-Control-Allow-Origin': `*`,
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        });
        let options = {
            headers: headers
        };
        let formData = {
            gameId: gameId,
            selectedEvent: id
        }
        return this.httpClient.post<EventResponse>("https://localhost:44393/api/SelectEvent", formData);
    }

    public GetPlayer(gameId: string): Observable<Player> {
        let payload = this.createHttpParams('gameId', gameId);
        return this.httpClient.post<Player>("https://localhost:44393/api/GetPlayer", payload);
    }

    public Do(Id: string): Observable<string> {
        let params = new HttpParams().set("id", Id);
        return this.httpClient.post<string>("https://localhost:44393/api/Do", params);
    }

    public SignUp(user: User): Observable<User> {
        let headers = new HttpHeaders({
            'Access-Control-Allow-Origin': `*`,
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        });
        let options = {
            headers: headers
        };
        return this.httpClient.post<User>("https://localhost:44393/api/SignUp", user, options);
    }

    protected createHttpParams(key: string, value: string) {
        return new HttpParams().set(key, value);
    }
}