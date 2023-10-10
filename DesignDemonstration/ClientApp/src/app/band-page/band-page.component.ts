import { Component, Input, OnInit } from '@angular/core';
import { MusicDirectoryClient } from 'src/api.generated.clients';

@Component({
  selector: 'app-band-page',
  templateUrl: './band-page.component.html',
  styleUrls: ['./band-page.component.scss'],
  providers: [MusicDirectoryClient]
})
export class BandPageComponent implements OnInit {

  @Input() id = 0;

  constructor(private directoryClient: MusicDirectoryClient){
    
  }

  ngOnInit() 
  {
    console.log(this.id);
    this.directoryClient.get(this.id)
  }

}
