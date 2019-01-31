import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ArkivComponent } from './arkiv.component';

describe('ArkivComponent', () => {
  let component: ArkivComponent;
  let fixture: ComponentFixture<ArkivComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ArkivComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ArkivComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
