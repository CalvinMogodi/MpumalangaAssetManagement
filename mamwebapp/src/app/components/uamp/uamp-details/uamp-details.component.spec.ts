import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UampDetailsComponent } from './uamp-details.component';

describe('ViewUampComponent', () => {
  let component: UampDetailsComponent;
  let fixture: ComponentFixture<UampDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UampDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UampDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
