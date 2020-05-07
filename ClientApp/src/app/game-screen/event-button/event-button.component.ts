import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { EventModel } from 'src/app/models/EventModel';

@Component({
  selector: 'app-event-button',
  templateUrl: './event-button.component.html',
  styleUrls: ['./event-button.component.scss']
})
export class EventButtonComponent implements OnInit {

  constructor() { }

  @Input() model: EventModel;

  @Output() enter = new EventEmitter<string>();
  @Output() leave = new EventEmitter();
  @Output() select = new EventEmitter<number>();

  ngOnInit() {
  }

  selectEvent(){
    this.select.next(this.model.id);
  }

  mouseEnter(){
    this.enter.next(this.model.description);
  }

  mouseLeave(){
    this.leave.next();
  }

}
