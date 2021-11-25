import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConditionAssessmentComponent } from './condition-assessment.component';

describe('ViewPropertyComponent', () => {
  let component: ConditionAssessmentComponent;
  let fixture: ComponentFixture<ConditionAssessmentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConditionAssessmentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConditionAssessmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
