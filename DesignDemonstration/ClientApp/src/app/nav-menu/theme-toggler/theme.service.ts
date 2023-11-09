import { Injectable, OnInit } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {

  private themeName: string = 'dark';
  public selectedTheme: BehaviorSubject<string> = new BehaviorSubject<string>(this.themeName);

  constructor() { }

  getTheme() {
    return this.selectedTheme.value;
  }

  setTheme(name: string) {
    if (this.isValidThemeName(name))
      this.selectedTheme.next(name);
    else
      throw new Error(`Theme name ${name} is not a valid theme.`);
  }

  //Gets subscribed to in app.component where the theme is applied to the <body> tag's data-bs-theme attribute.
  //https://getbootstrap.com/docs/5.3/customize/color-modes/#how-it-works
  themeChanges(): Observable<string> {
    return this.selectedTheme.asObservable();
  }

  isValidThemeName(name: string) {
    return name === 'light' || name === 'dark';
  }
}