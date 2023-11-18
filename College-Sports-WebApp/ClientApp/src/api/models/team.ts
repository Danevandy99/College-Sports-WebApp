/* tslint:disable */
/* eslint-disable */
import { Venue } from '../models/venue';
export interface Team {
  abbreviation?: string | null;
  alternateColor?: string | null;
  color?: string | null;
  conferenceId?: string | null;
  description?: string | null;
  displayName?: string | null;
  id?: number;
  isActive?: boolean;
  location?: string | null;
  logo?: string | null;
  name?: string | null;
  shortDisplayName?: string | null;
  uid?: string | null;
  venue?: Venue;
}
