import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CandidateActiveComponent } from './candidate-active.component';

describe('CandidateActiveComponent', () => {
  let component: CandidateActiveComponent;
  let fixture: ComponentFixture<CandidateActiveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CandidateActiveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CandidateActiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
