/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { StrictHttpResponse } from '../../strict-http-response';
import { RequestBuilder } from '../../request-builder';

import { ScoreBasic } from '../../models/score-basic';

export interface ApiSportsDataApiScoresByDateGet$Json$Params {
  date?: string;
}

export function apiSportsDataApiScoresByDateGet$Json(http: HttpClient, rootUrl: string, params?: ApiSportsDataApiScoresByDateGet$Json$Params, context?: HttpContext): Observable<StrictHttpResponse<Array<ScoreBasic>>> {
  const rb = new RequestBuilder(rootUrl, apiSportsDataApiScoresByDateGet$Json.PATH, 'get');
  if (params) {
    rb.query('date', params.date, {});
  }

  return http.request(
    rb.build({ responseType: 'json', accept: 'text/json', context })
  ).pipe(
    filter((r: any): r is HttpResponse<any> => r instanceof HttpResponse),
    map((r: HttpResponse<any>) => {
      return r as StrictHttpResponse<Array<ScoreBasic>>;
    })
  );
}

apiSportsDataApiScoresByDateGet$Json.PATH = '/api/SportsDataApi/scores-by-date';
