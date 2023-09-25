import { Component, Input, OnInit } from '@angular/core';
import { BandsClient } from 'src/api.generated.clients';

@Component({
  selector: 'app-band-page',
  templateUrl: './band-page.component.html',
  styleUrls: ['./band-page.component.css'],
  providers: [BandsClient]
})
export class BandPageComponent implements OnInit {

  @Input() id = 0;

  constructor(private bandsClient: BandsClient){
    
  }

  ngOnInit() 
  {
    console.log(this.id);
    this.bandsClient.get(this.id)
  }

}
