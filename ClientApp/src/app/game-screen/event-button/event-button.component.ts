import { Component, OnInit, Input, Output, EventEmitter, ElementRef, AfterViewInit } from '@angular/core';
import { EventModel } from 'src/app/models/EventModel';

@Component({
  selector: 'app-event-button',
  templateUrl: './event-button.component.html',
  styleUrls: ['./event-button.component.scss']
})
export class EventButtonComponent implements OnInit, AfterViewInit {

  constructor(elRef:ElementRef) { }

  @Input() model: EventModel;
  @Input() multi: boolean;

  @Output() enter = new EventEmitter<string>();
  @Output() leave = new EventEmitter();
  @Output() select = new EventEmitter<number>();

  id: string; 

  opened = false;
  
  top = "-50px";
  left = "-50px";
  ngOnInit() {
    if(this.multi)
      this.id = this.getRandomInt(100000).toString();
  }

  ngAfterViewInit(): void {
    if(this.multi){
    this.left = (document.getElementById(this.id).offsetLeft + document.getElementById(this.id).clientWidth/2 + 10).toString()+"px";
    this.top = (document.getElementById(this.id).offsetTop).toString()+"px";
    }
  }

  getRandomInt(max: number) {
    return Math.floor(Math.random() * Math.floor(max));
  }

  toggle(){
    if(this.multi){
    this.left = (document.getElementById(this.id).offsetLeft + document.getElementById(this.id).clientWidth/2).toString()+"px";
    this.top = (document.getElementById(this.id).offsetTop).toString()+"px";
    }
    this.opened = !this.opened;
  }

 selectEvent() {
   this.select.next(this.model.id);
  }

  mouseEnter() {
    this.enter.next(this.model.description);
  }

  mouseLeave() {
    this.leave.next();
  }

  selectEventFirst() {
    this.select.next(this.model.submodels[0].id);
   }
 
   mouseEnterFirst() {
     this.enter.next(this.model.submodels[0].description);
   }

   selectEventSecond() {
    this.select.next(this.model.submodels[1].id);
   }
 
   mouseEnterSecond() {
     this.enter.next(this.model.submodels[1].description);
   }

   selectEventThird() {
    this.select.next(this.model.submodels[2].id);
   }
 
   mouseEnterThird() {
     this.enter.next(this.model.submodels[2].description);
   }
}
