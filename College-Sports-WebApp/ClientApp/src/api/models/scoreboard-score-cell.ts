/* tslint:disable */
/* eslint-disable */
import { ScoreboardScoreCellItem } from '../models/scoreboard-score-cell-item';
export interface ScoreboardScoreCell {
  competitors?: Array<ScoreboardScoreCellItem> | null;
  id?: number;
  time?: string;
}
