/* tslint:disable */
/* eslint-disable */
import { AthletesInvolved } from '../models/athletes-involved';
import { Probability } from '../models/probability';
import { Team } from '../models/team';
import { Type } from '../models/type';
export interface LastPlay {
  athletesInvolved?: Array<AthletesInvolved> | null;
  id?: number;
  probability?: Probability;
  scoreValue?: number;
  team?: Team;
  text?: string | null;
  type?: Type;
}
