import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompleteInsuranceDocumentComponent } from './complete-insurance-document.component';

describe('CompleteInsuranceDocumentComponent', () => {
  let component: CompleteInsuranceDocumentComponent;
  let fixture: ComponentFixture<CompleteInsuranceDocumentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompleteInsuranceDocumentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompleteInsuranceDocumentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
