import { EspnApiService } from './../api/services/espn-api.service';
import { Component, computed, signal } from '@angular/core';
import { toObservable, toSignal } from '@angular/core/rxjs-interop';
import { switchMap } from 'rxjs';
import { ApiEspnApiScoreboardGet$Json$Params } from 'src/api/fn/espn-api/api-espn-api-scoreboard-get-json';
import { Competitor, Event, Team } from 'src/api/models';
import { Utility } from 'src/utility';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  protected Utility = Utility;

  protected date = signal(new Date());

  protected scoreboardResult = toSignal(toObservable(this.date).pipe(
    switchMap(date => {
      const data: ApiEspnApiScoreboardGet$Json$Params = { filterDate: date.toDateString() };

      return this.espnApiService.apiEspnApiScoreboardGet$Json(data)
    })
  ));

  protected games = computed(() => {
    const allGames = this.scoreboardResult()?.events ?? [];

    const finishedGames = allGames.filter(game => Utility.isGameFinished(game));
    const liveGames = allGames.filter(game => Utility.isGameLive(game));
    const scheduledGames = allGames.filter(game => Utility.isGameScheduled(game));

    return [...liveGames, ...scheduledGames, ...finishedGames]
  });

  constructor(private espnApiService: EspnApiService) { }

  protected getCompetitors(game: Event): Competitor[] {
    if (!game.competitions || game.competitions.length === 0) {
      return [];
    } else {
      return game.competitions[0].competitors ?? [];
    }
  }

  protected getLineScoreHeaders(game: Event): string[] {
    let headers = [];
    const lineScores = game.competitions?.at(0)?.competitors?.at(0)?.linescores ?? [];

    if (lineScores.length <= 2) {
      headers = lineScores.map((_, index) => (index + 1).toString());
    } else {
      headers = lineScores.map((_, index) => {
        if (index === 0) {
          return '1';
        } else if (index === 1) {
          return '2';
        } else if (index === 2) {
          return 'OT';
        } else {
          return `${index - 1}OT`;
        }
      });
    }

    return [...headers, 'T'];
  }
}
