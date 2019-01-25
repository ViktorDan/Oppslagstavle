import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect, inject, tick, fakeAsync } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { HomeComponent } from './home.component';
import { DebugElement } from '@angular/core';


describe('HomeComponent', () => {

  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;
  let de: DebugElement;


  beforeEach(async(() => {

    TestBed.configureTestingModule({
      declarations: [HomeComponent],

    })
      .compileComponents();
  }));

  beforeEach(() => {

    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    de = fixture.debugElement;

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

});
