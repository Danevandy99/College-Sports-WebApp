/* tslint:disable */
/* eslint-disable */
import { Audience } from '../models/audience';
export interface ViewingPolicy {
  actions?: Array<string> | null;
  audience?: Audience;
  externalId?: string | null;
  id?: number;
  name?: string | null;
}
