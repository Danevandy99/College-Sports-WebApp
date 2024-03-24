import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import { Meta } from '@angular/platform-browser';

@Injectable({
  providedIn: 'root'
})
export class DarkModeService {
  private readonly DARK_MODE_KEY = 'is-dark-mode';

  private isDarkModeSource$ = new BehaviorSubject<boolean>(this.getStartingDarkMode());
  public isDarkMode$ = this.isDarkModeSource$.asObservable()
    .pipe(
      tap(() => {
        this.meta.addTag({ name: 'theme-color', content: this.isDarkModeSource$.value ? '#121212' : '#ffffff' })
      }),
    );

  constructor(private meta: Meta) { }

  public toggleDarkMode(): void {
    this.setDarkMode(!this.isDarkModeSource$.value);
  }

  public setDarkMode(isDarkMode: boolean): void {
    this.isDarkModeSource$.next(isDarkMode);

    // Set local storage value
    localStorage.setItem(this.DARK_MODE_KEY, isDarkMode.toString());
  }

  private getStartingDarkMode(): boolean {
    const darkModeStringValue = localStorage.getItem(this.DARK_MODE_KEY);

    if (darkModeStringValue !== null && darkModeStringValue !== undefined) {
      const darkMode = darkModeStringValue === "true";

      return darkMode;
    } else {
      return window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches;
    }
  }
}
