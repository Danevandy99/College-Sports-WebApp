/* tslint:disable */
/* eslint-disable */
import { ViewingPolicy } from '../models/viewing-policy';
export interface Policy {
  createdBy?: string | null;
  createdOn?: string;
  id?: string | null;
  lastModifiedBy?: string | null;
  lastModifiedOn?: string;
  viewingPolicies?: Array<ViewingPolicy> | null;
}
