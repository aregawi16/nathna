import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PreflightTrainingDialogComponent } from './preflight-training-dialog.component';

describe('PreflightTrainingDialogComponent', () => {
  let component: PreflightTrainingDialogComponent;
  let fixture: ComponentFixture<PreflightTrainingDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PreflightTrainingDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PreflightTrainingDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
