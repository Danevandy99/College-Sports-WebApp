/* tslint:disable */
/* eslint-disable */
import { Ad } from './ad';
import { DeviceRestrictions } from './device-restrictions';
import { Image } from './image';
import { PosterImages } from './poster-images';
import { TimeRestrictions } from './time-restrictions';
import { Tracking } from './tracking';
export interface Video {
  ad?: Ad;
  caption?: string | null;
  cerebroId?: string | null;
  contributingPartner?: string | null;
  contributingSystem?: string | null;
  dataSourceIdentifier?: string | null;
  description?: string | null;
  deviceRestrictions?: DeviceRestrictions;
  duration?: number;
  headline?: string | null;
  id?: number;
  images?: Array<Image> | null;
  keywords?: Array<string> | null;
  lastModified?: string;
  originalPublishDate?: string;
  posterImages?: PosterImages;
  premium?: boolean;
  source?: string | null;
  syndicatable?: boolean;
  thumbnail?: string | null;
  timeRestrictions?: TimeRestrictions;
  title?: string | null;
  tracking?: Tracking;
}
