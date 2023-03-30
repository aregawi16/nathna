import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompletePreflightTrainingDialogComponent } from './complete-preflight-training-dialog.component';

describe('CompletePreflightTrainingDialogComponent', () => {
  let component: CompletePreflightTrainingDialogComponent;
  let fixture: ComponentFixture<CompletePreflightTrainingDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompletePreflightTrainingDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompletePreflightTrainingDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
