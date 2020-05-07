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
import { GameService } from './services/game.service';
import { PlayerCreationComponent } from './create-player/player-creation/player-creation.component';
import { SkillsComponent } from './create-player/skills/skills.component';
import { GameComponent } from './game-screen/game/game.component';
import { MenuComponent } from './menu/menu.component';
import { PlayerCreatedGuard } from './guards/playerCreated.guard';
import { EventButtonComponent } from './game-screen/event-button/event-button.component';
import { ActionResultComponent } from './action-result/action-result.component';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


const appRoures: Routes = [
  {
    path: '', component: MenuComponent,
    // path: '', component: GameComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'creation',
    component: PlayerCreationComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'game',
    component: GameComponent,
    canActivate: [PlayerCreatedGuard]
  },
  {
    path: 'records',
    component: CounterComponent,
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
  { path: "**", redirectTo: '' }


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
    SkillsComponent,
    GameComponent,
    MenuComponent,
    EventButtonComponent,
    ActionResultComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(
      appRoures
    ),
    BrowserAnimationsModule,
    MatProgressBarModule
  ],
  providers: [
    AuthGuard,
    PlayerCreatedGuard,
    HttpService,
    UserService,
    GameService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
