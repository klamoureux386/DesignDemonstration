import { Component, Input, OnInit } from '@angular/core';
import { FeaturedArtistInfo } from '../featured-artists.component';
import { MusicDirectoryClient } from 'src/api.generated.clients';

@Component({
  selector: 'app-edit-featured-artists',
  templateUrl: './edit-featured-artists.component.html',
  styleUrls: ['./edit-featured-artists.component.css'],
  providers: [MusicDirectoryClient]
})
export class EditFeaturedArtistsComponent implements OnInit {
  featuredArtistsInfo!: FeaturedArtistInfo[];

  constructor(private featuredArtistClient: MusicDirectoryClient) {

  }

  ngOnInit() {
    //To do: change this to featured artist controller
    this.featuredArtistClient.getAll().subscribe(res => {
      res.map(b => b) 
    })
  }
}
