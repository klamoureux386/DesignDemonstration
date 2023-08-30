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

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent, //Remove
    ArchitectureDirectoryComponent,
    MusicDirectoryComponent,
    GameDesignComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'game-design', component: GameDesignComponent },
      { path: 'architecture-directory', component: ArchitectureDirectoryComponent },
      { path: 'music-directory', component: MusicDirectoryComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
