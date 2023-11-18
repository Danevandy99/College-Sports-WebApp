/* tslint:disable */
/* eslint-disable */
import { Athlete } from '../models/athlete';
import { Team } from '../models/team';
export interface Leader {
  abbreviation?: string | null;
  athlete?: Athlete;
  displayName?: string | null;
  displayValue?: string | null;
  id?: number;
  leaders?: Array<Leader> | null;
  name?: string | null;
  shortDisplayName?: string | null;
  team?: Team;
  value?: number;
}
