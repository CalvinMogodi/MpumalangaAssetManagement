import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewUampComponent } from './view-uamp.component';

describe('ViewUampComponent', () => {
  let component: ViewUampComponent;
  let fixture: ComponentFixture<ViewUampComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewUampComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewUampComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
