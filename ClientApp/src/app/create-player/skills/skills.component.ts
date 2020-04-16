import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

enum Sex {
  Male,
  Female
}

enum Skills {
  Power,
  Agility,
  Intelligence,
  Speek,
  Attention,
  Glamor,
}

@Component({
  selector: 'app-skills',
  templateUrl: './skills.component.html',
  styleUrls: ['./skills.component.css']
})
export class SkillsComponent implements OnInit {

  constructor() { }

  @Output() messageEvent = new EventEmitter<number>();
  @Input() sex: Sex;
  Power: number;
  Agility: number;
  Intelligence: number;
  Speek: number;
  Attention: number;
  Glamor: number;

  skill: Skills;
  points: number = 7;

  ngOnInit() {
    this.Power = 1;
    this.Agility = 1;
    this.Intelligence = 1;
    this.Speek = 1;
    this.Attention = 1;
    this.Glamor = 1;
  }

  getPower() {
    if (this.sex == Sex.Male) return this.Power + 1;
    else return this.Power;
  }

  getGlamor() {
    if (this.sex == Sex.Female) return this.Glamor + 1;
    else return this.Glamor;
  }


  plus(value) {
    if (this.points == 0) return;
    switch (value) {
      case "power":
        if (this.Power < 10) {
          this.Power++;
          this.points--;
        }
        break;
      case "agile":
        if (this.Agility < 10) {
          this.Agility++;
          this.points--;
        }
        break;
      case "intel":
        if (this.Intelligence < 10) {
          this.Intelligence++;
          this.points--;
        }
        break;
      case "speek":
        if (this.Speek < 10) {
          this.Speek++;
          this.points--;
        }
        break;
      case "attention":
        if (this.Attention < 10) {
          this.Attention++;
          this.points--;
        }
        break;
      case "glamor":
        if (this.Glamor < 10) {
          this.Glamor++;
          this.points--;
        }
        break;

      default:
        break;
    }
    this.messageEvent.emit(this.points);
  }

  minus(value) {
    switch (value) {
      case "power":
        if (this.Power > 0) {
          this.Power--;
          this.points++;
        }
        break;
      case "agile":
        if (this.Agility > 0) {
          this.Agility--;
          this.points++;
        }
        break;
      case "intel":
        if (this.Intelligence > 0) {
          this.Intelligence--;
          this.points++;
        }
        break;
      case "speek":
        if (this.Speek > 0) {
          this.Speek--;
          this.points++;
        }
        break;
      case "attention":
        if (this.Attention > 0) {
          this.Attention--;
          this.points++;
        }
        break;
      case "glamor":
        if (this.Glamor > 0) {
          this.Glamor--;
          this.points++;
        }
        break;

      default:
        break;
    }
    this.messageEvent.emit(this.points);
  }


}
