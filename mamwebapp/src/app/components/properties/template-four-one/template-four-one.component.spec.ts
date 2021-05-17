import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateFourOneComponent } from './template-four-one.component';

describe('TemplateFourOneComponent', () => {
  let component: TemplateFourOneComponent;
  let fixture: ComponentFixture<TemplateFourOneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TemplateFourOneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TemplateFourOneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
