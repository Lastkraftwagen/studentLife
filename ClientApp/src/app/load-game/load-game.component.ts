import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { SavedGame } from '../models/SavedGame';

@Component({
  selector: 'app-load-game',
  templateUrl: './load-game.component.html',
  styleUrls: ['./load-game.component.scss']
})
export class LoadGameComponent implements OnInit {

  constructor(private router: Router, private userService: UserService) { }

  SavedGames: SavedGame[] = [];

  ngOnInit() {
    this.loginProcess = true;
    this.userService.GetSavedGames().subscribe(result=>{
      this.SavedGames = result;
      this.selectedId = this.SavedGames[0].GameId;
      this.loginProcess = false;
    });
  }
  loginProcess: boolean = false;
  selectedId: number;

  back(){
    this.router.navigate(['/']);
  }

  load(){
    this.userService.LoadGame(this.selectedId).subscribe(result=>{
      if(result)
        this.router.navigate(['/game']);
    });
  }

  select(gameId:number){
    this.selectedId = gameId;
  }
}
