/* tslint:disable */
/* eslint-disable */
import { AthletesInvolved } from './athletes-involved';
import { LastPlayType } from './last-play-type';
import { Probability } from './probability';
export interface LastPlay {
  athletesInvolved?: Array<AthletesInvolved> | null;
  id?: number;
  probability?: Probability;
  scoreValue?: number;
  text?: string | null;
  type?: LastPlayType;
}
