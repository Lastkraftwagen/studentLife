import { Component, OnInit } from '@angular/core';
import { Resource } from '../../resource'
import { UserService } from '../../services/user.service'
import { GameService } from 'src/app/services/game.service';
import { Player } from 'src/app/models/Player';
import { GenderType, PlaceType, CompanyType } from 'src/app/enums';
import { EventButtonComponent } from '../event-button/event-button.component';
import { EventModel } from 'src/app/models/EventModel';
import { PartOfDay, DayOfWeek } from 'src/app/enums';


class Bonus {
  constructor(url: string, name: string) {
    this.url = url;
    this.name = name;
  }
  url: string;
  name: string;
}


@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss']
})
export class GameComponent implements OnInit {

  constructor(private userService: UserService, private gameService: GameService) { }

  bonuses: Bonus[] = [];
  descriptionText: string = "";

  eventResult: string = "";
  name: string;
  happinessUrl: string = Resource.IMG_STUDENT;
  moneyUrl: string = Resource.IMG_MONEY_PATH;
  labUrl: string = Resource.IMG_LAB;

  day: DayOfWeek = DayOfWeek.Saturday;
  part: PartOfDay = PartOfDay.Morning;

  get dayUkr() {
    switch (this.day) {
      case DayOfWeek.Monday:
        return "Понеділок";
      case DayOfWeek.Tuseday:
        return "Вівторок";
      case DayOfWeek.Wednesday:
        return "Середа";
      case DayOfWeek.Thursday:
        return "Четвер";
      case DayOfWeek.Friday:
        return "П'ятниця";
      case DayOfWeek.Saturday:
        return "Субота";
      case DayOfWeek.Sunday:
        return "Неділя";

      default:
        break;
    }
  }

  get partUkr() {
    switch (this.part) {
      case PartOfDay.Morning:
        return "Ранок";
      case PartOfDay.Day:
        return "День";
      case PartOfDay.Evening:
        return "Вечір";
      case PartOfDay.Para:
        return "Пара";
      case PartOfDay.Night:
        return "Ніч";
      default:
        break;
    }
  }
  eventModels: EventModel[] = [];

  player: Player = new Player();
  ngOnInit() {
    this.bonuses.push(new Bonus(Resource.IMG_BIG_MONEY_PATH, "Money"));

    this.loadEvents();

    this.gameService.getPlayer().subscribe(result => {
      this.eventResult = " Зараз ранок суботи, ".concat(result.Name).concat(" знаходиться вдома і не знає, що робити. Можна обрати будь-який варіант, з описаних нижче.");
      this.name = result.Name;
    })
    this.updatePlayer();

  }
  loadEvents() {
    this.gameService.getEvents(this.gameService.player).subscribe(result => {
      this.eventModels = [];
      result.forEach(element => {
        this.eventModels.push(element);
      });
      this.eventModels.sort(() => Math.random() - 0.5);
      console.log(this.eventModels);
      console.log(this.gameService.player.Place);
    })
  }

  mouseLeave() {
    this.descriptionText = "";
  }

  mouseEnter(text: string) {
    this.descriptionText = text;
  }


  selectEvent(id: number) {
    this.gameService.selectEvent(id).subscribe(result => {

      if (result.status == Resource.FAIL) {
        throw "Not Implemented";
      }
      else if (result.status == Resource.DEAD) {
        this.writeResult(result.result);
        this.updatePlayer();
        this.eventModels = [];
        alert(result.message);
      }
      else if (result.status == Resource.CONTINUED) {
        this.writeResult(result.result);
        this.loadEvents();
        this.updatePlayer();
      }
      else if (result.status == Resource.SUCCESS) {
        this.writeResult(result.result);
        this.loadEvents();
        this.updatePlayer();
        this.updateTime();
      }
    });
  }
  updateTime() {
    this.gameService.getTime().subscribe(result => {
      this.day = result.dayOfWeek;
      this.part = result.partOfDay;
    });
  }
  updatePlayer() {
    this.gameService.getPlayer().subscribe(result => {
      var p: Player = result;
      this.player = p;
      this.bonuses = [];
      this.bonuses.push(new Bonus(Resource.IMG_BIG_MONEY_PATH, "Money"));
      if (p.isDrunk)
        this.bonuses.push(new Bonus(Resource.IMG_ALCOHOL, "Beer"));

      switch (result.Place) {
        case PlaceType.Home:
          this.bonuses.push(new Bonus(Resource.IMG_HOME, "Home"));
          break;
        case PlaceType.Outside:
          this.bonuses.push(new Bonus(Resource.IMG_OUTSIDE, "Outside"));
          break;
        case PlaceType.Place:
          this.bonuses.push(new Bonus(Resource.IMG_PLACE, "Place"));
          break;
        case PlaceType.Universitat:
          this.bonuses.push(new Bonus(Resource.IMG_UNIVER, "Univer"));
          break;
        default:
          break;
      }

      switch (p.Company) {
        case CompanyType.Alone:
          this.bonuses.push(new Bonus(Resource.IMG_ALONE, "Univer"));
          break;
        case CompanyType.WithFriends:
          this.bonuses.push(new Bonus(Resource.IMG_FRIENDS, "Friends"));
          break;
        case CompanyType.WithGF:
          this.bonuses.push(new Bonus(Resource.IMG_LOVE, "Follower"));
          break;
        default:
          break;
      }



    })
  }

  writeResult(result: string[]) {
    result.forEach(element => {
      var p = document.createElement("p");
      p.innerText = element;
      document.getElementById("textscreen").appendChild(p);
      document.getElementById("textscreen").scrollTop = document.getElementById("textscreen").scrollHeight;
    })

  }
}
