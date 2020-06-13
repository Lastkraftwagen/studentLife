import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { GameService } from 'src/app/services/game.service';
import { Player } from 'src/app/models/Player';
@Component({
  selector: 'app-skills-dialog',
  templateUrl: './skills-dialog.component.html',
  styleUrls: ['./skills-dialog.component.css']
})
export class SkillsDialogComponent implements OnInit {

  constructor(  public dialRef: MatDialogRef<SkillsDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: string,
    private gameService: GameService) { 

      this.p = gameService.player;
    } 
    p: Player = null;
    ngOnInit(): void {
      
    }
   
    onNoClick(): void {
      this.dialRef.close();
    }
}
