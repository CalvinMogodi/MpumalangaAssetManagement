import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateFiveTwoComponent } from './template-five-two.component';

describe('TemplateFiveTwoComponent', () => {
  let component: TemplateFiveTwoComponent;
  let fixture: ComponentFixture<TemplateFiveTwoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TemplateFiveTwoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TemplateFiveTwoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy(); 
  });
});
