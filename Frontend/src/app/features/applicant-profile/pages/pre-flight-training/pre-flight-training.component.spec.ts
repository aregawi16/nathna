import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PreFlightTrainingComponent } from './pre-flight-training.component';

describe('PreFlightTrainingComponent', () => {
  let component: PreFlightTrainingComponent;
  let fixture: ComponentFixture<PreFlightTrainingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PreFlightTrainingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PreFlightTrainingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
