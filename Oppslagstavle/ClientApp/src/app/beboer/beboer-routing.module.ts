import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AktiveOppslagComponent } from './aktive-oppslag/aktive-oppslag.component';
import { BeboerComponent } from './beboer.component';
import { ArkivComponent } from './arkiv/arkiv.component';

const routes: Routes = [
  {
    path: 'beboer',
    component: BeboerComponent,
    children: [
      { path: 'aktive', component: AktiveOppslagComponent },
      { path: 'arkiv', component: ArkivComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BeboerRoutingModule { }
