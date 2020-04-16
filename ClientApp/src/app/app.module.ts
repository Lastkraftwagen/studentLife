import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AComponent } from './a/a.component';
import { FooterComponent } from './footer/footer.component';
import { ControlPanelComponent } from './control-panel/control-panel.component';
import { LoginComponent } from './login_page/login/login.component';
import { SignupComponent } from './login_page/signup/signup.component';
import { LoginLayoutComponent } from './login_page/login-layout/login-layout.component';
import { IndicatorComponent } from './indicator/indicator.component';
import { HttpService } from './services/httpservise'
import { AuthGuard } from './guards/auth.guard'
import { UserService } from './services/user.service';
import { PlayerCreationComponent } from './create-player/player-creation/player-creation.component';
import { SkillsComponent } from './create-player/skills/skills.component';


const appRoures: Routes = [
  {
    path: '', component: PlayerCreationComponent,
    canActivate: [AuthGuard] 
  },
  {
    path: '', 
    component: LoginLayoutComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'signup', component: SignupComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch', component: FetchDataComponent }
    ]
  },
  {path: "**", redirectTo: ''}
  

]

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CounterComponent,
    FetchDataComponent,
    AComponent,
    FooterComponent,
    ControlPanelComponent,
    LoginComponent,
    SignupComponent,
    LoginLayoutComponent,
    IndicatorComponent,
    PlayerCreationComponent,
    SkillsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(
     appRoures
    )
  ],
  providers: [
    AuthGuard,
    HttpService,
    UserService 
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
