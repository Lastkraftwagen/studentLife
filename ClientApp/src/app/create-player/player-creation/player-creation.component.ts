import { Component, OnInit } from '@angular/core';
import { NumberValueAccessor } from '@angular/forms';


enum Sex{
  Male,
  Female
}

@Component({
  selector: 'app-player-creation',
  templateUrl: './player-creation.component.html',
  styleUrls: ['./player-creation.component.scss']
})
export class PlayerCreationComponent implements OnInit {

  constructor() { }

  name: string;
  randomSkill: number;
  arrowLeft: string;
  sex: Sex = Sex.Male;
  sexImg: string = "../../../assets/male_gender.png";
  placeholder: string = "Василь";

  points: number = 7;

  ngOnInit() {
    this.randomSkill = this.getRandomInt(3);
  }

  receiveMessage($event) {
    this.points = $event
  }

  getRandomInt(max: number) {
    return Math.floor(Math.random() * Math.floor(max));
  }
  toggleSex(){
    if(this.sex === Sex.Male) {
      this.sex = Sex.Female;
      this.placeholder = "Ольга";
      this.sexImg = "../../../assets/female_gender.png"
    }
    else{ 
      this.sex = Sex.Male;
      this.placeholder = "Василь";
      this.sexImg = "../../../assets/male_gender.png"

    }
  }
}
