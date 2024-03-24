/* tslint:disable */
/* eslint-disable */
import { LeagueSeasonType } from './league-season-type';
export interface LeagueSeason {
  displayName?: string | null;
  endDate?: string;
  id?: number;
  startDate?: string;
  type?: LeagueSeasonType;
  year?: number;
}
