import { EspnApiService } from './../api/services/espn-api.service';
import { Component, computed, signal } from '@angular/core';
import { toObservable, toSignal } from '@angular/core/rxjs-interop';
import { of, switchMap, tap } from 'rxjs';
import { ApiEspnApiScoreboardGet$Json$Params } from 'src/api/fn/espn-api/api-espn-api-scoreboard-get-json';
import { Competitor, Event, ScoreboardResult, Team } from 'src/api/models';
import { Utility } from 'src/utility';
import { DarkModeService } from './services/dark-mode.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  protected Utility = Utility;

  protected date = signal(new Date());
  protected isLoading = signal(true);

  protected scoreboardResult = toSignal(toObservable(this.date).pipe(
    switchMap(date => {
      this.isLoading.set(true);

      const data: ApiEspnApiScoreboardGet$Json$Params = { filterDate: date.toDateString() };

      return this.espnApiService.apiEspnApiScoreboardGet$Json(data)
      //return of({} as ScoreboardResult);
    }),
    tap(() => this.isLoading.set(false))
  ));

  protected games = computed(() => {
    const allGames = this.scoreboardResult()?.events ?? [];

    const finishedGames = allGames.filter(game => Utility.isGameFinished(game));
    const liveGames = allGames.filter(game => Utility.isGameLive(game));
    const scheduledGames = allGames.filter(game => Utility.isGameScheduled(game));

    return [...liveGames, ...scheduledGames, ...finishedGames]
  });

  constructor(private espnApiService: EspnApiService, protected darkModeService: DarkModeService) { }
}
