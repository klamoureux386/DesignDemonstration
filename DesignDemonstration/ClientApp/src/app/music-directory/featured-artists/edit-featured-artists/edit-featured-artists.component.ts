import { Component, Input, OnInit } from '@angular/core';
import { FeaturedArtistInfo } from '../featured-artists.component';
import { FeaturedArtistClient } from 'src/api.generated.clients';

@Component({
  selector: 'app-edit-featured-artists',
  templateUrl: './edit-featured-artists.component.html',
  styleUrls: ['./edit-featured-artists.component.scss'],
  providers: [FeaturedArtistClient]
})
export class EditFeaturedArtistsComponent implements OnInit {
  featuredArtistsInfo!: FeaturedArtistInfo[];

  constructor(private featuredArtistClient: FeaturedArtistClient) {

  }

  ngOnInit() {
    this.featuredArtistClient.getAll().subscribe(res => {
      this.featuredArtistsInfo = res.map(b => new FeaturedArtistInfo(b.bandName, b.imgSrc, b.description)); 
    })
  }
}
