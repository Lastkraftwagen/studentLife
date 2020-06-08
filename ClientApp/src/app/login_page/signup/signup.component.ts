import { Component, OnInit } from '@angular/core';
import { HttpService } from 'src/app/services/httpservise';
import { User } from 'src/app/models/User';
import { Md5 } from 'ts-md5';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  email: string;
  password: string;
  nick: string;
  spassword: string;
  loginProcess: boolean = false;
  constructor(private httpService: HttpService, private _router: Router) { }

  ngOnInit() {
  }

  signUp(){
    if(this.spassword!=this.password)
    {alert('Паролі не співпадають!'); return;}
    
    this.loginProcess = true;
    
    const user: User = new User();
    user.email = this.email;
    user.name = this.nick;
    user.password = Md5.hashAsciiStr(this.password).toString();

    this.httpService.SignUp(user).subscribe(
      result=>{
        if(result!=null){
          this.loginProcess = false;
          alert('Успішно зареєстровано.');
          this._router.navigate['/login'];
        }
          else{
            {alert('Неможливо зареєструватися зараз, спробуйте пізніше!'); return;}
          }

      }
    )

  }
}
