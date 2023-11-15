/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { StrictHttpResponse } from '../../strict-http-response';
import { RequestBuilder } from '../../request-builder';

import { ScoreBasic } from '../../models/score-basic';

export interface ApiSportsDataApiScoresByDateGet$Plain$Params {
  date?: string;
}

export function apiSportsDataApiScoresByDateGet$Plain(http: HttpClient, rootUrl: string, params?: ApiSportsDataApiScoresByDateGet$Plain$Params, context?: HttpContext): Observable<StrictHttpResponse<Array<ScoreBasic>>> {
  const rb = new RequestBuilder(rootUrl, apiSportsDataApiScoresByDateGet$Plain.PATH, 'get');
  if (params) {
    rb.query('date', params.date, {});
  }

  return http.request(
    rb.build({ responseType: 'text', accept: 'text/plain', context })
  ).pipe(
    filter((r: any): r is HttpResponse<any> => r instanceof HttpResponse),
    map((r: HttpResponse<any>) => {
      return r as StrictHttpResponse<Array<ScoreBasic>>;
    })
  );
}

apiSportsDataApiScoresByDateGet$Plain.PATH = '/api/SportsDataApi/scores-by-date';
