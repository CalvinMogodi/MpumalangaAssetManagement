import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddMunicipalUtilityServicesComponent } from './add-municipal-utility-services';

describe('TemplateTwoComponent', () => {
  let component: AddMunicipalUtilityServicesComponent;
  let fixture: ComponentFixture<AddMunicipalUtilityServicesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddMunicipalUtilityServicesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => { 
    fixture = TestBed.createComponent(AddMunicipalUtilityServicesComponent);
    component = fixture.componentInstance; 
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
