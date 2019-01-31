import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-arkiv',
  templateUrl: './arkiv.component.html',
  styleUrls: ['./arkiv.component.css']
})
export class ArkivComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
  today = new Date();
}
