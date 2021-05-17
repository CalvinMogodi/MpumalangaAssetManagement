import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateTwoTwoComponent } from './template-two-two.component';

describe('TemplateTwoComponent', () => {
  let component: TemplateTwoTwoComponent;
  let fixture: ComponentFixture<TemplateTwoTwoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TemplateTwoTwoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => { 
    fixture = TestBed.createComponent(TemplateTwoTwoComponent);
    component = fixture.componentInstance; 
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
