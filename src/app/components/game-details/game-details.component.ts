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
  templateUrl: './game-details.component.html'
})
export class GameDetailComponent {
  private espnApiService = inject(EspnApiService);
  protected darkModeService = inject(DarkModeService);

  protected eventId = input.required<number>();

  protected summaryQuery = computedAsync(() => this.espnApiService.getSummary(this.eventId()).result$, {
    initialValue: createPendingObserverResult<EventSummary>(),
  });

  // Computed properties now based on summaryQuery
  competitors = computed(() => {
    if (!this.summaryQuery().data?.boxscore.teams) return [];
    console.log(this.summaryQuery().data);
    return this.summaryQuery().data?.header.competitions[0].competitors ?? [];
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
    console.log(this.awayTeam());
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