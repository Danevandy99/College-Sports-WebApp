/* tslint:disable */
/* eslint-disable */
import { LeagueSeason } from '../models/league-season';
import { Logo } from '../models/logo';
export interface League {
  abbreviation?: string | null;
  calendar?: Array<string> | null;
  calendarEndDate?: string | null;
  calendarIsWhitelist?: boolean;
  calendarStartDate?: string | null;
  calendarType?: string | null;
  href?: string | null;
  id?: number;
  logos?: Array<Logo> | null;
  midsizeName?: string | null;
  name?: string | null;
  season?: LeagueSeason;
  slug?: string | null;
  uid?: string | null;
}
