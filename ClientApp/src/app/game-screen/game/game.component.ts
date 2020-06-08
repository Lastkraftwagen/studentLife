import { Component, OnInit, Output, EventEmitter, Inject } from '@angular/core';
import { Resource } from '../../resource'
import { UserService } from '../../services/user.service'
import { GameService } from 'src/app/services/game.service';
import { Player } from 'src/app/models/Player';
import { GenderType, PlaceType, CompanyType, RandomSkill } from 'src/app/enums';
import { EventButtonComponent } from '../event-button/event-button.component';
import { EventModel } from 'src/app/models/EventModel';
import { PartOfDay, DayOfWeek } from 'src/app/enums';
import { Router } from '@angular/router';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';


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

  constructor(public dialog: MatDialog, private userService: UserService, private gameService: GameService, private router: Router) { }

  bonuses: Bonus[] = [];
  descriptionText: string = "";

  eventResult: string = "";
  name: string;
  animationTime: boolean = true;
  visibility: boolean = true;
  profilePic: string = Resource.IMG_STUDENT;
  moneyUrl: string = Resource.IMG_MONEY_PATH;
  labUrl: string = Resource.IMG_NOT_READY_LAB;
  labReadyUrl: string = Resource.IMG_LAB;
  labPassedUrl: string = Resource.IMG_READY_LAB;
  progressValue = 100;
  progressStep = 1;

  ActionFieldWork: boolean = false;

  Action: boolean = false;
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
        return "Пари в універі";
      case PartOfDay.Night:
        return "Ніч";
      default:
        break;
    }
  }
  eventModels: EventModel[] = [];

  player: Player = new Player();
  ngOnInit() {
    this.loadEvents();
    this.gameService.getPlayer().subscribe(result => {

      this.name = result.Name;
      this.profilePic = result.Gender == GenderType.Man ? Resource.IMG_STUDENT : Resource.IMG_STUDENTKA;

      this.updateTime();
      this.gameService.getTime().subscribe(res => {
        this.day = res.dayOfWeek;
        this.part = res.partOfDay;
        if (this.day == DayOfWeek.Saturday && this.part == PartOfDay.Morning)
          this.eventResult = "Зараз ранок суботи, ".concat(result.Name).concat(" знаходиться вдома і не знає, що робити. Можна обрати будь-який варіант, з описаних нижче.");
        else
          this.eventResult = "Чим зайнятися зараз?"
      })
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

      this.updatePlayer();
    }
    )
  }

  mouseLeave() {
    this.descriptionText = "";
  }

  saveName: string = "default";
  saveGame() {
    const dialogRef = this.dialog.open(DialogOverviewExampleDialog, {
      width: '250px',
      data: this.saveName
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.saveName = result;
      this.gameService.saveGame(this.saveName).subscribe(result => {
        if (result)
          alert("Success");
      })
    });

  }
  mouseEnter(text: string) {
    this.descriptionText = text;
  }

  back() {
    this.router.navigate(['/']);
  }
  selectEvent(id: number) {
    this.gameService.selectEvent(id).subscribe(result => {
      this.animationTime = false;
      this.visibility = false;
      if (result.status == Resource.FAIL) {
        throw "Not Implemented";
      }
      else if (result.status == Resource.WIN) {
        setTimeout(() => this.timerwithoutProgress(result.result, 1000), 1000)
        alert("Гру завершено!");
        this.router.navigate(['/']);
      }
      else if (result.status == Resource.DEAD) {
        // this.writeResult(result.result);
        this.updatePlayer();
        this.eventModels = [];
        alert(result.message);
        this.router.navigate(['/']);

      }
      else if (result.status == Resource.CONTINUED) {
        this.writeResult(result.result);
      }
      else if (result.status == Resource.SUCCESS) {
        if (result.isAction) {
          this.Action = true;
          switch (result.actionId) {
            case 40:
              this.ActionFieldWork = true;
              var p = document.createElement("p");
              p.innerText = "<>"
              document.getElementById("textscreen").appendChild(p);
              this.writeParagraph("Завдання: натискай на кнопку як тільки вона відтиснута. Чим довше вона залишається відтиснутою, тим менше якість виконаної роботи. Мінімальна якість для прийняття роботи - 80%.");
              setTimeout(() => this.timerwithoutProgress(result.result, 0), 30000)
              break;

            default:
              break;
          }
        }
        else {
          this.writeResult(result.result);
          //this.loadEvents();
          // this.updatePlayer();
          this.updateTime();
        }
      }
    });
  }
  updateTime() {
    this.gameService.getTime().subscribe(result => {
      this.day = result.dayOfWeek;
      this.part = result.partOfDay;
    });
  }

  stopAction(message: string) {
    this.Action = false;
    this.ActionFieldWork = false;
    this.writeParagraph(message);
    if (message == "Робочі години зараховано.") {
      this.gameService.workDone().subscribe(result => {
        this.updatePlayer();
        this.updateTime();
        this.loadEvents();
      })
    }
    else {
      this.updateTime();
      this.loadEvents();
    }
  }

  updatePlayer() {
    this.gameService.getPlayer().subscribe(result => {
      var p: Player = result;
      this.player = p;
      this.bonuses = [];
      switch (p.RandomSkill) {
        case RandomSkill.Happy:
          this.bonuses.push(new Bonus(Resource.IMG_HAPPINES_PATH, result.Name.concat(" - має кращий настрій на момент початку гри.")));
          break;
        case RandomSkill.Reach:
          this.bonuses.push(new Bonus(Resource.IMG_BIG_MONEY_PATH, result.Name.concat(" - має більший запас грошей на момент початку гри.")));
          break;
        case RandomSkill.Strong:
          this.bonuses.push(new Bonus(Resource.IMG_ENERGY_PATH, result.Name.concat(" - має більше сил на момент початку гри.")));
          break;
        default:
          break;
      }
      if (p.isDrunk)
        this.bonuses.push(new Bonus(Resource.IMG_ALCOHOL, "В стані алкогольного сп'яніння"));

      switch (result.Place) {
        case PlaceType.Home:
          this.bonuses.push(new Bonus(Resource.IMG_HOME, "Вдома"));
          break;
        case PlaceType.Outside:
          this.bonuses.push(new Bonus(Resource.IMG_OUTSIDE, "На вулиці"));
          break;
        case PlaceType.Place:
          if (p.Company == CompanyType.Alone)
            this.bonuses.push(new Bonus(Resource.IMG_UNIVER, "На роботі"));
          else
            this.bonuses.push(new Bonus(Resource.IMG_PLACE, "В громадському місці"));
          break;
        case PlaceType.Universitat:
          this.bonuses.push(new Bonus(Resource.IMG_UNIVER, "В універі"));
          break;
        default:
          break;
      }

      switch (p.Company) {
        case CompanyType.Alone:
          this.bonuses.push(new Bonus(Resource.IMG_ALONE, "Наодинці"));
          break;
        case CompanyType.WithFriends:
          this.bonuses.push(new Bonus(Resource.IMG_FRIENDS, "З друзями"));
          break;
        case CompanyType.WithGF:
          this.bonuses.push(new Bonus(Resource.IMG_LOVE, "З другою половинкою"));
          break;
        default:
          break;
      }
      this.animationTime = true;
      this.visibility = true;
    })
  }

  writeResult(result: string[]) {
    this.progressValue = 0;
    this.progressStep = 100 / result.length;
    var p = document.createElement("p");
    p.innerText = "•"
    document.getElementById("textscreen").appendChild(p);
    setTimeout(() => this.timer(result, 0), 1000)
  }

  writeParagraph(text: string) {
    var p = document.createElement("p");
    p.innerText = text;
    document.getElementById("textscreen").appendChild(p)
    document.getElementById("textscreen").scrollTop = document.getElementById("textscreen").scrollHeight;
  }

  timer(eventsArray: string[], index) {
    if (eventsArray.length > index) {
      this.writeParagraph(eventsArray[index]);
      index += 1;
      this.progressValue += this.progressStep;
      setTimeout(() => {
        this.timer(eventsArray, index);
      }, 1200);
    } else {
      this.progressValue = 100;
      this.loadEvents();
    }
  }

  timerwithoutProgress(eventsArray: string[], index) {
    if (eventsArray.length > index) {
      this.writeParagraph(eventsArray[index]);
      index += 1;
      setTimeout(() => {
        this.timerwithoutProgress(eventsArray, index);
      }, 2000);
    } else {
    }
  }

}


@Component({
  selector: 'dialog-overview-example-dialog',
  templateUrl: 'dialog-overview-example-dialog.html',
  styleUrls: ['dialog-overview-example-dialog.scss']

})
export class DialogOverviewExampleDialog {

  constructor(
    public dialogRef: MatDialogRef<DialogOverviewExampleDialog>,
    @Inject(MAT_DIALOG_DATA) public data: string) { }

  onNoClick(): void {
    this.dialogRef.close();
  }
}

