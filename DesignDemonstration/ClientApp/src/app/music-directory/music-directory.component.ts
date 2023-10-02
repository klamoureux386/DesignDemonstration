import { Component, OnInit } from '@angular/core';
import { BandDTO, MusicDirectoryClient, MusicDirectoryViewModel } from '../../api.generated.clients';
import { ToastrService } from 'ngx-toastr';
import { FeaturedArtistInfo } from './featured-artists/featured-artists.component';

@Component({
  selector: 'app-music-directory',
  templateUrl: './music-directory.component.html',
  styleUrls: ['./music-directory.component.css'],
  providers: [MusicDirectoryClient]
})
export class MusicDirectoryComponent implements OnInit {

  public model : MusicDirectoryViewModel = new MusicDirectoryViewModel();

  public bands: BandDTO[] = [];

  public featuredArtistsInfo: FeaturedArtistInfo[] = [];

  public images: string[] = [
    "../../assets/shiner-egg.jpg",
    "../../assets/dinosaurIcon.png"
  ];

  constructor(
    public directoryClient: MusicDirectoryClient,
    private toastr: ToastrService
    ) {
   }

  ngOnInit(): void {
    //https://rxjs.dev/deprecations/subscribe-arguments
    this.directoryClient.getAll().subscribe({
      next: (res) => this.bands = res,
      error: (err) => this.toastr.error(err.message),
    });

    this.directoryClient.getDirectoryHome().subscribe({
      next: (res) => this.model = res,
      error: (err) => this.toastr.error(err.message),
      complete: () => this.setFeaturedArtists()
    })

  }

  setFeaturedArtists() {

    let infos: FeaturedArtistInfo[] = []

    for(const artist of this.model.featuredArtists) {
      infos.push(new FeaturedArtistInfo(artist.bandName, "../../assets/shiner-egg.jpg", artist.description))
    }

    // infos.push(new FeaturedArtistInfo("Shiner", "../../assets/shiner-egg.jpg", "Shiner Description"));
    // infos.push(new FeaturedArtistInfo("No Knife", "../../assets/no-knife-fire.jpg", "No Knife Description"));
    // infos.push(new FeaturedArtistInfo("Rival Schools", "../../assets/rival-schools-united.jpg", "Rival Schools Description"));

    this.featuredArtistsInfo = infos;

    return infos;

  }

}
