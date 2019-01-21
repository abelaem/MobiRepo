import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesforomComponent } from './salesforom.component';

describe('SalesforomComponent', () => {
  let component: SalesforomComponent;
  let fixture: ComponentFixture<SalesforomComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SalesforomComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SalesforomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
