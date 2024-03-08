import { createPendingObserverResult, injectQuery, injectQueryClient } from '@ngneat/query';
import { BasketballConferencesService } from './services/basketball-conferences.service';
import { Component, computed, signal, effect } from '@angular/core';
import { takeUntilDestroyed, toObservable, toSignal } from '@angular/core/rxjs-interop';
import { combineLatest, of, switchMap, tap } from 'rxjs';
import { Utility } from 'src/utility';
import { DarkModeService } from './services/dark-mode.service';
import { EspnApiService } from './services/espn-api.service';
import { computedAsync } from 'ngxtension/computed-async';
import { ScoreboardResult } from './models/scoreboard-result';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  private readonly SELECTED_CONFERENCE_KEY = "selectedConference";

  private readonly queryClient = injectQueryClient();

  protected Utility = Utility;

  protected dateString = signal(Utility.getDefaultDate());
  protected selectedConference = signal<string>(this.getDefaultSelectedConferenceFromLocalStorage());

  protected selectedConferenceName$ = toObservable(this.selectedConference).pipe(
    switchMap(selectedConference => this.basketballConferencesService.getConferenceName(selectedConference))
  );

  protected scoreboardResult = computedAsync(() => this.espnApiService.getScoreboard(new Date(this.dateString())).result$, {
    initialValue: createPendingObserverResult<ScoreboardResult>(),
  });

  protected filteredGames = computed(() => {
    // This make sure that the scoreboard gets refreshed if it's stale and we change the filter
    this.queryClient.prefetchQuery(this.espnApiService.getScoreboardQueryOptions(new Date(this.dateString())));

    const result = this.scoreboardResult();

    if (!result.data) {
      return [];
    }

    const allGames = result.data.events ?? [];
    const selectedConference = this.selectedConference();

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
    private basketballConferencesService: BasketballConferencesService) {
    toObservable(this.selectedConference)
      .pipe(takeUntilDestroyed())
      .subscribe(selectedConference => {
        localStorage.setItem(this.SELECTED_CONFERENCE_KEY, selectedConference);
      });

    // When the scoreboard or selected conference changes, scroll to the top of the page
    combineLatest([
      toObservable(this.scoreboardResult),
      toObservable(this.selectedConference)
    ])
      .pipe(takeUntilDestroyed())
      .subscribe(() => {
        console.log("scrolling to top")
        window.scrollTo(0, 0);
      });
  }

  protected setDate(dateString: string | null): void {
    const value = dateString ? dateString : Utility.getDefaultDate();
    this.dateString.set(value);
  }

  private getDefaultSelectedConferenceFromLocalStorage(): string {
    const selectedConference = localStorage.getItem(this.SELECTED_CONFERENCE_KEY);
    if (selectedConference) {
      return selectedConference;
    } else {
      return "s:40~l:41~g:50";
    }
  }
}
