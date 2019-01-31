import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BeboerRoutingModule } from './beboer/beboer-routing.module';
import { AktiveOppslagComponent } from './beboer/aktive-oppslag/aktive-oppslag.component';
import { HomeComponent } from './home/home.component';
import { StyretComponent } from './styret/styret.component';
import { BeboerComponent } from './beboer/beboer.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'styret', component: StyretComponent },
  { path: 'beboer', component: BeboerComponent },
];
@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    BeboerRoutingModule
  ],
  exports: [RouterModule],
  
})
export class AppRoutingModule { }
