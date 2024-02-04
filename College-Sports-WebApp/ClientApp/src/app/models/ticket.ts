/* tslint:disable */
/* eslint-disable */
import { Link } from './link';
export interface Ticket {
  id?: number;
  links?: Array<Link> | null;
  numberAvailable?: number;
  summary?: string | null;
}
