import { Component, OnInit } from '@angular/core';
import { NumberValueAccessor } from '@angular/forms';
import { Player } from 'src/app/models/Player';
import { GenderType } from 'src/app/enums';
import { GameService } from 'src/app/services/game.service';
import { UserService } from 'src/app/services/user.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-player-creation',
  templateUrl: './player-creation.component.html',
  styleUrls: ['./player-creation.component.scss']
})
export class PlayerCreationComponent implements OnInit {

  constructor(private userService: UserService, private gameService: GameService,  private router: Router) { }

  name: string;
  randomSkill: number;
  arrowLeft: string;
  sex: GenderType = GenderType.Man;
  sexImg: string = "../../../assets/male_gender.png";
  studentImg: string = "../../../assets/student.png";
  placeholder: string = "Василь";

  Power: number;
  Agility: number;
  Intelligence: number;
  Speek: number;
  Attention: number;
  Glamor: number;

  points: number = 7;

  ngOnInit() {
    this.Power = 1;
    this.Agility = 1;
    this.Intelligence = 1;
    this.Speek = 1;
    this.Attention = 1;
    this.Glamor = 1;
    this.randomSkill = this.getRandomInt(3);
  }

  receiveMessage($event) {
    this.points = $event
  }

  getRandomInt(max: number) {
    return Math.floor(Math.random() * Math.floor(max));
  }
  toggleSex() {
    if (this.sex === GenderType.Man) {
      this.sex = GenderType.Woman;
      this.placeholder = "Ольга";
      this.studentImg = "../../../assets/studentka.png";
      this.sexImg = "../../../assets/female_gender.png"
    }
    else {
      this.sex = GenderType.Man;
      this.placeholder = "Василь";
      this.sexImg = "../../../assets/male_gender.png"
      this.studentImg = "../../../assets/student.png";

    }
  }

  plus(value) {
    switch (value) {
      case "power":
        if (this.Power < 10) {
          this.Power++;
        }
        break;
      case "agile":
        if (this.Agility < 10) {
          this.Agility++;
        }
        break;
      case "intel":
        if (this.Intelligence < 10) {
          this.Intelligence++;
        }
        break;
      case "speek":
        if (this.Speek < 10) {
          this.Speek++;
        }
        break;
      case "attention":
        if (this.Attention < 10) {
          this.Attention++;
        }
        break;
      case "glamor":
        if (this.Glamor < 10) {
          this.Glamor++;
        }
        break;

      default:
        break;
    }
  }

  minus(value) {
    switch (value) {
      case "power":
        if (this.Power > 0) {
          this.Power--;
        }
        break;
      case "agile":
        if (this.Agility > 0) {
          this.Agility--;
        }
        break;
      case "intel":
        if (this.Intelligence > 0) {
          this.Intelligence--;
        }
        break;
      case "speek":
        if (this.Speek > 0) {
          this.Speek--;
        }
        break;
      case "attention":
        if (this.Attention > 0) {
          this.Attention--;
        }
        break;
      case "glamor":
        if (this.Glamor > 0) {
          this.Glamor--;
        }
        break;

      default:
        break;
    }
  }

  start() {
    let p: Player = new Player();
    p.Gender = this.sex;
    p._agility = this.Agility;
    p._attention = this.Attention;
    p._glamor = this.Glamor;
    p._intelligence = this.Intelligence;
    p._power = this.Power;
    p._speek = this.Speek;

    p.Name = this.name;

    this.userService.CreateGame(p).subscribe(result => {
      if (result) {
        this.gameService.player = result;
        this.router.navigate(['/game']);
      }
    });
  }

  back(){
    this.router.navigate(['']);
  }
}
