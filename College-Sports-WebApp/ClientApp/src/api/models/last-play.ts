/* tslint:disable */
/* eslint-disable */
import { AthletesInvolved } from '../models/athletes-involved';
import { LastPlayType } from '../models/last-play-type';
import { Probability } from '../models/probability';
export interface LastPlay {
  athletesInvolved?: Array<AthletesInvolved> | null;
  id?: number;
  probability?: Probability;
  scoreValue?: number;
  text?: string | null;
  type?: LastPlayType;
}
