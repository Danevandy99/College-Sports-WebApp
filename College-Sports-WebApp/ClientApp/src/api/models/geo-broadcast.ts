/* tslint:disable */
/* eslint-disable */
import { Market } from '../models/market';
import { Media } from '../models/media';
import { Type } from '../models/type';
export interface GeoBroadcast {
  id?: number;
  lang?: string | null;
  market?: Market;
  media?: Media;
  region?: string | null;
  type?: Type;
}
