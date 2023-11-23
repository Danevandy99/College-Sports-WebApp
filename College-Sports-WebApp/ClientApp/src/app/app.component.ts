import { EspnApiService } from './../api/services/espn-api.service';
import { Component, computed, signal } from '@angular/core';
import { toObservable, toSignal } from '@angular/core/rxjs-interop';
import { switchMap } from 'rxjs';
import { ApiEspnApiScoreboardGet$Json$Params } from 'src/api/fn/espn-api/api-espn-api-scoreboard-get-json';
import { Competitor, Event, Team } from 'src/api/models';
import { Utility } from 'src/utility';
import { DarkModeService } from './services/dark-mode.service';

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

  constructor(private espnApiService: EspnApiService, protected darkModeService: DarkModeService) { }

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

  protected idealTextColor(bgColor?: string | null): string {

    if (!bgColor) {
      return '#000000';
    }

    var nThreshold = 105;
    var components = this.getRGBComponents(bgColor);
    var bgDelta = (components.R * 0.299) + (components.G * 0.587) + (components.B * 0.114);

    return ((255 - bgDelta) < nThreshold) ? "#000000" : "#ffffff";
  }

  private getRGBComponents(color: string): { R: number, G: number, B: number } {

    var r = color.substring(1, 3);
    var g = color.substring(3, 5);
    var b = color.substring(5, 7);

    return {
      R: parseInt(r, 16),
      G: parseInt(g, 16),
      B: parseInt(b, 16)
    };
  }

  protected competitorWinnerIndex(game: Event): number {
    const competitors = this.getCompetitors(game);

    if (competitors.length !== 2) {
      return -1;
    }

    const winner = competitors.sort((a, b) => {
      return +(b.score ?? "0") - +(a.score ?? "0");
    })[0];

    if (!winner) {
      return -1;
    }

    return competitors.indexOf(winner);
  }
}
