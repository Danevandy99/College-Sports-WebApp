/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';

import { apiEspnApiScoreboardGet$Json } from '../fn/espn-api/api-espn-api-scoreboard-get-json';
import { ApiEspnApiScoreboardGet$Json$Params } from '../fn/espn-api/api-espn-api-scoreboard-get-json';
import { apiEspnApiScoreboardGet$Plain } from '../fn/espn-api/api-espn-api-scoreboard-get-plain';
import { ApiEspnApiScoreboardGet$Plain$Params } from '../fn/espn-api/api-espn-api-scoreboard-get-plain';
import { ScoreboardResult } from '../models/scoreboard-result';

@Injectable({ providedIn: 'root' })
export class EspnApiService extends BaseService {
  constructor(config: ApiConfiguration, http: HttpClient) {
    super(config, http);
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
