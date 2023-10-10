import { Component, OnInit } from '@angular/core';
import { BandDTO, MusicDirectoryClient, MusicDirectoryViewModel } from '../../api.generated.clients';
import { ToastrService } from 'ngx-toastr';
import { FeaturedArtistInfo } from './featured-artists/featured-artists.component';

@Component({
  selector: 'app-music-directory',
  templateUrl: './music-directory.component.html',
  styleUrls: ['./music-directory.component.scss'],
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

    // infos.push(new FeaturedArtistInfo("test1", "../../assets/shiner-egg.jpg", "description1"))
    // infos.push(new FeaturedArtistInfo("test2", "../../assets/shiner-egg.jpg", "description2"))
    // infos.push(new FeaturedArtistInfo("test3", "../../assets/shiner-egg.jpg", "description3"))

    for(const artist of this.model.featuredArtists) {
      //infos.push(new FeaturedArtistInfo(artist.bandName, "../../assets/shiner-egg.jpg", artist.description))
      infos.push(new FeaturedArtistInfo(artist.bandName, "../../" + artist.imgSrc, artist.description))
    }

    this.featuredArtistsInfo = infos;

    return infos;

  }

}
