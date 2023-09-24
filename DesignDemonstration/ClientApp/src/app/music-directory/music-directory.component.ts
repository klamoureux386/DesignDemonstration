import { Component, OnInit } from '@angular/core';
import { BandDTO, BandsClient } from '../../api.generated.clients';
import { ToastrService } from 'ngx-toastr';
import { FeaturedArtistInfo } from './featured-artists/featured-artists.component';

@Component({
  selector: 'app-music-directory',
  templateUrl: './music-directory.component.html',
  styleUrls: ['./music-directory.component.css'],
  providers: [BandsClient]
})
export class MusicDirectoryComponent implements OnInit {

  public bands: BandDTO[] = [];

  public featuredArtistsInfo: FeaturedArtistInfo[] = [];

  public images: string[] = [
    "../../assets/shiner-egg.jpg",
    "../../assets/dinosaurIcon.png"
  ];

  constructor(
    public bandsClient: BandsClient,
    private toastr: ToastrService
    ) {
   }

  ngOnInit(): void {
    //https://rxjs.dev/deprecations/subscribe-arguments
    this.bandsClient.getAll().subscribe({
      next: (res) => this.bands = res,
      error: (err) => this.toastr.error(err.message),
    });

    this.featuredArtistsInfo = this.getFeaturedArtists();

  }

  getFeaturedArtists(): FeaturedArtistInfo[] {

    let infos: FeaturedArtistInfo[] = []

    infos.push(new FeaturedArtistInfo("Shiner", "../../assets/shiner-egg.jpg", "Shiner Description"));
    infos.push(new FeaturedArtistInfo("No Knife", "../../assets/no-knife-fire.jpg", "No Knife Description"));
    infos.push(new FeaturedArtistInfo("Rival Schools", "../../assets/rival-schools-united.jpg", "Rival Schools Description"));

    return infos;

  }

}
