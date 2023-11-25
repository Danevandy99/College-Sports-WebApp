/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';

import { apiEspnApiConferencesGet$Json } from '../fn/espn-api/api-espn-api-conferences-get-json';
import { ApiEspnApiConferencesGet$Json$Params } from '../fn/espn-api/api-espn-api-conferences-get-json';
import { apiEspnApiConferencesGet$Plain } from '../fn/espn-api/api-espn-api-conferences-get-plain';
import { ApiEspnApiConferencesGet$Plain$Params } from '../fn/espn-api/api-espn-api-conferences-get-plain';
import { apiEspnApiScoreboardGet$Json } from '../fn/espn-api/api-espn-api-scoreboard-get-json';
import { ApiEspnApiScoreboardGet$Json$Params } from '../fn/espn-api/api-espn-api-scoreboard-get-json';
import { apiEspnApiScoreboardGet$Plain } from '../fn/espn-api/api-espn-api-scoreboard-get-plain';
import { ApiEspnApiScoreboardGet$Plain$Params } from '../fn/espn-api/api-espn-api-scoreboard-get-plain';
import { ConferencesResult } from '../models/conferences-result';
import { ScoreboardResult } from '../models/scoreboard-result';

@Injectable({ providedIn: 'root' })
export class EspnApiService extends BaseService {
  constructor(config: ApiConfiguration, http: HttpClient) {
    super(config, http);
  }

  /** Path part for operation `apiEspnApiConferencesGet()` */
  static readonly ApiEspnApiConferencesGetPath = '/api/ESPNApi/conferences';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEspnApiConferencesGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEspnApiConferencesGet$Plain$Response(params?: ApiEspnApiConferencesGet$Plain$Params, context?: HttpContext): Observable<StrictHttpResponse<ConferencesResult>> {
    return apiEspnApiConferencesGet$Plain(this.http, this.rootUrl, params, context);
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiEspnApiConferencesGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEspnApiConferencesGet$Plain(params?: ApiEspnApiConferencesGet$Plain$Params, context?: HttpContext): Observable<ConferencesResult> {
    return this.apiEspnApiConferencesGet$Plain$Response(params, context).pipe(
      map((r: StrictHttpResponse<ConferencesResult>): ConferencesResult => r.body)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEspnApiConferencesGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEspnApiConferencesGet$Json$Response(params?: ApiEspnApiConferencesGet$Json$Params, context?: HttpContext): Observable<StrictHttpResponse<ConferencesResult>> {
    return apiEspnApiConferencesGet$Json(this.http, this.rootUrl, params, context);
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiEspnApiConferencesGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEspnApiConferencesGet$Json(params?: ApiEspnApiConferencesGet$Json$Params, context?: HttpContext): Observable<ConferencesResult> {
    return this.apiEspnApiConferencesGet$Json$Response(params, context).pipe(
      map((r: StrictHttpResponse<ConferencesResult>): ConferencesResult => r.body)
    );
  }

  /** Path part for operation `apiEspnApiScoreboardGet()` */
  static readonly ApiEspnApiScoreboardGetPath = '/api/ESPNApi/scoreboard';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEspnApiScoreboardGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEspnApiScoreboardGet$Plain$Response(params?: ApiEspnApiScoreboardGet$Plain$Params, context?: HttpContext): Observable<StrictHttpResponse<ScoreboardResult>> {
    return apiEspnApiScoreboardGet$Plain(this.http, this.rootUrl, params, context);
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiEspnApiScoreboardGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEspnApiScoreboardGet$Plain(params?: ApiEspnApiScoreboardGet$Plain$Params, context?: HttpContext): Observable<ScoreboardResult> {
    return this.apiEspnApiScoreboardGet$Plain$Response(params, context).pipe(
      map((r: StrictHttpResponse<ScoreboardResult>): ScoreboardResult => r.body)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiEspnApiScoreboardGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEspnApiScoreboardGet$Json$Response(params?: ApiEspnApiScoreboardGet$Json$Params, context?: HttpContext): Observable<StrictHttpResponse<ScoreboardResult>> {
    return apiEspnApiScoreboardGet$Json(this.http, this.rootUrl, params, context);
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiEspnApiScoreboardGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiEspnApiScoreboardGet$Json(params?: ApiEspnApiScoreboardGet$Json$Params, context?: HttpContext): Observable<ScoreboardResult> {
    return this.apiEspnApiScoreboardGet$Json$Response(params, context).pipe(
      map((r: StrictHttpResponse<ScoreboardResult>): ScoreboardResult => r.body)
    );
  }

}
