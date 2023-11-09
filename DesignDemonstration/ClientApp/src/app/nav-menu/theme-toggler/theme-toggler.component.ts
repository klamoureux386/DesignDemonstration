import { Component } from '@angular/core';
import { ThemeService } from './theme.service';

@Component({
  selector: 'app-theme-toggler',
  templateUrl: './theme-toggler.component.html',
  styleUrls: ['./theme-toggler.component.scss']
})
export class ThemeTogglerComponent {

  theme: string = 'dark';

  constructor(private themeService: ThemeService) 
  { 
    
  }

  isLightMode() {
    return this.theme === 'light';
  }

  toggleTheme() {
    
    if (this.theme === 'dark') {
      this.theme = 'light'
    }
    else {
      this.theme = 'dark';
    }
    this.themeService.setTheme(this.theme);
  }
}
