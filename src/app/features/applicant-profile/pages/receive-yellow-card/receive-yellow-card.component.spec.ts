import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReceiveYellowCardComponent } from './receive-yellow-card.component';

describe('ReceiveYellowCardComponent', () => {
  let component: ReceiveYellowCardComponent;
  let fixture: ComponentFixture<ReceiveYellowCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReceiveYellowCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReceiveYellowCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
