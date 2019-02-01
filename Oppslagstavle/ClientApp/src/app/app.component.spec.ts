import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect, inject, tick, fakeAsync } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { Location } from '@angular/common';
import { RouterTestingModule } from '@angular/router/testing';
import { Router } from '@angular/router';
import { DebugElement } from '@angular/core';

import { HomeComponent } from './home/home.component';
import { StyretComponent } from './styret/styret.component';
import { BeboerComponent } from './beboer/beboer.component';
import { routes } from './app-routing.module';
import { AppComponent } from './app.component';

describe('Router: App', () => {

  let location: Location;
  let router: Router;
  let fixture;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule.withRoutes(routes)],
      declarations: [
        HomeComponent,
        BeboerComponent,
        StyretComponent,
        AppComponent
      ] 
    });

    router = TestBed.get(Router);
    location = TestBed.get(Location);
    fixture = TestBed.createComponent(AppComponent);
    router.initialNavigation();
  });

  it('navigate to "" should redirect to /home', fakeAsync(() => {
    router.navigate(['']);
    tick();
    expect(location.path()).toBe('/home');
  }));
});
