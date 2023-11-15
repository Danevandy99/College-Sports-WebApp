/* tslint:disable */
/* eslint-disable */
import { ScoreboardScoreCellItemRecord } from '../models/scoreboard-score-cell-item-record';
export interface ScoreboardScoreCellItem {
  id?: number;
  isAway?: boolean;
  logoUrl?: string | null;
  record?: ScoreboardScoreCellItemRecord;
  teamName?: string | null;
}
