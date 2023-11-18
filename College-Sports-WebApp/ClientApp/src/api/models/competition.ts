/* tslint:disable */
/* eslint-disable */
import { Airing } from '../models/airing';
import { Broadcast } from '../models/broadcast';
import { Competitor } from '../models/competitor';
import { Format } from '../models/format';
import { GeoBroadcast } from '../models/geo-broadcast';
import { Note } from '../models/note';
import { Odd } from '../models/odd';
import { Situation } from '../models/situation';
import { Status } from '../models/status';
import { Ticket } from '../models/ticket';
import { Type } from '../models/type';
import { Venue } from '../models/venue';
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
}
