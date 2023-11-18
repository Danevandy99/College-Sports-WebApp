import { EspnApiService } from './../api/services/espn-api.service';
import { Component, computed, signal } from '@angular/core';
import { toObservable, toSignal } from '@angular/core/rxjs-interop';
import { switchMap } from 'rxjs';
import { ApiEspnApiScoreboardGet$Json$Params } from 'src/api/fn/espn-api/api-espn-api-scoreboard-get-json';
import { Competitor, Event, Team } from 'src/api/models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  protected date = signal(new Date());

  protected scoreboardResult = toSignal(toObservable(this.date).pipe(
    switchMap(date => {
      const data: ApiEspnApiScoreboardGet$Json$Params = { filterDate: date.toDateString() };

      return this.espnApiService.apiEspnApiScoreboardGet$Json(data)
    })
  ));

  protected games = computed(() => this.scoreboardResult()?.events ?? []);

  constructor(private espnApiService: EspnApiService) { }

  protected getCompetitors(game: Event): Competitor[] {
    if (!game.competitions || game.competitions.length === 0) {
      return [];
    } else {
      return game.competitions[0].competitors ?? [];
    }
  }
}
