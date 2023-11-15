/* tslint:disable */
/* eslint-disable */
import { ScoreboardCallouts } from '../models/scoreboard-callouts';
import { ScoreboardEventInfo } from '../models/scoreboard-event-info';
import { ScoreboardScoreCell } from '../models/scoreboard-score-cell';
export interface ScoreboardItem {
  callouts?: ScoreboardCallouts;
  eventInfo?: ScoreboardEventInfo;
  id?: number;
  scoreCell?: ScoreboardScoreCell;
}
