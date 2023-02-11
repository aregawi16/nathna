import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VerifyFlightTicketComponent } from './verify-flight-ticket.component';

describe('VerifyFlightTicketComponent', () => {
  let component: VerifyFlightTicketComponent;
  let fixture: ComponentFixture<VerifyFlightTicketComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VerifyFlightTicketComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VerifyFlightTicketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
