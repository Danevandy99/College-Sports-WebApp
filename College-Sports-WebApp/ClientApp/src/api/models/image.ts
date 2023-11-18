/* tslint:disable */
/* eslint-disable */
import { Peer } from '../models/peer';
export interface Image {
  alt?: string | null;
  caption?: string | null;
  credit?: string | null;
  height?: number;
  id?: number;
  name?: string | null;
  peers?: Array<Peer> | null;
  url?: string | null;
  width?: number;
}
