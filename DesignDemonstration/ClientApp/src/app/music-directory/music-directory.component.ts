import { Component, OnInit } from '@angular/core';
import { BandDTO, BandsClient } from '../../api.generated.clients';

@Component({
  selector: 'app-music-directory',
  templateUrl: './music-directory.component.html',
  styleUrls: ['./music-directory.component.css']
})
export class MusicDirectoryComponent implements OnInit {

  private bandsClient: BandsClient
  public band : BandDTO = new BandDTO();

  constructor(bandsClient: BandsClient) {
    this.bandsClient = bandsClient;
   }

  ngOnInit(): void {
    this.bandsClient.get(1).subscribe(res => {
      this.band = res
    },
    error => {

    });
  }

}
