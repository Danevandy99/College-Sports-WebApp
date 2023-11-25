/* tslint:disable */
/* eslint-disable */
import { Audience } from '../models/audience';
export interface ViewingPolicy {
  actions?: Array<string> | null;
  audience?: Audience;
  externalId?: string | null;
  id?: string | null;
  name?: string | null;
}
