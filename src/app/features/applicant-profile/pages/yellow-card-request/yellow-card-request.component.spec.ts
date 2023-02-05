import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YellowCardRequestComponent } from './yellow-card-request.component';

describe('YellowCardRequestComponent', () => {
  let component: YellowCardRequestComponent;
  let fixture: ComponentFixture<YellowCardRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ YellowCardRequestComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(YellowCardRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
