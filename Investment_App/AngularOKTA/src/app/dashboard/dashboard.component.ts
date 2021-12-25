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
    this.service.authorizeCallback().subscribe((data: null | undefined) => {
      if (data != undefined || data != null) {
        this.fundDetail = data;
      }});
  }
  
  deleteFundDetails(response:any){
    this.service.deleteFundDetails(response.id).subscribe((data) => {
      if (data != undefined || data != null) {
        window.alert('Selected Fund detail removed')
        location.reload();
      }
      else{
        window.alert('Error');
      }
    });
  }
  editFundDetails(response:any){
    localStorage.setItem('fundId',response.id.toString());
    this.router.navigate(['fundAction']);
  }
  addNewFund(){
    localStorage.setItem('fundId','null');
   this.router.navigate(['fundAction']);
  }
}