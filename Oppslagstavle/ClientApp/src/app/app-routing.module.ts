import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BeboerRoutingModule } from './beboer/beboer-routing.module';
import { StyretRoutingModule } from './styret/styret-routing.module';
import { HomeComponent } from './home/home.component';
import { StyretComponent } from './styret/styret.component';
import { BeboerComponent } from './beboer/beboer.component';

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'styret', component: StyretComponent },
  { path: 'beboer', component: BeboerComponent },
];
@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    BeboerRoutingModule,
    StyretRoutingModule
  ],
  exports: [RouterModule],
  
})
export class AppRoutingModule { }
