import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SArkivComponent } from './s-arkiv.component';

describe('SArkivComponent', () => {
  let component: SArkivComponent;
  let fixture: ComponentFixture<SArkivComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SArkivComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SArkivComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
