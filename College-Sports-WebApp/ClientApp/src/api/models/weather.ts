/* tslint:disable */
/* eslint-disable */
import { Link } from '../models/link';
export interface Weather {
  conditionId?: string | null;
  displayValue?: string | null;
  highTemperature?: number;
  link?: Link;
  temperature?: number;
}
