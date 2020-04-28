import { Component, OnInit } from '@angular/core';
import{Resource} from '../../resource'
import{UserService} from '../../services/user.service'
import { GameService } from 'src/app/services/game.service';
import { Player } from 'src/app/models/Player';
import { GenderType } from 'src/app/enums';

class Bonus{
  constructor(url:string, name: string)
  {
    this.url = url;
    this.name = name;
  }
  url: string;
  name: string;
}

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss']
})
export class GameComponent implements OnInit {

  constructor(private userService: UserService, private gameService: GameService) { }

  bonuses: Bonus[] = [];

  ngOnInit() {
    this.bonuses.push(new Bonus( Resource.IMG_MONEY_PATH, "Beer"));
    this.bonuses.push(new Bonus( Resource.IMG_HAPPINES_PATH, "Beer"));
    this.bonuses.push(new Bonus( Resource.IMG_HAPPINES_PATH, "Beer"));
    this.bonuses.push(new Bonus( Resource.IMG_HAPPINES_PATH, "Beer"));
    this.bonuses.push(new Bonus( Resource.IMG_HAPPINES_PATH, "Beer"));
    this.gameStep();
    
  }
  gameStep() {
    this.gameService.getEvents(this.gameService.player).subscribe(result=>{
      console.log(result);
    })
  }

  startGame(){
    console.log(this.gameService.player);
  }

  // julia(){
  //   console.log('julia');
  //   this.userService.CreateGame("julia").subscribe(result=>{
  //     console.log(result);
  //   });
  // }

  // drink(){
  //   console.log('drink');
  //   this.userService.Do().subscribe(result=>{
  //   });
  // }
}
