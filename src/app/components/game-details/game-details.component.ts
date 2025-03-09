import { Component, Input, OnInit, computed, inject, input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EspnApiService } from '../../services/espn-api.service';
import { EventSummary } from '../../models/event-summary';
import { computedAsync } from 'ngxtension/computed-async';
import { createPendingObserverResult } from '@ngneat/query';

@Component({
  selector: 'app-game-detail',
  standalone: true,
  imports: [CommonModule],
  template: `
    <!-- Show loading state -->
    <div *ngIf="summaryQuery().isLoading" class="flex items-center justify-center p-8">
      <div class="animate-spin rounded-full h-8 w-8 border-b-2 border-gray-900"></div>
    </div>

    <!-- Show error state -->
    <div *ngIf="summaryQuery().isError" class="p-4 bg-red-100 text-red-700 rounded">
      Error loading game details
    </div>

    <!-- Show game details when data is available -->
    <div *ngIf="summaryQuery().isSuccess" class="max-w-6xl mx-auto p-4 bg-gray-100 rounded-lg shadow-lg">
      <!-- Game Header with Teams and Score -->
      <div class="bg-white p-4 rounded-lg shadow mb-4">
        <div class="flex justify-between items-center">
          <!-- Away Team -->
          <div class="flex flex-col items-center w-1/3">
            <div *ngIf="awayTeam()?.team?.logo" class="h-24 w-24">
              <img [src]="awayTeam()?.team?.logo" [alt]="awayTeam()?.team?.displayName" class="w-full h-full object-contain">
            </div>
            <div class="text-center mt-2">
              <h2 class="font-bold text-2xl">{{ awayTeam()?.team?.displayName }}</h2>
              <p class="text-4xl font-bold">{{ awayScore() }}</p>
            </div>
          </div>
          
          <!-- Game Status -->
          <div class="text-center w-1/3">
            <div class="text-xl font-semibold">
              {{ gameStatus() }}
            </div>
            <div class="text-sm text-gray-600">{{ formattedDate() }}</div>
            <div *ngIf="gameNote()" class="mt-2 p-2 bg-blue-100 text-blue-800 rounded text-sm">
              {{ gameNote() }}
            </div>
          </div>
          
          <!-- Home Team -->
          <div class="flex flex-col items-center w-1/3">
            <div *ngIf="homeTeam()?.team?.logo" class="h-24 w-24">
              <img [src]="homeTeam()?.team?.logo" [alt]="homeTeam()?.team?.displayName" class="w-full h-full object-contain">
            </div>
            <div class="text-center mt-2">
              <h2 class="font-bold text-2xl">{{ homeTeam()?.team?.displayName }}</h2>
              <p class="text-4xl font-bold">{{ homeScore() }}</p>
            </div>
          </div>
        </div>
      </div>
      
      <!-- Venue Information -->
      <div *ngIf="venue()" class="bg-white p-4 rounded-lg shadow mb-4">
        <h3 class="font-bold text-lg mb-2">Venue</h3>
        <p>{{ venue()?.fullName }}, {{ venue()?.address?.state }}</p>
      </div>
      
      <!-- Team Statistics Comparison -->
      <div class="bg-white p-4 rounded-lg shadow mb-4">
        <h3 class="font-bold text-lg mb-4">Team Statistics</h3>
        
        <div *ngFor="let stat of keyStats" class="mb-2">
          <div class="flex justify-between mb-1">
            <span class="text-gray-700">{{ getStatValue(0, stat) }}</span>
            <span class="font-medium">{{ getStatLabel(stat) }}</span>
            <span class="text-gray-700">{{ getStatValue(1, stat) }}</span>
          </div>
          <div class="flex h-2 bg-gray-200 rounded overflow-hidden">
            <div class="bg-blue-500" [style.width]="getComparisonWidth(0, stat)"></div>
            <div class="bg-red-500" [style.width]="getComparisonWidth(1, stat)"></div>
          </div>
        </div>
      </div>
      
      <!-- Win Probability -->
      <div *ngIf="winProbability().length > 0" class="bg-white p-4 rounded-lg shadow mb-4">
        <h3 class="font-bold text-lg mb-2">Win Probability</h3>
        <div class="flex mb-2">
          <div class="h-4 bg-blue-500" [style.width]="currentWinPercent() + '%'"></div>
          <div class="h-4 bg-red-500" [style.width]="(100 - currentWinPercent()) + '%'"></div>
        </div>
        <div class="flex justify-between">
          <div>{{ awayTeam()?.team?.displayName }} {{ (100 - currentWinPercent()).toFixed(1) }}%</div>
          <div>{{ homeTeam()?.team?.displayName }} {{ currentWinPercent().toFixed(1) }}%</div>
        </div>
      </div>
      
      <!-- Key Players -->
      <div class="bg-white p-4 rounded-lg shadow mb-4">
        <h3 class="font-bold text-lg mb-2">Key Players</h3>
        <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
          <!-- Away Team Leaders -->
          <div class="border rounded p-3">
            <h4 class="font-bold mb-2">{{ awayTeam()?.team?.displayName }} Leaders</h4>
            <div *ngFor="let leader of getTeamLeaders(0)" class="mb-2">
              <div class="font-medium">{{ leader.displayName }}</div>
              <div *ngFor="let playerStat of leader.leaders" class="text-sm text-gray-600">
                {{ playerStat.athlete?.athlete?.displayName }}: {{ playerStat.displayValue }}
              </div>
            </div>
          </div>
          
          <!-- Home Team Leaders -->
          <div class="border rounded p-3">
            <h4 class="font-bold mb-2">{{ homeTeam()?.team?.displayName }} Leaders</h4>
            <div *ngFor="let leader of getTeamLeaders(1)" class="mb-2">
              <div class="font-medium">{{ leader.displayName }}</div>
              <div *ngFor="let playerStat of leader.leaders" class="text-sm text-gray-600">
                {{ playerStat.athlete?.athlete?.displayName }}: {{ playerStat.displayValue }}
              </div>
            </div>
          </div>
        </div>
      </div>
      
      <!-- Broadcasts -->
      <div *ngIf="broadcasts().length" class="bg-white p-4 rounded-lg shadow mb-4">
        <h3 class="font-bold text-lg mb-2">Broadcasts</h3>
        <div class="flex flex-wrap gap-2">
          <div *ngFor="let broadcast of broadcasts()" class="px-3 py-1 bg-gray-100 rounded">
            {{ broadcast.market }}
          </div>
        </div>
      </div>
      
      <!-- Game Notes & Context -->
      <div *ngIf="pickcenter().length" class="bg-white p-4 rounded-lg shadow">
        <h3 class="font-bold text-lg mb-2">Betting Information</h3>
        <div *ngFor="let pick of pickcenter()" class="mb-2">
          <div class="grid grid-cols-2 gap-2">
            <div>
              <span class="font-medium">Spread:</span> {{ pick.details }}
            </div>
            <div>
              <span class="font-medium">Over/Under:</span> {{ pick.overUnder }}
            </div>
          </div>
        </div>
      </div>
    </div>
  `
})
export class GameDetailComponent implements OnInit {
  private espnApiService = inject(EspnApiService);

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