/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';

import { apiSportsDataApiScoresByDateGet$Json } from '../fn/sports-data-api/api-sports-data-api-scores-by-date-get-json';
import { ApiSportsDataApiScoresByDateGet$Json$Params } from '../fn/sports-data-api/api-sports-data-api-scores-by-date-get-json';
import { apiSportsDataApiScoresByDateGet$Plain } from '../fn/sports-data-api/api-sports-data-api-scores-by-date-get-plain';
import { ApiSportsDataApiScoresByDateGet$Plain$Params } from '../fn/sports-data-api/api-sports-data-api-scores-by-date-get-plain';
import { ScoreBasic } from '../models/score-basic';

@Injectable({ providedIn: 'root' })
export class SportsDataApiService extends BaseService {
  constructor(config: ApiConfiguration, http: HttpClient) {
    super(config, http);
  }

  /** Path part for operation `apiSportsDataApiScoresByDateGet()` */
  static readonly ApiSportsDataApiScoresByDateGetPath = '/api/SportsDataApi/scores-by-date';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiSportsDataApiScoresByDateGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiSportsDataApiScoresByDateGet$Plain$Response(params?: ApiSportsDataApiScoresByDateGet$Plain$Params, context?: HttpContext): Observable<StrictHttpResponse<Array<ScoreBasic>>> {
    return apiSportsDataApiScoresByDateGet$Plain(this.http, this.rootUrl, params, context);
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiSportsDataApiScoresByDateGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiSportsDataApiScoresByDateGet$Plain(params?: ApiSportsDataApiScoresByDateGet$Plain$Params, context?: HttpContext): Observable<Array<ScoreBasic>> {
    return this.apiSportsDataApiScoresByDateGet$Plain$Response(params, context).pipe(
      map((r: StrictHttpResponse<Array<ScoreBasic>>): Array<ScoreBasic> => r.body)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiSportsDataApiScoresByDateGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiSportsDataApiScoresByDateGet$Json$Response(params?: ApiSportsDataApiScoresByDateGet$Json$Params, context?: HttpContext): Observable<StrictHttpResponse<Array<ScoreBasic>>> {
    return apiSportsDataApiScoresByDateGet$Json(this.http, this.rootUrl, params, context);
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiSportsDataApiScoresByDateGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiSportsDataApiScoresByDateGet$Json(params?: ApiSportsDataApiScoresByDateGet$Json$Params, context?: HttpContext): Observable<Array<ScoreBasic>> {
    return this.apiSportsDataApiScoresByDateGet$Json$Response(params, context).pipe(
      map((r: StrictHttpResponse<Array<ScoreBasic>>): Array<ScoreBasic> => r.body)
    );
  }

}
