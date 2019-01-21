import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesorderlineComponent } from './salesorderline.component';

describe('SalesorderlineComponent', () => {
  let component: SalesorderlineComponent;
  let fixture: ComponentFixture<SalesorderlineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SalesorderlineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SalesorderlineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
