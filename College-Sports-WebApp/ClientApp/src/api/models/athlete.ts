/* tslint:disable */
/* eslint-disable */
import { Position } from '../models/position';
import { Team } from '../models/team';
export interface Athlete {
  active?: boolean;
  description?: string | null;
  displayName?: string | null;
  fullName?: string | null;
  headshot?: string | null;
  id?: number;
  jersey?: string | null;
  position?: Position;
  shortName?: string | null;
  team?: Team;
}
