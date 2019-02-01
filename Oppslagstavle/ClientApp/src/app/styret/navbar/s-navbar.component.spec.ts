import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SNavbarComponent } from './s-navbar.component';

describe('SNavbarComponent', () => {
  let component: SNavbarComponent;
  let fixture: ComponentFixture<SNavbarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SNavbarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
