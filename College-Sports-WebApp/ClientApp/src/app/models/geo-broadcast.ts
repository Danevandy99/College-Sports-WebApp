/* tslint:disable */
/* eslint-disable */
import { Market } from './market';
import { Media } from './media';
import { Type } from './type';
export interface GeoBroadcast {
  id?: number;
  lang?: string | null;
  market?: Market;
  media?: Media;
  region?: string | null;
  type?: Type;
}
