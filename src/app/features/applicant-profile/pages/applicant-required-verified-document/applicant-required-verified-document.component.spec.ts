import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicantRequiredVerifiedDocumentComponent } from './applicant-required-verified-document.component';

describe('ApplicantRequiredVerifiedDocumentComponent', () => {
  let component: ApplicantRequiredVerifiedDocumentComponent;
  let fixture: ComponentFixture<ApplicantRequiredVerifiedDocumentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicantRequiredVerifiedDocumentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApplicantRequiredVerifiedDocumentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
