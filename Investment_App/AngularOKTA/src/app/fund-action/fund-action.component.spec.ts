import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FundActionComponent } from './fund-action.component';

describe('FundActionComponent', () => {
  let component: FundActionComponent;
  let fixture: ComponentFixture<FundActionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FundActionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FundActionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
