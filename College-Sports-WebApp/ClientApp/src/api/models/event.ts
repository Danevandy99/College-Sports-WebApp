/* tslint:disable */
/* eslint-disable */
import { Competition } from '../models/competition';
import { Link } from '../models/link';
import { Season } from '../models/season';
import { Status } from '../models/status';
import { Weather } from '../models/weather';
export interface Event {
  competitions?: Array<Competition> | null;
  date?: string | null;
  id?: number;
  links?: Array<Link> | null;
  name?: string | null;
  season?: Season;
  shortName?: string | null;
  status?: Status;
  uid?: string | null;
  weather?: Weather;
}
