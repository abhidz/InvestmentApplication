import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../dashboard/dashboard.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  fundDetail: any = {};
  routeState: any;
  constructor(private service: DashboardService, private router: Router) {
    if (this.router.getCurrentNavigation()?.extras.state) {
      this.routeState = this.router.getCurrentNavigation()?.extras.state;
      this.fundDetail = this.routeState.example ? JSON.parse(this.routeState.example) : '';
    }
    else {
      this.service.authorizeCallback().subscribe((data: null | undefined) => {
        if (data != undefined || data != null) {
          this.fundDetail = data;
        }
      });
    }
  }

  ngOnInit() {
  }

  deleteFundDetails(response: any) {
    this.service.deleteFundDetails(response.id).subscribe((data) => {
      if (data != undefined || data != null) {
        window.alert('Selected Fund detail removed');
        location.reload();
      }
      else {
        window.alert('Error');
      }
    });
  }
  editFundDetails(response: any) {
    localStorage.setItem('fundId', response.id.toString());
    this.router.navigate(['fundAction']);
  }
  addNewFund() {
    localStorage.setItem('fundId', 'null');
    this.router.navigate(['fundAction']);
  }

  logout() {
    localStorage.setItem('fundId', '');
    localStorage.setItem('accesstoken', '');
    localStorage.setItem('url', '');
    this.router.navigate(['']);
  }
}