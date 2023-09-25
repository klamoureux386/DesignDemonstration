import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, UrlMatchResult, UrlSegment } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ArchitectureDirectoryComponent } from './architecture-directory/architecture-directory.component';
import { MusicDirectoryComponent } from './music-directory/music-directory.component';
import { GameDesignComponent } from './game-design/game-design.component';
import { ToastrModule } from 'ngx-toastr';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { BandPageComponent } from './band-page/band-page.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FeaturedArtistsComponent } from './music-directory/featured-artists/featured-artists.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent, //Remove
    ArchitectureDirectoryComponent,
    MusicDirectoryComponent,
    GameDesignComponent,
    PageNotFoundComponent,
    BandPageComponent,
    FeaturedArtistsComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'fetch', component: FetchDataComponent }, //Remove
      { path: 'game-design', component: GameDesignComponent },
      { path: 'architecture-directory', component: ArchitectureDirectoryComponent },
      { path: 'music-directory', component: MusicDirectoryComponent },

      { matcher: (url) => OnlyMatchNumericBandIds(url), component: BandPageComponent },
      { path: '**', component: PageNotFoundComponent, pathMatch: 'full' },
    ],
    //https://itnext.io/bind-route-info-to-component-inputs-new-router-feature-1d747e559dc4
    //Allows for direct Component @Input from route parameters
    { bindToComponentInputs: true }),
    ToastrModule.forRoot({
      positionClass :'toast-top-right'
    }),
    NgbModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { 

}

//{ path: 'music-directory/band/:id', component: BandPageComponent },
//Same as above but only matches numeric bandIds. If the id params 
export function OnlyMatchNumericBandIds(url: UrlSegment[]) : UrlMatchResult | null {
  if (
    url.length == 3
    && url[0].path == 'music-directory'
    && url[1].path == 'band'
    && url[2].path.match(RegExp("^[0-9]"))) 
  {
    return {
      consumed: url,
      posParams: {
        id: new UrlSegment(url[2].path, {})
      }
    };
  }
  else {
    return null;
  }
}