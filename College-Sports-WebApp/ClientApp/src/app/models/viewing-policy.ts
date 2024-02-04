/* tslint:disable */
/* eslint-disable */
import { Audience } from './audience';
export interface ViewingPolicy {
  actions?: Array<string> | null;
  audience?: Audience;
  externalId?: string | null;
  id?: string | null;
  name?: string | null;
}
