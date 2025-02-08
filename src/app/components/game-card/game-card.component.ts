import { toObservable } from '@angular/core/rxjs-interop';
import { BasketballConferencesService } from 'src/app/services/basketball-conferences.service';
import { Utility } from './../../../utility';
import { Component, computed, input } from '@angular/core';
import { Competitor } from '../../models/competitor';
import { Event } from '../../models/event';
import { of, startWith, switchMap, tap } from 'rxjs';

@Component({
  selector: 'app-game-card',
  templateUrl: './game-card.component.html',
  styleUrl: './game-card.component.css'
})
export class GameCardComponent {
  protected Utility = Utility;

  public game = input<Event | null>(null);

  protected isLoading = computed(() => !this.game());

  protected competitors = computed(() => {
    const game = this.game();

    if (!game || !game.competitions || game.competitions.length === 0) {
      return [{ id: 0 }, { id: 1 }];
    } else {
      return game.competitions[0].competitors ?? [];
    }
  });

  protected lineScoreHeaderColumnCount = computed(() => {
    const competitors = this.competitors();

    if (!competitors || competitors.length === 0) {
      return 3;
    } else {
      return (competitors[0].linescores?.length ?? 0) + 1;
    }
  })

  protected lineScoreHeaders = computed(() => {
    let headers: string[] = [];
    const game = this.game();

    if (!game) {
      return headers;
    }

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
  })

  protected isWinner(competitor: Competitor): boolean {
    const game = this.game();

    if (!game) {
      return false;
    }

    const competitors = this.competitors();

    if (competitors.length !== 2) {
      return false;
    }

    const winner = competitors.sort((a, b) => {
      return +(b.score ?? "0") - +(a.score ?? "0");
    })[0];

    if (!winner) {
      return false;
    }

    return winner.team?.id === competitor.team?.id;
  }

  protected gameNotes = computed(() => {
    const game = this.game();

    if (!game) {
      return [];
    }

    return game.competitions?.at(0)?.notes ?? [];
  });

  protected gameLocation = computed(() => {
    const game = this.game();

    if (!game) {
      return '';
    }

    const venueName = game.competitions?.at(0)?.venue?.fullName;
    const venueAddress = game.competitions?.at(0)?.venue?.address;
    const cityState = venueAddress ? `${venueAddress.city}, ${venueAddress.state}` : '';

    return `${venueName} (${cityState})`;
  });

  protected gameConferenceLogo$ = toObservable(this.game)
    .pipe(
      switchMap(game => {

        if (!game || !game.competitions || game.competitions.length === 0 || !game.competitions[0].groups || game.competitions[0].groups.length === 0) {
          return '';
        }

        return of("");
      })
    );

  constructor(private basketballConferencesService: BasketballConferencesService) { }
}
