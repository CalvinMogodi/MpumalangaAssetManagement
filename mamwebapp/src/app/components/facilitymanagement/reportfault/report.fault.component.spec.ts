import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportFaultComponent } from './report.fault.component';

describe('ReportFaultComponent', () => {
  let component: ReportFaultComponent;
  let fixture: ComponentFixture<ReportFaultComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportFaultComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportFaultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
