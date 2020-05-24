import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { GameService } from '../services/game.service';

@Component({
  selector: 'app-work-game',
  templateUrl: './work-game.component.html',
  styleUrls: ['./work-game.component.scss']
})
export class WorkGameComponent implements OnInit {

  constructor() {
  }
  @Output() stopEvent = new EventEmitter<string>();
  quality: number = 2500;
  isStarted: boolean = false;
  isClicked: boolean = false;
  s: number = 0;
  time: number = 50;

  ngOnInit() {
  }

  DoWork() {
    if (!this.isStarted) {
      this.isStarted = true;
      setTimeout(() => this.timer(50), 1000)
    }
    if (this.isClicked) {
      this.s+=100;
      this.quality= 2500-this.s;
      alert("НЕ НАТИСКАЙ НА ВЖЕ НАТИСНУТУ КНОПКУ, ТИ З ГЛУЗДУ З'ЇХАВ??");
      return;
    }
    this.quality= 2500-this.s;
    this.isClicked = true;
    setTimeout(
      () => {
        this.isClicked = false;
        this.tickWork();
      },
      Math.floor(Math.random() * 10000)
    );
  }

  StopGame(): any {
    if(this.quality>2000){
      alert("Частину роботи виконано.");
      this.stopEvent.next("Робочі години зараховано.");
    }
      else{
        alert("Якість виконаної роботи - нижче 80%! НЕ ПРИЙМАЄТЬСЯ.");
        this.stopEvent.next("Робочі години не зараховано.");
      }
      this.quality = 2500;
      this.isStarted = false;
      this.isClicked = false;
      this.s = 0;
      this.time = 50;
  }

  updateTime(): any {
    this.time--;
  }

  timer(seconds) {
    if (seconds > 0) {
      this.updateTime();
      seconds -= 1;
      setTimeout(() => {
        this.timer(seconds);
      }, 1000);
    } else {
      this.StopGame();
    }
  }

  tickWork() {
    if(!this.isStarted) return;
    if (!this.isClicked) {
      this.s++;
      this.quality--;
      setTimeout(() => this.tickWork(), 10);
    }
  }


}
