import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'styret-arkiv',
  templateUrl: './s-arkiv.component.html',
  styleUrls: ['./s-arkiv.component.css']
})
export class SArkivComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
  today = new Date();
}
