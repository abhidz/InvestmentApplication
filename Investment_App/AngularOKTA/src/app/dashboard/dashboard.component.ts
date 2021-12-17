import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../dashboard/dashboard.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  fundDetail: any;
  constructor(private service: DashboardService, private router: Router) {
  }

  ngOnInit() {
    debugger;
    this.service.authorizeCallback().subscribe((data: null | undefined) => {
      if (data != undefined || data != null) {
        this.fundDetail = data;
      }});
  }
}