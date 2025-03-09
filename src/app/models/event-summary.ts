import { Broadcast } from "./broadcast";
import { Competition } from "./competition";
import { Record } from "./record";
import { Team } from "./team";

export interface EventSummary {
    boxscore: BoxScore;
    format: GameFormat;
    gameInfo: GameInfo;
    leaders: TeamLeaders[];
    broadcasts: Broadcast[];
    pickcenter: PickCenter[];
    againstTheSpread: TeamSpread[];
    news: NewsSection;
    header: GameHeader;
    winprobability: WinProbability[];
  }
  
  export interface BoxScore {
    teams: BoxScoreTeam[];
    players: BoxScorePlayers[];
  }
  
  export interface BoxScoreTeam {
    team: Team;
    statistics: Statistic[];
    displayOrder: number;
    homeAway: 'home' | 'away';
  }
  
  export interface Statistic {
    name: string;
    displayValue: string;
    label: string;
    abbreviation?: string;
  }
  
  export interface BoxScorePlayers {
    team: Team;
    statistics: PlayerStatistics[];
  }
  
  export interface PlayerStatistics {
    names: string[];
    keys: string[];
    labels: string[];
    descriptions: string[];
    athletes: Athlete[];
    totals: string[];
  }
  
  export interface Athlete {
    active: boolean;
    athlete: {
      id: string;
      uid: string;
      guid: string;
      displayName: string;
      shortName: string;
      jersey: string;
      position: Position;
      headshot: Image;
    };
    starter: boolean;
    didNotPlay: boolean;
    ejected: boolean;
    stats: string[];
  }
  
  export interface GameFormat {
    regulation: {
      periods: number;
      displayName: string;
      slug: string;
      clock: number;
    };
    overtime: {
      clock: number;
    };
  }
  
  export interface GameInfo {
    venue: Venue;
    officials: Official[];
  }
  
  export interface TeamLeaders {
    team: Team;
    leaders: Leader[];
  }
  
  export interface Leader {
    name: string;
    displayName: string;
    leaders: LeaderStats[];
  }
  
  export interface LeaderStats {
    displayValue: string;
    athlete: Athlete;
    statistics: Statistic[];
  }
  
  // Additional shared interfaces
  
  export interface Position {
    name: string;
    displayName: string;
    abbreviation: string;
  }
  
  export interface Image {
    href: string;
    alt: string;
  }
  
  export interface Venue {
    id: string;
    fullName: string;
    address: {
      city: string;
      state: string;
    };
    capacity?: number;
    grass: boolean;
    images: Image[];
  }
  
  export interface Official {
    fullName: string;
    displayName: string;
    position: Position;
    order: number;
  }

  export interface PickCenter {
    provider: Provider;
    details: string;
    overUnder: number;
    spread: number;
    overOdds: number;
    underOdds: number;
    awayTeamOdds: TeamOdds;
    homeTeamOdds: TeamOdds;
    links: Link[];
    moneyline: any; // Add specific type if needed
    pointSpread: any; // Add specific type if needed
    total: any; // Add specific type if needed
    link: Link;
  }
  
  export interface TeamSpread {
    team: Team;
    records: Record[];
  }
  
  export interface NewsSection {
    header: string;
    link: Link;
    articles: Article[];
  }
  
  export interface GameHeader {
    id: string;
    uid: string;
    season: {
      year: number;
      type: number;
    };
    timeValid: boolean;
    competitions: Competition[];
    links: Link[];
    week: number;
    league: League;
    gameNote: string;
  }
  
  export interface WinProbability {
    homeWinPercentage: number;
    tiePercentage: number;
    playId: string;
  }
  
  // Supporting interfaces
  export interface Provider {
    // Add provider properties
  }
  
  export interface TeamOdds {
    favoriteAtOpen: boolean;
  }
  
  export interface Link {
    language?: string;
    rel?: string[];
    href?: string;
    text?: string;
    shortText?: string;
    isExternal?: boolean;
    isPremium: boolean;
  }
  
  export interface Article {
    byline?: string;
    // Add other article properties
  }
  
  export interface League {
    id: string;
    uid: string;
    name: string;
    abbreviation: string;
    midsizeName: string;
    slug: string;
    isTournament: boolean;
    links: Link[];
  }