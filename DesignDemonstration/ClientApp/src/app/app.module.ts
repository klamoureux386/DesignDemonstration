import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

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
      { path: 'music-directory/band/:id', component: BandPageComponent },
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
export class AppModule { }
