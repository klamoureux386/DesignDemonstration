import { Component, Input } from '@angular/core';
import { FeaturedArtistInfo } from '../featured-artists.component';

@Component({
  selector: 'app-edit-featured-artists',
  templateUrl: './edit-featured-artists.component.html',
  styleUrls: ['./edit-featured-artists.component.css']
})
export class EditFeaturedArtistsComponent {
  featuredArtistsInfo!: FeaturedArtistInfo[];
}
