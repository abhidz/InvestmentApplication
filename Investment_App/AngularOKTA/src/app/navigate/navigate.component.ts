import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DashboardService } from '../dashboard/dashboard.service';


@Component({
  selector: 'app-navigate',
  templateUrl: './navigate.component.html',
  styleUrls: ['./navigate.component.css']
})
export class NavigateComponent implements OnInit {
  constructor(private router: Router, private service: DashboardService) { }

  ngOnInit(): void {
    this.service.authorizeCallback().subscribe((data: null | undefined) => {
      if (data != undefined || data != null) {
        this.router.navigate(['dashboard'], {
          state: { example: JSON.stringify(data) }
        });
      }
    });

  }

}
