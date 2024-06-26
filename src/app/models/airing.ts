/* tslint:disable */
/* eslint-disable */
import { Image } from './image';
import { Policy } from './policy';
import { ProductLinks } from './product-links';
import { ProgramCategory } from './program-category';
import { Properties } from './properties';
export interface Airing {
  appAiringLink?: string | null;
  appGameLink?: string | null;
  artworkUrl?: string | null;
  createdBy?: string | null;
  createdOn?: string;
  end?: string;
  externalId?: string | null;
  id?: string | null;
  images?: Array<Image> | null;
  lastModifiedBy?: string | null;
  lastModifiedOn?: string;
  network?: string | null;
  networkId?: string | null;
  network_displayName?: string | null;
  network_shortName?: string | null;
  playableUrl?: string | null;
  policy?: Policy;
  policyUrl?: string | null;
  productLinks?: ProductLinks;
  program?: string | null;
  program_categories?: Array<ProgramCategory> | null;
  program_eventId?: string | null;
  program_eventUrl?: string | null;
  program_firstPresented?: string;
  program_language?: string | null;
  program_originalAirDate?: string;
  program_shortTitle?: string | null;
  properties?: Properties;
  start?: string;
  webAiringLink?: string | null;
  webGameLink?: string | null;
  withinPlayWindow?: boolean;
}
