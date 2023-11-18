/* tslint:disable */
/* eslint-disable */
import { Address } from '../models/address';
export interface Venue {
  address?: Address;
  capacity?: number;
  fullName?: string | null;
  id?: number;
  indoor?: boolean;
}
