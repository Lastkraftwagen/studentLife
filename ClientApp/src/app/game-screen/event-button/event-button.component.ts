import { Component, OnInit, Input } from '@angular/core';
import { EventModel } from 'src/app/models/EventModel';

@Component({
  selector: 'app-event-button',
  templateUrl: './event-button.component.html',
  styleUrls: ['./event-button.component.scss']
})
export class EventButtonComponent implements OnInit {

  constructor() { }

  @Input() model: EventModel;

  ngOnInit() {
  }

}
