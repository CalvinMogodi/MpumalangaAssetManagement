import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FacilityManagementComponent } from './facility-management.component';

describe('ViewPropertyComponent', () => {
  let component: FacilityManagementComponent;
  let fixture: ComponentFixture<FacilityManagementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FacilityManagementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FacilityManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
