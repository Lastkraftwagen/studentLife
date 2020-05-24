import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import {HttpService} from 'src/app/services/httpservise'
import { DayOfWeek, PartOfDay } from '../enums';
@Component({
  selector: 'app-control-panel',
  templateUrl: './control-panel.component.html',
  styleUrls: ['./control-panel.component.css']
})
export class ControlPanelComponent implements OnInit {

  public http: HttpClient;
  public time: Time;
  public step: string;
  public baseUrl: string = "https://localhost:44393/";
  constructor(http: HttpClient,private httpService: HttpService ) {
    this.http = http;
  }

  ngOnInit() {
    this.time = new Time();
    this.time.dayOfWeek = 1;
    this.time.partOfDay = 1;
    this.NextDay();
  }

  NextDay(): void {
    this.http.get<string>(this.baseUrl + 'api/values').subscribe(result => {
      this.step = result;
    }, error => console.error(error));
  }

}

class Time {
  dayOfWeek: DayOfWeek;
  partOfDay: PartOfDay;
}

