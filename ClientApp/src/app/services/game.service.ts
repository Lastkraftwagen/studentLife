import { Injectable } from "@angular/core"
import { HttpService } from '../services/httpservise'
import { Observable, from } from "rxjs"
import { map } from 'rxjs/operators'
import { User } from '../models/User'
import { Player } from "../models/Player"
import { EventModel } from "../models/EventModel"
import { UserService } from "./user.service"


@Injectable()
export class GameService {

    constructor(private httpService: HttpService, private userService: UserService) { }

    public getEvents(player: Player):Observable<EventModel[]> {
        return this.httpService.GetEvents(this.userService.gameId, player);
    }

    player: Player;
    



}