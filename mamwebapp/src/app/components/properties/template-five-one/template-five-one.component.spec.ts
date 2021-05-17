import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateFiveOneComponent } from './template-five-one.component';

describe('TemplateFiveOneComponent', () => {
  let component: TemplateFiveOneComponent;
  let fixture: ComponentFixture<TemplateFiveOneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TemplateFiveOneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TemplateFiveOneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy(); 
  });
});
