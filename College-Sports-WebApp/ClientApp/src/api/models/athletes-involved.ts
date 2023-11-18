/* tslint:disable */
/* eslint-disable */
import { Link } from '../models/link';
import { Team } from '../models/team';
export interface AthletesInvolved {
  displayName?: string | null;
  fullName?: string | null;
  headshot?: string | null;
  id?: number;
  jersey?: string | null;
  links?: Array<Link> | null;
  position?: string | null;
  shortName?: string | null;
  team?: Team;
}
