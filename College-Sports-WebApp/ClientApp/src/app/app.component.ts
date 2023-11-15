import { Component, computed, signal } from '@angular/core';
import { SportsDataApiService } from 'src/api/services/sports-data-api.service';
import { toObservable, toSignal } from '@angular/core/rxjs-interop';
import { switchMap } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  protected date = signal(new Date());

  protected games = toSignal(toObservable(this.date).pipe(
    switchMap(date => {
      const data = { date: date.toISOString() };

      return this.sportsDataApiService.apiSportsDataApiScoresByDateGet$Json(data)
    })
  ));

  constructor(private sportsDataApiService: SportsDataApiService) { }
}
