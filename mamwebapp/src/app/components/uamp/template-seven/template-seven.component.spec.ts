import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { TemplateSevenComponent } from './template-seven.component';

describe('TemplateSevenComponent', () => {
  let component: TemplateSevenComponent;
  let fixture: ComponentFixture<TemplateSevenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TemplateSevenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TemplateSevenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
