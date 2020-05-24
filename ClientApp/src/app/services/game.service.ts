import { Injectable } from "@angular/core"
import { HttpService } from '../services/httpservise'
import { Observable, from } from "rxjs"
import { map } from 'rxjs/operators'
import { User } from '../models/User'
import { Player } from "../models/Player"
import { EventModel } from "../models/EventModel"
import { UserService } from "./user.service"
import { EventResponse } from "../models/EventResponse"
import { Time } from "../models/Time"


@Injectable()
export class GameService {
    
   

    constructor(private httpService: HttpService, private userService: UserService) { }

    public getEvents(player: Player):Observable<EventModel[]> {
        return this.httpService.GetEvents(this.userService.gameId, player);
    }

    public selectEvent(id: number):Observable<EventResponse> {
      return this.httpService.SelectEvent(this.userService.gameId, id);
    }

    getTime():Observable<Time> {
      return this.httpService.GetCurrentTime(this.userService.gameId);
    }
    player: Player = null;

    workDone():Observable<Player> {
      return this.httpService.WorkDone(this.userService.gameId).pipe(
        map(result=>{
          if(result!=null){
            this.player = result;
          }
          return this.player;
        })
      );
    }


    getPlayer():Observable<Player>{
      return this.httpService.GetPlayer(this.userService.gameId).pipe(
        map(result=>{
          if(result!=null){
            this.player = result;
          }
          return this.player;
        })
      );
    }
    



}