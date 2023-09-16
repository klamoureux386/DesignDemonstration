import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-band-page',
  templateUrl: './band-page.component.html',
  styleUrls: ['./band-page.component.css']
})
export class BandPageComponent implements OnInit {

  @Input() id = 0;

  constructor(){}

  ngOnInit() 
  {
    console.log(this.id);
  }

}
