import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DepartamentJobsComponent } from './departament-jobs.component';

describe('DepartamentJobsComponent', () => {
  let component: DepartamentJobsComponent;
  let fixture: ComponentFixture<DepartamentJobsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DepartamentJobsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DepartamentJobsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
