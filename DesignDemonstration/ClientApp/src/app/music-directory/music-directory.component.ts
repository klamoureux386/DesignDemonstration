import { Component, OnInit } from '@angular/core';
import { BandDTO, BandsClient } from '../../api.generated.clients';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-music-directory',
  templateUrl: './music-directory.component.html',
  styleUrls: ['./music-directory.component.css'],
  providers: [BandsClient]
})
export class MusicDirectoryComponent implements OnInit {

  public bands : BandDTO[] = [];

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
  }

}
