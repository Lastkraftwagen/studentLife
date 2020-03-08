import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

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
  constructor(http: HttpClient) {
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

enum DayOfWeek {
  Monday = 1,
  Tuseday = 2,
  Wednesday = 3,
  Thursday = 4,
  Friday = 5,
  Saturday = 6,
  Sunday = 7
}

enum PartOfDay {
  Morning = 1,
  Day = 2,
  Evening = 3,
  Night = 4
}
enum GenderType {
  Man = 1, Woman = 2
}

enum PlaceType {
  Home = 1,
  Universitat = 2,
  Street = 3,
  Bar = 4,
  Restaurant = 5
}


class PlayerModel {

  public Name: string;
  public Gender: GenderType;


  public Theory: number;
  public Practic: number;
  public TeacherRaiting: number;
  public Money: number;
  public Happines: number;
  public Power: number;
  public hasFollower: boolean;
  public FriendsRaiting: number;
  public FollowerRaiting: number;
  public IsDrunk: number;

  public Place: PlaceType;
  public  LabMarks:number;
  public CountLabs: number;

  constructor() {

  }
}