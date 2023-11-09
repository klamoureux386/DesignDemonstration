import { Component, OnInit } from '@angular/core';
import { ThemeService } from './nav-menu/theme-toggler/theme.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'app';

  constructor(private themeService: ThemeService) {}

  ngOnInit(): void {
    this.themeService.themeChanges().subscribe(themeName => {
      if (this.themeService.isValidThemeName(themeName))
        document.body.setAttribute('data-bs-theme', themeName);
      else
        throw new Error(`Attempted to apply invalid theme name ${themeName}.`)
    })
  }
}
