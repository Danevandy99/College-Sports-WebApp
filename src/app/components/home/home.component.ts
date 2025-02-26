import { Conference } from 'src/app/models/conference';
import { Component, computed, signal } from '@angular/core';
import { toObservable, takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { injectQueryClient, createPendingObserverResult } from '@ngneat/query';
import { computedAsync } from 'ngxtension/computed-async';
import { switchMap, combineLatest } from 'rxjs';
import { ScoreboardResult } from 'src/app/models/scoreboard-result';
import { BasketballConferencesService } from 'src/app/services/basketball-conferences.service';
import { DarkModeService } from 'src/app/services/dark-mode.service';
import { EspnApiService } from 'src/app/services/espn-api.service';
import { Utility } from 'src/utility';
import { DateDropdownComponent } from '../date-dropdown/date-dropdown.component';
import { BasketballConferencesDropdownComponent } from '../basketball-conferences-dropdown/basketball-conferences-dropdown.component';
import { AsyncPipe, DatePipe, NgClass } from '@angular/common';
import { GameCardComponent } from '../game-card/game-card.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [DateDropdownComponent, BasketballConferencesDropdownComponent, AsyncPipe, NgClass, GameCardComponent, DatePipe,],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
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
  
  protected adOccurence = computed(() => Math.min(8, this.games().length));

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
