import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicantContractAgreementComponent } from './applicant-contract-agreement.component';

describe('ApplicantContractAgreementComponent', () => {
  let component: ApplicantContractAgreementComponent;
  let fixture: ComponentFixture<ApplicantContractAgreementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicantContractAgreementComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApplicantContractAgreementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
