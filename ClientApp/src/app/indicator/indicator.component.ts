import { Component, OnInit, Input } from '@angular/core';
import {Resource} from 'src/app/resource';
@Component({
  selector: 'app-indicator',
  templateUrl: './indicator.component.html',
  styleUrls: ['./indicator.component.css']
})
export class IndicatorComponent implements OnInit {

  @Input() type;
  @Input() value : number;
  imagePath : string = "no";
  Resource = Resource;
  constructor() { 
   
  }

  ngOnInit() {
    switch(this.type){
      case 'Енергія': 
      {this.imagePath = Resource.IMG_ENERGY_PATH; break;}
      case 'Щастя': 
      {this.imagePath = Resource.IMG_HAPPINES_PATH; break;}
      case 'Ставлення друзів': 
      {this.imagePath = Resource.IMG_FRIENDS; break;}
      case 'Ставлення другої половинки': 
      {this.imagePath = Resource.IMG_LOVE; break;}
      case 'Ставлення вчителя': 
      {this.imagePath = Resource.IMG_TEACHER; break;}
      case 'Теоретичні знання': 
      {this.imagePath = Resource.IMG_THEORIE; break;}
      case 'Практичні навички': 
      {this.imagePath = Resource.IMG_PRAXIS; break;}

    }
  }

}
