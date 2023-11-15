/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { StrictHttpResponse } from '../../strict-http-response';
import { RequestBuilder } from '../../request-builder';

import { ScoreboardResult } from '../../models/scoreboard-result';

export interface ApiEspnApiScoreboardGet$Json$Params {
  filterDate?: string;
}

export function apiEspnApiScoreboardGet$Json(http: HttpClient, rootUrl: string, params?: ApiEspnApiScoreboardGet$Json$Params, context?: HttpContext): Observable<StrictHttpResponse<ScoreboardResult>> {
  const rb = new RequestBuilder(rootUrl, apiEspnApiScoreboardGet$Json.PATH, 'get');
  if (params) {
    rb.query('filterDate', params.filterDate, {});
  }

  return http.request(
    rb.build({ responseType: 'json', accept: 'text/json', context })
  ).pipe(
    filter((r: any): r is HttpResponse<any> => r instanceof HttpResponse),
    map((r: HttpResponse<any>) => {
      return r as StrictHttpResponse<ScoreboardResult>;
    })
  );
}

apiEspnApiScoreboardGet$Json.PATH = '/api/ESPNApi/scoreboard';
