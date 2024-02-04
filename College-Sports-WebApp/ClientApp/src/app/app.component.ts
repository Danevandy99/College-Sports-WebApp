import { BasketballConferencesService } from './services/basketball-conferences.service';
import { Component, computed, signal } from '@angular/core';
import { takeUntilDestroyed, toObservable, toSignal } from '@angular/core/rxjs-interop';
import { of, switchMap, tap } from 'rxjs';
import { Utility } from 'src/utility';
import { DarkModeService } from './services/dark-mode.service';
import { EspnApiService } from './services/espn-api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  private readonly SELECTED_CONFERENCE_KEY = "selectedConference";

  protected Utility = Utility;

  protected dateString = signal(Utility.getDefaultDate());
  protected selectedConference = signal<string>(this.getDefaultSelectedConferenceFromLocalStorage());
  protected isLoading = signal(true);

  protected selectedConferenceName$ = toObservable(this.selectedConference).pipe(
    switchMap(selectedConference => this.basketballConferencesService.getConferenceName(selectedConference))
  );

  protected scoreboardResult = toSignal(toObservable(this.dateString).pipe(
    switchMap(dateString => {
      this.isLoading.set(true);

      return this.espnApiService.getScoreboard(new Date(dateString));
    }),
    tap(() => this.isLoading.set(false))
  ));

  protected filteredGames = computed(() => {
    const allGames = this.scoreboardResult()?.events ?? [];
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
