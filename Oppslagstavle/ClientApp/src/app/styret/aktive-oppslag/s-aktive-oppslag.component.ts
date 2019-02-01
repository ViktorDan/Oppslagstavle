import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'styret-aktive-oppslag',
  templateUrl: './s-aktive-oppslag.component.html',
  styleUrls: ['./s-aktive-oppslag.component.css']
})
export class SAktiveOppslagComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
  today = new Date();
}
