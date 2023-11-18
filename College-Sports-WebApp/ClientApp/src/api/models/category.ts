/* tslint:disable */
/* eslint-disable */
import { Athlete } from '../models/athlete';
import { League } from '../models/league';
import { Team } from '../models/team';
export interface Category {
  athlete?: Athlete;
  athleteId?: number;
  description?: string | null;
  id?: number;
  league?: League;
  leagueId?: number | null;
  sportId?: number;
  team?: Team;
  teamId?: number | null;
  type?: string | null;
  uid?: string | null;
}
