import { Component, Input } from '@angular/core';
import { ThemeService } from 'src/app/nav-menu/theme-toggler/theme.service';
import { UserService } from 'src/app/user.service';

@Component({
  selector: 'app-featured-artists',
  templateUrl: './featured-artists.component.html',
  styleUrls: ['./featured-artists.component.scss'],
})
export class FeaturedArtistsComponent {
  @Input({required: true}) featuredArtistsInfo!: FeaturedArtistInfo[];


  constructor(public themeService: ThemeService,
    public userService: UserService) {

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
