import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { OKTA_CONFIG, OktaAuthModule, OktaAuthGuard, OktaCallbackComponent } from '@okta/okta-angular';
import { OktaAuth } from '@okta/okta-auth-js';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { DashboardService } from './dashboard/dashboard.service';
import { FundActionComponent } from './fund-action/fund-action.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';

const appRoutes: Routes = [
  {
    path: 'callback',
    component:DashboardComponent
  },
  {
    path: 'dashboard',
    component:DashboardComponent
  },
  {
    path: 'fundAction',
    component:FundActionComponent
  }
]

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    LoginComponent,
    FundActionComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes)
],
  providers: [DashboardService],
  bootstrap: [AppComponent]
})
export class AppModule { }
