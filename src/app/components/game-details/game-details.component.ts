import { Component, Input, OnInit, computed, inject, input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EspnApiService } from '../../services/espn-api.service';
import { EventSummary } from '../../models/event-summary';
import { computedAsync } from 'ngxtension/computed-async';
import { createPendingObserverResult } from '@ngneat/query';
import { DarkModeService } from 'src/app/services/dark-mode.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-game-detail',
  standalone: true,
  imports: [CommonModule, RouterLink],
  template: `
    <div [ngClass]="{ dark: (darkModeService.isDarkMode$ | async) }">
    <div class="min-h-screen flex flex-col bg-gray-100 dark:bg-gray-950">
      <div
        class="w-full sticky top-0 bottom-0 flex flex-row items-center bg-[#fff] dark:bg-gray-900 border-b-[1px] border-b-gray-100 dark:border-b-gray-950 z-50 pt-[env(safe-area-inset-top)]"
      >
      <div class="container flex gap-x-2 items-center py-2">
          <img priority src="assets/favicon.ico" class="h-8 w-8 rounded" />

          <button
            routerLink="/"
            class="text-xs py-1.5 pl-3 px-3 flex gap-2 items-center rounded-lg h-9 bg-gray-100 cursor-pointer border-r-8 border-r-transparent text-gray-900 focus:ring-gray-500 dark:bg-gray-800 dark:placeholder-gray-400 dark:text-[#fff] dark:focus:ring-gray-500"
          >
            <svg
              class="h-4 w-4"
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
              [style.view-transition-name]="'arrow-left'"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                stroke-width="2"
                d="M10 19l-7-7m0 0l7-7m-7 7h18"
              ></path>
            </svg>
            Back to Games
          </button>
      </div>

      <div class="flex flex-row">
        @let awayTeam = awayTeam()
      <div class="flex flex-col items-center w-1/3">
            <div *ngIf="awayTeam()?.team?.logo" class="h-24 w-24">
              <img [src]="awayTeam()?.team?.logo" [alt]="awayTeam()?.team?.displayName" class="w-full h-full object-contain">
            </div>
            <div class="text-center mt-2">
              <h2 class="font-bold text-2xl">{{ awayTeam()?.team?.displayName }}</h2>
              <p class="text-4xl font-bold">{{ awayScore() }}</p>
            </div>
          </div>
    </div>
  `
})
export class GameDetailComponent implements OnInit {
  private espnApiService = inject(EspnApiService);
  protected darkModeService = inject(DarkModeService);

  protected eventId = input.required<number>();

  protected summaryQuery = computedAsync(() => this.espnApiService.getSummary(this.eventId()).result$, {
    initialValue: createPendingObserverResult<EventSummary>(),
  });

  // Computed properties now based on summaryQuery
  competitors = computed(() => {
    if (!this.summaryQuery().data?.boxscore.teams) return [];
    return this.summaryQuery().data?.boxscore.teams ?? [];
  });

  homeTeam = computed(() => {
    return this.competitors().find(c => c.homeAway === 'home');
  });

  awayTeam = computed(() => {
    return this.competitors().find(c => c.homeAway === 'away');
  });

  homeScore = computed(() => {
    const scoreStatistic = this.homeTeam()?.statistics?.find(stat => stat.name === 'points');
    return scoreStatistic?.displayValue || '0';
  });

  awayScore = computed(() => {
    const scoreStatistic = this.awayTeam()?.statistics?.find(stat => stat.name === 'points');
    return scoreStatistic?.displayValue || '0';
  });

  gameStatus = computed(() => {
    const competition = this.summaryQuery().data?.header.competitions[0];
    if (!competition) return 'Unknown';
    return competition.status?.type?.shortDetail || 'Unknown';
  });

  gameNote = computed(() => {
    return this.summaryQuery().data?.header.gameNote || '';
  });

  venue = computed(() => {
    return this.summaryQuery().data?.gameInfo.venue;
  });

  winProbability = computed(() => {
    return this.summaryQuery().data?.winprobability || [];
  });

  currentWinPercent = computed(() => {
    const winProb = this.winProbability();
    if (winProb.length === 0) return 50;
    return winProb[winProb.length - 1].homeWinPercentage * 100;
  });

  broadcasts = computed(() => {
    return this.summaryQuery().data?.broadcasts || [];
  });

  pickcenter = computed(() => {
    return this.summaryQuery().data?.pickcenter || [];
  });

  formattedDate = computed(() => {
    const dateString = this.summaryQuery().data?.header.competitions[0]?.date;
    if (!dateString) {
      return '';
    }

    const date = new Date(dateString);
    return date.toLocaleDateString('en-US', {
      weekday: 'long',
      year: 'numeric',
      month: 'long',
      day: 'numeric',
      hour: '2-digit',
      minute: '2-digit'
    });
  });

  keyStats = [
    'fieldGoalPct',
    'rebounds',
    'assists',
    'threePointFieldGoalPct',
    'freeThrowPct',
    'steals',
    'blocks',
    'turnovers'
  ];

  ngOnInit(): void {
    // Query will automatically start when component initializes
  }

  // Update helper methods to handle possibly undefined data
  getStatValue(teamIndex: number, stat: string): string {
    const team = teamIndex === 0 ? this.awayTeam() : this.homeTeam();
    if (!team) return '0';
    const statObj = team.statistics?.find(s => s.name === stat);
    return statObj ? statObj.displayValue : '0';
  }

  getStatLabel(stat: string): string {
    const team = this.homeTeam();
    if (!team) return stat;
    const statObj = team.statistics?.find(s => s.name === stat);
    return statObj ? statObj.label : stat;
  }

  getComparisonWidth(teamIndex: number, stat: string): string {
    const team1Value = this.getStatNumericValue(0, stat);
    const team2Value = this.getStatNumericValue(1, stat);

    if (team1Value === 0 && team2Value === 0) return '50%';

    const total = team1Value + team2Value;
    const percentage = (teamIndex === 0 ? team1Value : team2Value) / total * 100;

    return `${percentage}%`;
  }

  getStatNumericValue(teamIndex: number, stat: string): number {
    const displayValue = this.getStatValue(teamIndex, stat);
    // Remove percentage sign and convert to number
    return parseFloat(displayValue.replace('%', '')) || 0;
  }

  getTeamLeaders(teamIndex: number): any[] {
    const leaders = this.summaryQuery().data?.leaders;
    if (!leaders || leaders.length === 0) return [];

    const teamId = teamIndex === 0
      ? this.awayTeam()?.team?.id
      : this.homeTeam()?.team?.id;

    const teamLeaders = leaders.find(l => l.team?.id === teamId);
    return teamLeaders?.leaders || [];
  }
}