/* tslint:disable */
/* eslint-disable */
import { CuratedRank } from './curated-rank';
import { Linescore } from './linescore';
import { Record } from './record';
import { Statistic } from './statistic';
import { Team } from './team';
export interface Competitor {
  curatedRank?: CuratedRank;
  homeAway?: string | null;
  id?: number;
  linescores?: Array<Linescore> | null;
  order?: number;
  records?: Array<Record> | null;
  score?: string | null;
  statistics?: Array<Statistic> | null;
  team?: Team;
  type?: string | null;
  uid?: string | null;
}
