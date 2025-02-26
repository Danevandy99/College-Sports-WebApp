import { Component, Input, OnInit, computed, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

interface Player {
  id: string;
  fullName: string;
  displayName: string;
  shortName: string;
  headshot: string;
  jersey: string;
  position: { abbreviation: string };
}

interface TeamStatistic {
  name: string;
  abbreviation: string;
  displayValue: string;
}

interface TeamLeader {
  name: string;
  displayName: string;
  shortDisplayName: string;
  abbreviation: string;
  leaders: {
    displayValue: string;
    value: number;
    athlete: Player;
  }[];
}

interface Team {
  id: string;
  location: string;
  name: string;
  abbreviation: string;
  displayName: string;
  shortDisplayName: string;
  color: string;
  logo: string;
}

interface Competitor {
  id: string;
  homeAway: string;
  winner: boolean;
  team: Team;
  score: string;
  linescores: { value: number }[];
  statistics: TeamStatistic[];
  leaders: TeamLeader[];
  curatedRank: { current: number };
  records: { name: string; type: string; summary: string }[];
}

interface GameData {
  id: string;
  date: string;
  name: string;
  competitions: {
    id: string;
    date: string;
    venue: { fullName: string; address: { city: string; state: string } };
    competitors: Competitor[];
    status: {
      clock: number;
      displayClock: string;
      period: number;
      type: {
        id: string;
        state: string;
        completed: boolean;
        description: string;
        detail: string;
        shortDetail: string;
      };
    };
    broadcasts: { market: string; names: string[] }[];
  }[];
}

@Component({
  selector: 'app-game-detail',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="max-w-6xl mx-auto p-4 bg-gray-100 rounded-lg shadow-lg">
      <!-- Game Header -->
      <div class="bg-white rounded-lg shadow p-4 mb-6">
        <div class="flex justify-between items-center">
          <div class="text-xs text-gray-500">
            {{ formattedDate() }}
          </div>
          <div class="bg-red-600 text-white text-xs px-2 py-1 rounded" *ngIf="isUpset()">
            UPSET
          </div>
        </div>
        
        <div class="flex justify-between items-center mt-2">
          <h1 class="text-xl font-bold">{{ gameData().name }}</h1>
          <div class="text-sm text-gray-700">
            {{ gameData().competitions[0].status.type.shortDetail }}
          </div>
        </div>
        
        <div class="text-sm text-gray-600 mt-1">
          {{ gameData().competitions[0].venue.fullName }} ({{ gameData().competitions[0].venue.address.city }}, {{ gameData().competitions[0].venue.address.state }})
        </div>
      </div>
      
      <!-- Score Section -->
      <div class="bg-white rounded-lg shadow overflow-hidden mb-6">
        <div class="grid grid-cols-9 bg-gray-800 text-white text-sm font-medium">
          <div class="col-span-3 p-2">Team</div>
          <div class="p-2 text-center">1</div>
          <div class="p-2 text-center">2</div>
          <div class="p-2 text-center">T</div>
          <div class="p-2 text-center">Rank</div>
          <div class="col-span-2 p-2 text-center">Record</div>
        </div>
        
        <ng-container *ngFor="let competitor of competitors(); let i = index">
          <div [class]="'grid grid-cols-9 border-b text-sm ' + (competitor.winner ? 'bg-green-50' : '')">
            <div class="col-span-3 p-3 flex items-center">
              <div class="w-8 h-8 mr-3">
                <img [src]="competitor.team.logo" [alt]="competitor.team.displayName" class="w-full h-full object-contain">
              </div>
              <div>
                <div class="font-bold flex items-center">
                  <span>{{ competitor.team.shortDisplayName }}</span>
                  <span *ngIf="competitor.curatedRank.current < 99" class="ml-2 text-xs bg-gray-200 px-1 rounded">#{{ competitor.curatedRank.current }}</span>
                </div>
                <div class="text-xs text-gray-500">{{ competitor.team.name }}</div>
              </div>
            </div>
            <div class="p-3 font-bold text-center">{{ competitor.linescores[0].value }}</div>
            <div class="p-3 font-bold text-center">{{ competitor.linescores[1].value }}</div>
            <div class="p-3 font-bold text-center text-lg">{{ competitor.score }}</div>
            <div class="p-3 text-center">{{ competitor.curatedRank.current < 99 ? competitor.curatedRank.current : '-' }}</div>
            <div class="col-span-2 p-3 text-center">{{ getOverallRecord(competitor) }}</div>
          </div>
        </ng-container>
      </div>
      
      <!-- Team Stats Comparison -->
      <div class="bg-white rounded-lg shadow p-4 mb-6">
        <h2 class="text-lg font-bold mb-4">Team Stats</h2>
        
        <div class="grid grid-cols-3 gap-4">
          <div *ngFor="let stat of keyStats()" class="relative">
            <div class="text-sm font-medium text-center mb-1">{{ getStatName(stat) }}</div>
            <div class="h-6 bg-gray-200 rounded-full overflow-hidden">
              <div class="relative w-full h-full">
                <div 
                  [style.width.%]="getStatPercentage(0, stat)"
                  [style.background-color]="'#' + awayTeam().team.color || '#cccccc'"
                  class="absolute h-full left-0 top-0">
                </div>
                <div 
                  [style.width.%]="getStatPercentage(1, stat)"
                  [style.background-color]="'#' + homeTeam().team.color || '#000000'"
                  class="absolute h-full right-0 top-0">
                </div>
              </div>
            </div>
            <div class="flex justify-between text-xs mt-1">
              <div>{{ getStatValue(0, stat) }}</div>
              <div>{{ getStatValue(1, stat) }}</div>
            </div>
          </div>
        </div>
      </div>
      
      <!-- Team Leaders -->
      <div class="grid grid-cols-1 md:grid-cols-2 gap-6 mb-6">
        <div class="bg-white rounded-lg shadow p-4">
          <h2 class="text-lg font-bold mb-4">{{ awayTeam().team.shortDisplayName }} Leaders</h2>
          <div class="space-y-4">
            <div *ngFor="let category of ['points', 'rebounds', 'assists']" class="border-b pb-2 last:border-0">
              <div class="text-sm font-medium text-gray-500 mb-1">{{ getLeaderCategory(category) }}</div>
              <div class="flex items-center">
                <div class="w-10 h-10 mr-3">
                  <img 
                    [src]="getLeaderPhoto(awayTeam(), category)" 
                    [alt]="getLeaderName(awayTeam(), category)"
                    class="w-full h-full object-cover rounded-full">
                </div>
                <div>
                  <div class="font-bold">{{ getLeaderName(awayTeam(), category) }}</div>
                  <div class="text-sm">{{ getLeaderValue(awayTeam(), category) }}</div>
                </div>
              </div>
            </div>
          </div>
        </div>
        
        <div class="bg-white rounded-lg shadow p-4">
          <h2 class="text-lg font-bold mb-4">{{ homeTeam().team.shortDisplayName }} Leaders</h2>
          <div class="space-y-4">
            <div *ngFor="let category of ['points', 'rebounds', 'assists']" class="border-b pb-2 last:border-0">
              <div class="text-sm font-medium text-gray-500 mb-1">{{ getLeaderCategory(category) }}</div>
              <div class="flex items-center">
                <div class="w-10 h-10 mr-3">
                  <img 
                    [src]="getLeaderPhoto(homeTeam(), category)" 
                    [alt]="getLeaderName(homeTeam(), category)"
                    class="w-full h-full object-cover rounded-full">
                </div>
                <div>
                  <div class="font-bold">{{ getLeaderName(homeTeam(), category) }}</div>
                  <div class="text-sm">{{ getLeaderValue(homeTeam(), category) }}</div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      
      <!-- Game Summary -->
      <div class="bg-white rounded-lg shadow p-4">
        <h2 class="text-lg font-bold mb-4">Game Summary</h2>
        <p class="text-gray-700">
          {{ getGameSummary() }}
        </p>
      </div>
    </div>
  `,
  styles: []
})
export class GameDetailComponent implements OnInit {
  @Input() gameId: string = '';
  
  private _gameData = signal<GameData | null>(null);
  
  gameData = computed(() => this._gameData() as GameData);
  
  formattedDate = computed(() => {
    if (!this.gameData()) return '';
    const date = new Date(this.gameData().competitions[0].date);
    return date.toLocaleDateString('en-US', { 
      weekday: 'long', 
      year: 'numeric', 
      month: 'long', 
      day: 'numeric',
      hour: '2-digit',
      minute: '2-digit'
    });
  });
  
  competitors = computed(() => {
    if (!this.gameData()) return [];
    return this.gameData().competitions[0].competitors;
  });
  
  homeTeam = computed(() => {
    return this.competitors().find(c => c.homeAway === 'home') as Competitor;
  });
  
  awayTeam = computed(() => {
    return this.competitors().find(c => c.homeAway === 'away') as Competitor;
  });
  
  keyStats = computed(() => {
    return ['fieldGoalPct', 'rebounds', 'assists', 'threePointFieldGoalPct', 'freeThrowPct'];
  });
  
  isUpset = computed(() => {
    if (!this.gameData()) return false;
    
    const homeRank = this.homeTeam().curatedRank.current;
    const awayRank = this.awayTeam().curatedRank.current;
    
    // If lower ranked team (higher number) beats higher ranked team
    return (
      (homeRank > awayRank && this.homeTeam().winner) || 
      (awayRank > homeRank && this.awayTeam().winner)
    ) && (homeRank < 99 || awayRank < 99); // At least one team is ranked
  });
  
  constructor() {}
  
  ngOnInit(): void {
    // In a real app, you would fetch the data based on the gameId
    // For now, we'll use the sample data passed in
    this.fetchGameData();
  }
  
  fetchGameData(): void {
    // This would be a service call in a real app
    const sampleData: GameData = {
      "id": "401725760",
      "date": "2025-02-26T01:00Z",
      "name": "Iowa State Cyclones at Oklahoma State Cowboys",
      "competitions": [
        {
          "id": "401725760",
          "date": "2025-02-26T01:00Z",
          "venue": {
            "fullName": "Gallagher-Iba Arena",
            "address": {
              "city": "Stillwater",
              "state": "OK"
            }
          },
          "competitors": [
            {
              "id": "197",
              "homeAway": "home",
              "winner": true,
              "team": {
                "id": "197",
                "location": "Oklahoma State",
                "name": "Cowboys",
                "abbreviation": "OKST",
                "displayName": "Oklahoma State Cowboys",
                "shortDisplayName": "Oklahoma St",
                "color": "000000",
                "logo": "https://a.espncdn.com/i/teamlogos/ncaa/500/197.png"
              },
              "score": "74",
              "linescores": [
                { "value": 40.0 },
                { "value": 34.0 }
              ],
              "statistics": [
                { "name": "rebounds", "abbreviation": "REB", "displayValue": "34" },
                { "name": "assists", "abbreviation": "AST", "displayValue": "18" },
                { "name": "fieldGoalPct", "abbreviation": "FG%", "displayValue": "42.4" },
                { "name": "freeThrowPct", "abbreviation": "FT%", "displayValue": "81.8" },
                { "name": "threePointFieldGoalPct", "abbreviation": "3P%", "displayValue": "26.1" }
              ],
              "leaders": [
                {
                  "name": "points",
                  "displayName": "Points",
                  "shortDisplayName": "Pts",
                  "abbreviation": "Pts",
                  "leaders": [
                    {
                      "displayValue": "25",
                      "value": 25.0,
                      "athlete": {
                        "id": "4702773",
                        "fullName": "Abou Ousmane",
                        "displayName": "Abou Ousmane",
                        "shortName": "A. Ousmane",
                        "headshot": "https://a.espncdn.com/i/headshots/mens-college-basketball/players/full/4702773.png",
                        "jersey": "33",
                        "position": {
                          "abbreviation": "F"
                        }
                      }
                    }
                  ]
                },
                {
                  "name": "rebounds",
                  "displayName": "Rebounds",
                  "shortDisplayName": "Reb",
                  "abbreviation": "Reb",
                  "leaders": [
                    {
                      "displayValue": "7",
                      "value": 7.0,
                      "athlete": {
                        "id": "5106286",
                        "fullName": "Robert Jennings II",
                        "displayName": "Robert Jennings II",
                        "shortName": "R. Jennings II",
                        "headshot": "https://a.espncdn.com/i/headshots/mens-college-basketball/players/full/5106286.png",
                        "jersey": "25",
                        "position": {
                          "abbreviation": "F"
                        }
                      }
                    }
                  ]
                },
                {
                  "name": "assists",
                  "displayName": "Assists",
                  "shortDisplayName": "Ast",
                  "abbreviation": "Ast",
                  "leaders": [
                    {
                      "displayValue": "4",
                      "value": 4.0,
                      "athlete": {
                        "id": "5106868",
                        "fullName": "Arturo Dean",
                        "displayName": "Arturo Dean",
                        "shortName": "A. Dean",
                        "headshot": "https://a.espncdn.com/i/headshots/mens-college-basketball/players/full/5106868.png",
                        "jersey": "2",
                        "position": {
                          "abbreviation": "G"
                        }
                      }
                    }
                  ]
                }
              ],
              "curatedRank": {
                "current": 99
              },
              "records": [
                {
                  "name": "overall",
                  "type": "total",
                  "summary": "14-14"
                }
              ]
            },
            {
              "id": "66",
              "homeAway": "away",
              "winner": false,
              "team": {
                "id": "66",
                "location": "Iowa State",
                "name": "Cyclones",
                "abbreviation": "ISU",
                "displayName": "Iowa State Cyclones",
                "shortDisplayName": "Iowa State",
                "color": "822433",
                "logo": "https://a.espncdn.com/i/teamlogos/ncaa/500/66.png"
              },
              "score": "68",
              "linescores": [
                { "value": 26.0 },
                { "value": 42.0 }
              ],
              "statistics": [
                { "name": "rebounds", "abbreviation": "REB", "displayValue": "38" },
                { "name": "assists", "abbreviation": "AST", "displayValue": "15" },
                { "name": "fieldGoalPct", "abbreviation": "FG%", "displayValue": "41.4" },
                { "name": "freeThrowPct", "abbreviation": "FT%", "displayValue": "60.0" },
                { "name": "threePointFieldGoalPct", "abbreviation": "3P%", "displayValue": "29.6" }
              ],
              "leaders": [
                {
                  "name": "points",
                  "displayName": "Points",
                  "shortDisplayName": "Pts",
                  "abbreviation": "Pts",
                  "leaders": [
                    {
                      "displayValue": "17",
                      "value": 17.0,
                      "athlete": {
                        "id": "4870564",
                        "fullName": "Joshua Jefferson",
                        "displayName": "Joshua Jefferson",
                        "shortName": "J. Jefferson",
                        "headshot": "https://a.espncdn.com/i/headshots/mens-college-basketball/players/full/4870564.png",
                        "jersey": "2",
                        "position": {
                          "abbreviation": "F"
                        }
                      }
                    }
                  ]
                },
                {
                  "name": "rebounds",
                  "displayName": "Rebounds",
                  "shortDisplayName": "Reb",
                  "abbreviation": "Reb",
                  "leaders": [
                    {
                      "displayValue": "8",
                      "value": 8.0,
                      "athlete": {
                        "id": "4870564",
                        "fullName": "Joshua Jefferson",
                        "displayName": "Joshua Jefferson",
                        "shortName": "J. Jefferson",
                        "headshot": "https://a.espncdn.com/i/headshots/mens-college-basketball/players/full/4870564.png",
                        "jersey": "2",
                        "position": {
                          "abbreviation": "F"
                        }
                      }
                    }
                  ]
                },
                {
                  "name": "assists",
                  "displayName": "Assists",
                  "shortDisplayName": "Ast",
                  "abbreviation": "Ast",
                  "leaders": [
                    {
                      "displayValue": "5",
                      "value": 5.0,
                      "athlete": {
                        "id": "4870564",
                        "fullName": "Joshua Jefferson",
                        "displayName": "Joshua Jefferson",
                        "shortName": "J. Jefferson",
                        "headshot": "https://a.espncdn.com/i/headshots/mens-college-basketball/players/full/4870564.png",
                        "jersey": "2",
                        "position": {
                          "abbreviation": "F"
                        }
                      }
                    }
                  ]
                }
              ],
              "curatedRank": {
                "current": 9
              },
              "records": [
                {
                  "name": "overall",
                  "type": "total",
                  "summary": "21-7"
                }
              ]
            }
          ],
          "status": {
            "clock": 2.0,
            "displayClock": "0:02",
            "period": 2,
            "type": {
              "id": "3",
              "state": "post",
              "completed": true,
              "description": "Final",
              "detail": "Final",
              "shortDetail": "Final"
            }
          },
          "broadcasts": [
            {
              "market": "national",
              "names": [
                "ESPN+"
              ]
            }
          ]
        }
      ]
    };
    
    this._gameData.set(sampleData);
  }
  
  getOverallRecord(competitor: Competitor): string {
    const record = competitor.records.find(r => r.name === 'overall');
    return record ? record.summary : '';
  }
  
  getStatName(stat: string): string {
    switch(stat) {
      case 'fieldGoalPct': return 'FG%';
      case 'threePointFieldGoalPct': return '3PT%';
      case 'freeThrowPct': return 'FT%';
      case 'rebounds': return 'Rebounds';
      case 'assists': return 'Assists';
      default: return stat;
    }
  }
  
  getStatValue(teamIndex: number, stat: string): string {
    const team = teamIndex === 0 ? this.awayTeam() : this.homeTeam();
    const statObj = team.statistics.find(s => s.name === stat);
    return statObj ? statObj.displayValue : '0';
  }
  
  getStatPercentage(teamIndex: number, stat: string): number {
    if (stat === 'fieldGoalPct' || stat === 'threePointFieldGoalPct' || stat === 'freeThrowPct') {
      // For percentages, we can use the value directly
      return parseFloat(this.getStatValue(teamIndex, stat));
    } else {
      // For counting stats like rebounds or assists, calculate as percentage of total
      const awayValue = parseFloat(this.getStatValue(0, stat));
      const homeValue = parseFloat(this.getStatValue(1, stat));
      const total = awayValue + homeValue;
      
      if (total === 0) return 50; // Equal split if no stats
      
      return teamIndex === 0 ? (awayValue / total * 100) : (homeValue / total * 100);
    }
  }
  
  getLeaderCategory(category: string): string {
    switch(category) {
      case 'points': return 'Points';
      case 'rebounds': return 'Rebounds';
      case 'assists': return 'Assists';
      default: return category;
    }
  }
  
  getLeaderName(team: Competitor, category: string): string {
    const leader = team.leaders.find(l => l.name === category);
    if (!leader || leader.leaders.length === 0) return 'N/A';
    return leader.leaders[0].athlete.shortName;
  }
  
  getLeaderValue(team: Competitor, category: string): string {
    const leader = team.leaders.find(l => l.name === category);
    if (!leader || leader.leaders.length === 0) return 'N/A';
    return leader.leaders[0].displayValue + ' ' + leader.shortDisplayName;
  }
  
  getLeaderPhoto(team: Competitor, category: string): string {
    const leader = team.leaders.find(l => l.name === category);
    if (!leader || leader.leaders.length === 0) return '';
    return leader.leaders[0].athlete.headshot || '';
  }
  
  getGameSummary(): string {
    if (!this.gameData()) return '';
    
    const home = this.homeTeam();
    const away = this.awayTeam();
    const homeRank = home.curatedRank.current < 99 ? `#${home.curatedRank.current} ` : '';
    const awayRank = away.curatedRank.current < 99 ? `#${away.curatedRank.current} ` : '';
    
    let summary = '';
    if (home.winner) {
      summary = `${homeRank}${home.team.displayName} defeated ${awayRank}${away.team.displayName} ${home.score}-${away.score} at ${this.gameData().competitions[0].venue.fullName}.`;
      
      if (this.isUpset()) {
        summary += ` In a surprising upset, `;
      } else {
        summary += ` `;
      }
      
      summary += `${home.team.shortDisplayName} was led by ${this.getLeaderName(home, 'points')} with ${this.getLeaderValue(home, 'points')}.`;
    } else {
      summary = `${awayRank}${away.team.displayName} defeated ${homeRank}${home.team.displayName} ${away.score}-${home.score} at ${this.gameData().competitions[0].venue.fullName}.`;
      
      if (this.isUpset()) {
        summary += ` In a surprising upset, `;
      } else {
        summary += ` `;
      }
      
      summary += `${away.team.shortDisplayName} was led by ${this.getLeaderName(away, 'points')} with ${this.getLeaderValue(away, 'points')}.`;
    }
    
    return summary;
  }
}