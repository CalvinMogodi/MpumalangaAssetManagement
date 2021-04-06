import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ScheduleOfCurrentUtilisationComponent } from './schedule-of-current-utilisation.component';

describe('ScheduleOfCurrentUtilisationComponent', () => {
  let component: ScheduleOfCurrentUtilisationComponent;
  let fixture: ComponentFixture<ScheduleOfCurrentUtilisationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ScheduleOfCurrentUtilisationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ScheduleOfCurrentUtilisationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
