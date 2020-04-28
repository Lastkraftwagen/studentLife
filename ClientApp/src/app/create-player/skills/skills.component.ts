import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { GenderType } from 'src/app/enums';

@Component({
  selector: 'app-skills',
  templateUrl: './skills.component.html',
  styleUrls: ['./skills.component.css']
})
export class SkillsComponent implements OnInit {

  constructor() { }

  @Output() messageEvent = new EventEmitter<number>();

  @Output() plusEvent = new EventEmitter<string>();
  @Output() minusEvent = new EventEmitter<string>();


  @Input() sex: GenderType;
  @Input() Power: number;
  @Input() Agility: number;
  @Input() Intelligence: number;
  @Input() Speek: number;
  @Input() Attention: number;
  @Input() Glamor: number;

  points: number = 7;

  ngOnInit() {
  }

  getPower() {
    if (this.sex == GenderType.Man) return this.Power + 1;
    else return this.Power;
  }

  getGlamor() {
    if (this.sex == GenderType.Woman) return this.Glamor + 1;
    else return this.Glamor;
  }


  plus(value) {
    if (this.points == 0) return;
    this.plusEvent.next(value);
    this.points--;
    this.messageEvent.emit(this.points);
  }

  minus(value) {
    this.minusEvent.next(value);
    this.points++;
    this.messageEvent.emit(this.points);
  }


}
