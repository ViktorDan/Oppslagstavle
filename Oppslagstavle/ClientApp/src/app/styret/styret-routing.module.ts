import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SAktiveOppslagComponent } from './aktive-oppslag/s-aktive-oppslag.component';
import { StyretComponent } from './styret.component';
import { SArkivComponent } from './arkiv/s-arkiv.component';
import { SNyComponent } from './s-ny/s-ny.component';

const routes: Routes = [
  {
    path: 'styret',
    component: StyretComponent,
    children: [
      { path: 's-aktive', component: SAktiveOppslagComponent },
      { path: 's-arkiv', component: SArkivComponent },
      { path: 's-ny', component: SNyComponent }

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StyretRoutingModule { }
