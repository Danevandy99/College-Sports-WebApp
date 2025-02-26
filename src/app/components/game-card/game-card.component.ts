import { toObservable } from '@angular/core/rxjs-interop';
import { BasketballConferencesService } from 'src/app/services/basketball-conferences.service';
import { Utility } from './../../../utility';
import { Component, computed, input } from '@angular/core';
import { Competitor } from '../../models/competitor';
import { Event } from '../../models/event';
import { of, startWith, switchMap, tap } from 'rxjs';

interface GameTag {
  label: string;
  class: string;
}

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

  protected gameTags = computed(() => {
    const game = this.game();

    if (!game) {
      return [];
    }

    const tags: GameTag[] = [];

    // Is an upset alert?
    if (game.competitions?.[0]?.competitors?.length === 2 && !game.status?.type?.completed) {
      const [compA, compB] = game.competitions[0].competitors;
      const scoreA = +(compA.score ?? "0");
      const scoreB = +(compB.score ?? "0");

      if (scoreA !== 0 && scoreB !== 0) {
        // Determine winner and loser
        const winner = scoreA > scoreB ? compA : compB;
        const loser = winner === compA ? compB : compA;

        // Assume each team has a "ranking" property where a lower number is higher seeded.
        const winnerRank = Number(winner.curatedRank?.current);
        const loserRank = Number(loser.curatedRank?.current);

        // Check if both rankings are available and if the winner was lower seeded.
        if (!isNaN(winnerRank) && !isNaN(loserRank) && winnerRank > loserRank) {
          tags.push({
            label: `🚨 Upset Alert`,
            class: 'text-white bg-red-800'
          });
        }
      }
    }

    // Is a completed upset?
    if (game.status?.type?.completed && game.competitions?.[0]?.competitors) {
      const [compA, compB] = game.competitions[0].competitors;
      const scoreA = +(compA.score ?? "0");
      const scoreB = +(compB.score ?? "0");

      if (scoreA !== 0 && scoreB !== 0) {

        // Determine winner and loser
        const winner = scoreA > scoreB ? compA : compB;
        const loser = winner === compA ? compB : compA;

        // Assume each team has a "ranking" property where a lower number is higher seeded.
        const winnerRank = Number(winner.curatedRank?.current);
        const loserRank = Number(loser.curatedRank?.current);

        // Check if both rankings are available and if the winner was lower seeded.
        if (!isNaN(winnerRank) && !isNaN(loserRank) && winnerRank > loserRank) {
          tags.push({
            label: `🪣 Upset`,
            class: 'text-white bg-red-800'
          });
        }
      }
    }

    return tags;
  });

  constructor(private basketballConferencesService: BasketballConferencesService) { }
}
