import { Component, OnInit } from '@angular/core';
import {HttpService} from 'src/app/services/httpservise'
import {Router} from '@angular/router'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  email: string;
  password: string;
  constructor(private httpService: HttpService, private router: Router) { }


  ngOnInit() {
  }

  logIn(){
    
      this.httpService.LogIn(this.email, this.password).subscribe(
        result=>{
          alert(result);
        }
      )
  
  }

}
