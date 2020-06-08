import { Injectable } from "@angular/core"
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http"
import { Observable, from } from "rxjs"
import { map } from 'rxjs/operators'
import { User } from "../models/User";
import { Player } from "../models/Player";
import { EventModel } from "../models/EventModel";
import { EventResponse } from "../models/EventResponse";
import { SavedGame } from "../models/SavedGame";
import { Record } from "../models/Record";

@Injectable()
export class HttpService {
    
    
    constructor(private httpClient: HttpClient) { }

    public LogIn(email: string, password: string): Observable<User> {
        let payload = this.createHttpParams('email', email).set('password', password);
        return this.httpClient.post<User>("https://localhost:44393/api/LogIn", payload);
    }
    GetRecords():  Observable<Record[]> {
        return this.httpClient.get<Record[]>("https://localhost:44393/api/GetRecords");
    }

    LoadGame(id: string, selectedId: number, gameId: string): Observable<boolean> {
        let payload = this.createHttpParams('userId', id).set('savedGameId', selectedId.toString()).set('gameId', gameId);
        return this.httpClient.post<boolean>("https://localhost:44393/api/LoadGame", payload);
    }

    GetSavedGames(userId: string): Observable<SavedGame[]> {
        let payload = this.createHttpParams('userId', userId);
        return this.httpClient.post<SavedGame[]>("https://localhost:44393/api/GetSavedGames", payload);
    }

    SaveGame(gameId: string, userId: string, saveName: string): Observable<boolean> {
        let payload = this.createHttpParams('gameId', gameId).set('userId', userId).set('saveName', saveName);
        return this.httpClient.post<boolean>("https://localhost:44393/api/SaveGame", payload);
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

    WorkDone(gameId: string): Observable<Player> {
        let payload = this.createHttpParams('gameId', gameId);
        return this.httpClient.post<Player>("https://localhost:44393/api/WorkDone", payload);
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