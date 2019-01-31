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
import { NavbarComponent } from './navbar/navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    BeboerComponent,
    StyretComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    JsonpModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([

      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'beboer', component: BeboerComponent },
      { path: 'styret', component: StyretComponent }
    ]) 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
