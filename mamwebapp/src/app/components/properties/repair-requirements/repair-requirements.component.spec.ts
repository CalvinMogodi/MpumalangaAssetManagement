import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RepairRequirementsComponent } from './repair-requirements.component';

describe('RepairRequirementsComponent', () => {
  let component: RepairRequirementsComponent;
  let fixture: ComponentFixture<RepairRequirementsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RepairRequirementsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RepairRequirementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
