import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DashboardService } from '../dashboard/dashboard.service';
import { FundActionService } from '../fund-action/fund-action.service';

@Component({
  selector: 'app-fund-action',
  templateUrl: './fund-action.component.html',
  styleUrls: ['./fund-action.component.css']
})
export class FundActionComponent implements OnInit {

  constructor(private formBuilder: FormBuilder,
    private service: FundActionService,
    private routeService: DashboardService,
    private router: Router) { }

  fundActionForm!: FormGroup;
  submitted: false | undefined;
  fundId = window.localStorage.getItem("fundId");

  ngOnInit(): void {
    if (!localStorage.getItem('accesstoken')) {
      this.router.navigate(['login']);
      return;
    }
    this.fundActionForm = this.formBuilder.group({
      id: [''],
      fundName: ['', Validators.required],
      description: ['', Validators.required]
    });

    if (this.fundId != 'null') {
      this.service.getFundDetailByID(this.fundId).subscribe(data => {
        this.fundActionForm.setValue(data);
      });
    }
  }

  onSubmit(form: any) {
    this.submitted = false;
    let insertCriteria = {
      FundName: form.value.fundName,
      Description: form.value.description
    }
    let updateCriteria = {
      id: form.value.id,
      FundName: form.value.fundName,
      Description: form.value.description
    }
    if (this.fundActionForm != undefined && this.fundActionForm.valid) {
      if (this.fundId == 'null') {
        this.service.insertFundDetail(insertCriteria).subscribe((data: any) => {
          if (data != undefined) {
            window.alert('Fund details are inserted successfully');
            this.routeService.getFundDetails().subscribe((data) => {
              if (data != undefined || data != null) {
                this.router.navigate(['dashboard'], {
                  state: { example: JSON.stringify(data) }
                });
              }
            });
          }
          else {
            window.alert('Error in inserting the details. Please retry');
          }
        });
      }
      else {
        this.service.updateFundDetail(updateCriteria).subscribe((data: any) => {
          if (data != undefined) {
            window.alert('Fund details are modified successfully');
            localStorage.setItem('fundID', '');
            this.routeService.getFundDetails().subscribe((data) => {
              if (data != undefined || data != null) {
                this.router.navigate(['dashboard'], {
                  state: { example: JSON.stringify(data) }
                });
              }
            });
          }
          else {
            window.alert('Error in updating the details. Please retry');
          }
        });
      }

    }
    else {
      window.alert('Both fields are mandatory to fill');
    }
  }

  logout(){
    localStorage.setItem('fundId', '');
    localStorage.setItem('accesstoken', '');
    localStorage.setItem('url', '');
    this.router.navigate(['']);
  }
}
