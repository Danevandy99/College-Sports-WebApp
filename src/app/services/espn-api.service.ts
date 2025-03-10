import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { Observable } from "rxjs";
import { ScoreboardResult } from "../models/scoreboard-result";
import { ConferencesResult } from "../models/conferences-result";
import { QueryObserverResult, injectQuery, injectQueryClient, queryOptions } from "@ngneat/query";
import { Result } from "@ngneat/query/lib/types";
import { EventSummary } from "../models/event-summary";

@Injectable({
  providedIn: 'root'
})
export class EspnApiService {
  private readonly httpClient = inject(HttpClient);
  private readonly query = injectQuery();

  public getScoreboardQueryOptions(date: Date) {
    return queryOptions({
      queryKey: ['scoreboard', date],
      queryFn: () => {
        // Date as yyyyMMdd
        const dateString = date.toISOString().split('T')[0].replace(/-/g, '');

        const url = `https://site.web.api.espn.com/apis/site/v2/sports/basketball/mens-college-basketball/scoreboard?region=us&lang=en&contentorigin=espn&limit=300&calendartype=offdays&includeModules=videos&dates=${dateString}&groups=50&tz=America%2FNew_York&buyWindow=1m&showAirings=live&showZipLookup=true`

        return this.httpClient.get<ScoreboardResult>(url);
      },
      staleTime: 10000, // 10 seconds,
    });
  }

  public getScoreboard(date: Date): Result<QueryObserverResult<ScoreboardResult, Error>> {
    return this.query(this.getScoreboardQueryOptions(date));
  }

  public getConferences(): Observable<ConferencesResult> {
    const url = "https://site.web.api.espn.com/apis/site/v2/sports/basketball/mens-college-basketball/scoreboard/conferences?groups=50";

    return this.httpClient.get<ConferencesResult>(url);
  }

  public getSummary(eventId: number): Result<QueryObserverResult<EventSummary, Error>> {
    const url = `https://site.web.api.espn.com/apis/site/v2/sports/basketball/mens-college-basketball/summary?region=us&lang=en&contentorigin=espn&event=${eventId}`;

    return this.query({
      queryKey: ['summary', eventId],
      queryFn: () => {
        return this.httpClient.get<EventSummary>(url);
      },
      staleTime: 10000, // 10 seconds,
    });
  }
}
