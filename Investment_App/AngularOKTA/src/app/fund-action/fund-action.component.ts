import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FundActionService } from '../fund-action/fund-action.service';

@Component({
  selector: 'app-fund-action',
  templateUrl: './fund-action.component.html',
  styleUrls: ['./fund-action.component.css']
})
export class FundActionComponent implements OnInit {

  constructor(private formBuilder: FormBuilder,
    private service: FundActionService,
    private router: Router) { }

  fundActionForm: FormGroup | undefined;
  submitted: false | undefined;

  ngOnInit(): void {
    this.fundActionForm = this.formBuilder.group({
      afundName: ['', Validators.required],
      description: ['', Validators.required]
    });
  }

  onSubmit(form: any) {
    debugger;
    this.submitted = false;
    let criteria = {
      FundName: form.value.afundName,
      Description: form.value.description
    }
    if (this.fundActionForm != undefined && this.fundActionForm.valid) {
      this.service.insertFund(criteria).subscribe((data: any) => {
        debugger;
        if (data != undefined) {
          this.router.navigate(['dashboard']);
        }
        else {
          window.alert('Error in inserting the details. Please retry');
        }
      });
    }
    else{
      window.alert('Both fields are mandatory to fill');
    }
  }

}
