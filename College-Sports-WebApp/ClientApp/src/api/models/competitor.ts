/* tslint:disable */
/* eslint-disable */
import { CuratedRank } from '../models/curated-rank';
import { Leader } from '../models/leader';
import { Linescore } from '../models/linescore';
import { Record } from '../models/record';
import { Statistic } from '../models/statistic';
import { Team } from '../models/team';
export interface Competitor {
  curatedRank?: CuratedRank;
  homeAway?: string | null;
  id?: number;
  leaders?: Array<Leader> | null;
  linescores?: Array<Linescore> | null;
  order?: number;
  records?: Array<Record> | null;
  score?: string | null;
  statistics?: Array<Statistic> | null;
  team?: Team;
  type?: string | null;
  uid?: string | null;
}
