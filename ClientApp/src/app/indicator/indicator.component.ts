import { Component, OnInit, Input } from '@angular/core';
import {Resource} from 'src/app/resource';
@Component({
  selector: 'app-indicator',
  templateUrl: './indicator.component.html',
  styleUrls: ['./indicator.component.css']
})
export class IndicatorComponent implements OnInit {

  @Input() type;
  imagePath : string;
  value: number;
  Resource = Resource;
  constructor() { 
   
  }

  ngOnInit() {
    switch(this.type){
      case 'Energy': 
      {this.imagePath = Resource.IMG_ENERGY_PATH; break;}
      case 'Happiness': 
      {this.imagePath = Resource.IMG_HAPPINES_PATH; break;}
      case 'Money': 
      {this.imagePath = Resource.IMG_MONEY_PATH; break;}
      
    }
  }

}
