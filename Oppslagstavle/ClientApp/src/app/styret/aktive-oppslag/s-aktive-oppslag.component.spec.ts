import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SAktiveOppslagComponent } from './s-aktive-oppslag.component';

describe('SAktiveOppslagComponent', () => {
  let component: SAktiveOppslagComponent;
  let fixture: ComponentFixture<SAktiveOppslagComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SAktiveOppslagComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SAktiveOppslagComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
