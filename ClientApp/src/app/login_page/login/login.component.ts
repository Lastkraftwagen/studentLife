import { Component, OnInit } from '@angular/core';
import { Md5 } from 'ts-md5/dist/md5'
import { UserService } from 'src/app/services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  email: string;
  password: string;
  loginProcess: boolean = false;
  loginFailed: boolean = false;
  constructor(private userService: UserService, private _router: Router) {

  }


  ngOnInit() {
  }

  logIn() {
    this.loginProcess = true;
    this.loginFailed =false;
    this.userService.LogIn(this.email, Md5.hashAsciiStr(this.password).toString()).subscribe(
      result => {
        this.loginProcess = false;
        if (result) {
          this._router.navigate(['/']);
        }
        else{
          this.loginFailed = true;
        }
      }
    )
  }

}
