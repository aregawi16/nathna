import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VerfContractDocumentComponent } from './verf-contract-document.component';

describe('VerfContractDocumentComponent', () => {
  let component: VerfContractDocumentComponent;
  let fixture: ComponentFixture<VerfContractDocumentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VerfContractDocumentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VerfContractDocumentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
