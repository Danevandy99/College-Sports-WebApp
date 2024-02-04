/* tslint:disable */
/* eslint-disable */
import { Event } from './event';
import { EventsDate } from './events-date';
import { League } from './league';
import { Video } from './video';
export interface ScoreboardResult {
  events?: Array<Event> | null;
  eventsDate?: EventsDate;
  groups?: Array<string> | null;
  id?: number;
  leagues?: Array<League> | null;
  videos?: Array<Video> | null;
}
