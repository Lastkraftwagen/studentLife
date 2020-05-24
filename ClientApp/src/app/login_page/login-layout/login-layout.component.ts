import { Component, OnInit } from '@angular/core';
import {HttpService} from 'src/app/services/httpservise'

@Component({
  selector: 'app-login-layout',
  templateUrl: './login-layout.component.html',
  styleUrls: ['./login-layout.component.scss']
})
export class LoginLayoutComponent implements OnInit {

  login: boolean = true;
  leftButtonText: string = "Увійти";
  rightButtonText: string = "Зареєструватися";
  helpLabel: string = "Ще не маєте аккаунта?";

  constructor(private httpService: HttpService) { }

  ngOnInit() {
  }

  changeVis(){
    this.login = !this.login;
    if(this.login)
    {
      this.leftButtonText = "Увійти";
      this.rightButtonText = "Зареєструватися";
      this.helpLabel = "Ще не маєте аккаунта?";
    }
    else{
      this.leftButtonText = "Створити акаунт";
      this.rightButtonText = "Назад до входу";
      this.helpLabel = "Вже зареєстровані?";
    }
  }

  logIn(){
    
  }

}
