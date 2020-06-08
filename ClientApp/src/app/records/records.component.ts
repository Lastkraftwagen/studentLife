import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { Record } from '../models/Record';

@Component({
  selector: 'app-records',
  templateUrl: './records.component.html',
  styleUrls: ['./records.component.scss']
})
export class RecordsComponent implements OnInit {

  constructor(private router: Router, private userService: UserService) { }

  Records: Record[] = [];

  loginProcess: boolean = false;
  ngOnInit() {
    this.loginProcess = true;
    this.userService.GetRecords().subscribe(result=>{
      this.Records = result;
      this.loginProcess = false;
    });
  }

  back(){
    this.router.navigate(['/']);
  }

}
