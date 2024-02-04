/* tslint:disable */
/* eslint-disable */
import { Competition } from './competition';
import { Link } from './link';
import { Season } from './season';
import { Status } from './status';
import { Weather } from './weather';
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
