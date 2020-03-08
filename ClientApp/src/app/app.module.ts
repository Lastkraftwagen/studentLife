import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AComponent } from './a/a.component';
import { FooterComponent } from './footer/footer.component';
import { ControlPanelComponent } from './control-panel/control-panel.component';
import { LoginComponent } from './login_page/login/login.component';
import { PlayerCreateComponent } from './player-create/player-create.component';
import { SignupComponent } from './login_page/signup/signup.component';
import { LoginLayoutComponent } from './login_page/login-layout/login-layout.component';
import { IndicatorComponent } from './indicator/indicator.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AComponent,
    FooterComponent,
    ControlPanelComponent,
    LoginComponent,
    PlayerCreateComponent,
    SignupComponent,
    LoginLayoutComponent,
    IndicatorComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: AComponent},
      { path: 'home', component: HomeComponent},
      { path: 'signin', component: LoginLayoutComponent},
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
