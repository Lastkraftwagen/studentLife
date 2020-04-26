import { Injectable } from "@angular/core"
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http"
import { Observable, from } from "rxjs"
import { map } from 'rxjs/operators'
import { User } from "../models/User";

@Injectable()
export class HttpService {
    
    constructor(private httpClient: HttpClient) { }

    public LogIn(email: string, password: string): Observable<User> {
        let payload = this.createHttpParams('email', email).set('password', password);
        return this.httpClient.post<User>("https://localhost:44393/api/LogIn", payload);
    }

    public CreateGame(Id: string, name: string): Observable<boolean> {
        
        let payload = this.createHttpParams('Id', Id).set('name', name);
        return this.httpClient.post<boolean>("https://localhost:44393/api/values", payload);
    }

    public Do(Id: string): Observable<string> {
        let params = new HttpParams().set("id",Id);
        return this.httpClient.post<string>("https://localhost:44393/api/Do",params);
    }

    public SignUp(user: User): Observable<any> {
        let headers = new HttpHeaders({
            'Access-Control-Allow-Origin':`*`,
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        });
        let options = {
            headers: headers
        };
        return this.httpClient.post<any>("https://localhost:44393/api/SignUp", user, options);
    }

    protected createHttpParams(key: string, value: string) {
        return new HttpParams().set(key, value);
    }
}