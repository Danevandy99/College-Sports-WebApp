import { BasketballConferencesService } from './services/basketball-conferences.service';
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
  protected selectedConference = signal<string>("s:40~l:41~g:50");
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

  protected filteredGames = computed(() => {
    const allGames = this.scoreboardResult()?.events ?? [];
    const selectedConference = this.selectedConference();

    console.log(selectedConference)

    switch (selectedConference) {
      case "Top25":
        return allGames.filter(game => game.competitions?.[0].competitors?.some(competitor => (competitor.curatedRank?.current ?? 99) <= 25));
      case "Power6":
        return allGames.filter(game => game.competitions?.[0].competitors?.some(competitor => Utility.p6ConferenceIds.map(x => x.split(":").at(-1)).includes(competitor.team?.conferenceId ?? "")));
      case "Televised":
        return allGames.filter(game => game.competitions?.[0].broadcasts && game.competitions[0].broadcasts.length > 0);
      // NCAA Division 1
      case "s:40~l:41~g:50":
        return allGames;
      default:
        return allGames.filter(game => game.competitions?.[0].competitors?.some(competitor => competitor.team?.conferenceId === selectedConference.split(":").at(-1)));
    }
  })

  protected games = computed(() => {
    const allGames = this.filteredGames() ?? [];

    const finishedGames = allGames.filter(game => Utility.isGameFinished(game));
    const liveGames = allGames.filter(game => Utility.isGameLive(game));
    const scheduledGames = allGames.filter(game => Utility.isGameScheduled(game));

    return [...liveGames, ...scheduledGames, ...finishedGames]
  });

  constructor(
    private espnApiService: EspnApiService,
    protected darkModeService: DarkModeService,
    private basketballConferencesService: BasketballConferencesService) { }
}
