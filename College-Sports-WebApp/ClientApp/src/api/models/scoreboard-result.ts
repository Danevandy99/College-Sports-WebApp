/* tslint:disable */
/* eslint-disable */
import { ScoreboardItem } from '../models/scoreboard-item';
export interface ScoreboardResult {
  fetchDateTime?: string;
  filterDate?: string;
  id?: number;
  scoreboardItems?: Array<ScoreboardItem> | null;
}
