/* tslint:disable */
/* eslint-disable */
import { Ad } from '../models/ad';
import { Category } from '../models/category';
import { DeviceRestrictions } from '../models/device-restrictions';
import { Image } from '../models/image';
import { PosterImages } from '../models/poster-images';
import { TimeRestrictions } from '../models/time-restrictions';
import { Tracking } from '../models/tracking';
export interface Video {
  ad?: Ad;
  caption?: string | null;
  categories?: Array<Category> | null;
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
