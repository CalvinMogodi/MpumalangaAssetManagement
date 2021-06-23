import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UampComponent } from './uamp.component';

describe('UampComponent', () => {
  let component: UampComponent;
  let fixture: ComponentFixture<UampComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UampComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UampComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
