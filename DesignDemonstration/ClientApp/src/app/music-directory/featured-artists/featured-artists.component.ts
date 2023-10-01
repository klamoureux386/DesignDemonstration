import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-featured-artists',
  templateUrl: './featured-artists.component.html',
  styleUrls: ['./featured-artists.component.scss']
})
export class FeaturedArtistsComponent {
  @Input({required: true}) featuredArtistsInfo!: FeaturedArtistInfo[];

  constructor() {
    
  }

}

export class FeaturedArtistInfo {
  bandName: string;
  imgSrc: string;
  description: string;

  constructor(bandName: string, imgSrc: string, description: string) {
    this.bandName = bandName;
    this.imgSrc = imgSrc;
    this.description = description;
  }
}
