import { Injectable } from "@angular/core"
import { HttpService } from '../services/httpservise'
import { Observable, from } from "rxjs"
import { map } from 'rxjs/operators'
import { User } from '../models/User'
import { Player } from "../models/Player"


@Injectable()
export class GameService {

    player: Player;
    



}