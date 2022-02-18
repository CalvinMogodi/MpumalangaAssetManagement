import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LeasedPropertyComponent } from './leased-property.component';

describe('ViewPropertyComponent', () => {
  let component: LeasedPropertyComponent;
  let fixture: ComponentFixture<LeasedPropertyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LeasedPropertyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LeasedPropertyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
