import { Component, OnInit } from '@angular/core';
import { ThemeService } from './nav-menu/theme-toggler/theme.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  title = 'app';

  constructor(private themeService: ThemeService,
    private router: Router) {}

  ngOnInit(): void {
    this.themeService.themeChanges().subscribe(themeName => {
      if (this.themeService.isValidThemeName(themeName))
        document.body.setAttribute('data-bs-theme', themeName);
      else
        throw new Error(`Attempted to apply invalid theme name ${themeName}.`)
    })
  }

  //Uses a fluid container for homepage; remaining site areas use a regular container.
  useFluidContainer(): boolean {
    return this.router.url === '/';
  }
}
