import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SNyComponent } from './s-ny.component';

describe('SNyComponent', () => {
  let component: SNyComponent;
  let fixture: ComponentFixture<SNyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SNyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SNyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
