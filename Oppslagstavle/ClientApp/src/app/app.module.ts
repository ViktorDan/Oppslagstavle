import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { BeboerComponent } from './beboer/beboer.component';
import { StyretComponent } from './styret/styret.component';
import { NavbarComponent } from './beboer/navbar/navbar.component';
import { SNavbarComponent } from './styret/navbar/s-navbar.component';
import { AktiveOppslagComponent } from './beboer/aktive-oppslag/aktive-oppslag.component';
import { SAktiveOppslagComponent } from './styret/aktive-oppslag/s-aktive-oppslag.component';
import { AppRoutingModule } from './app-routing.module';
import { ArkivComponent } from './beboer/arkiv/arkiv.component';
import { SArkivComponent } from './styret/arkiv/s-arkiv.component';
import { SNyComponent } from './styret/s-ny/s-ny.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    BeboerComponent,
    StyretComponent,
    NavbarComponent,
    AktiveOppslagComponent,
    ArkivComponent,
    SNavbarComponent,
    SAktiveOppslagComponent,
    SArkivComponent,
    SNyComponent,
  ],
  imports: [
    BrowserModule,
    HttpModule,
    JsonpModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
