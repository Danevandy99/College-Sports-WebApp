/* tslint:disable */
/* eslint-disable */
import { Event } from '../models/event';
import { EventsDate } from '../models/events-date';
import { League } from '../models/league';
import { Video } from '../models/video';
export interface ScoreboardResult {
  events?: Array<Event> | null;
  eventsDate?: EventsDate;
  groups?: Array<string> | null;
  id?: number;
  leagues?: Array<League> | null;
  videos?: Array<Video> | null;
}
