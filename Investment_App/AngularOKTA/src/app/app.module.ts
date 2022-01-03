import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { DashboardService } from './dashboard/dashboard.service';
import { FundActionComponent } from './fund-action/fund-action.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NavigateComponent } from './navigate/navigate.component';
import { TokenInterceptor } from './interceptors/token-interceptor';
import { HandleExceptionInterceptor } from './interceptors/handle-exception';

const appRoutes: Routes = [
  {
    path: '',
    component: LoginComponent
  },
  {
    path: 'callback',
    component: NavigateComponent
  },
  {
    path: 'dashboard',
    component: DashboardComponent
  },
  {
    path: 'fundAction',
    component: FundActionComponent
  }
]

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    LoginComponent,
    FundActionComponent,
    NavigateComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [DashboardService,
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: HandleExceptionInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
