/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { StrictHttpResponse } from '../../strict-http-response';
import { RequestBuilder } from '../../request-builder';

import { ConferencesResult } from '../../models/conferences-result';

export interface ApiEspnApiConferencesGet$Json$Params {
}

export function apiEspnApiConferencesGet$Json(http: HttpClient, rootUrl: string, params?: ApiEspnApiConferencesGet$Json$Params, context?: HttpContext): Observable<StrictHttpResponse<ConferencesResult>> {
  const rb = new RequestBuilder(rootUrl, apiEspnApiConferencesGet$Json.PATH, 'get');
  if (params) {
  }

  return http.request(
    rb.build({ responseType: 'json', accept: 'text/json', context })
  ).pipe(
    filter((r: any): r is HttpResponse<any> => r instanceof HttpResponse),
    map((r: HttpResponse<any>) => {
      return r as StrictHttpResponse<ConferencesResult>;
    })
  );
}

apiEspnApiConferencesGet$Json.PATH = '/api/ESPNApi/conferences';
