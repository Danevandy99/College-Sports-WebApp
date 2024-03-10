/* tslint:disable */
/* eslint-disable */
import { GroupByOptionsWithElement } from 'rxjs';
import { Airing } from './airing';
import { Broadcast } from './broadcast';
import { Competitor } from './competitor';
import { Format } from './format';
import { GeoBroadcast } from './geo-broadcast';
import { Note } from './note';
import { Odd } from './odd';
import { Situation } from './situation';
import { Status } from './status';
import { Ticket } from './ticket';
import { Type } from './type';
import { Venue } from './venue';
export interface Competition {
  airings?: Array<Airing> | null;
  attendance?: number;
  broadcasts?: Array<Broadcast> | null;
  competitors?: Array<Competitor> | null;
  conferenceCompetition?: boolean;
  date?: string | null;
  format?: Format;
  geoBroadcasts?: Array<GeoBroadcast> | null;
  id?: number;
  neutralSite?: boolean;
  notes?: Array<Note> | null;
  odds?: Array<Odd> | null;
  playByPlayAvailable?: boolean;
  recent?: boolean;
  situation?: Situation;
  startDate?: string | null;
  status?: Status;
  tickets?: Array<Ticket> | null;
  timeValid?: boolean;
  tournamentId?: number | null;
  type?: Type;
  uid?: string | null;
  venue?: Venue;
  groups: { id: string, name: string, shortName: string }[];
}
