import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RefurbishmentReconfigurationComponent } from './refurbishment-reconfiguration.component';

describe('RefurbishmentReconfigurationComponent', () => {
  let component: RefurbishmentReconfigurationComponent;
  let fixture: ComponentFixture<RefurbishmentReconfigurationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RefurbishmentReconfigurationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RefurbishmentReconfigurationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
