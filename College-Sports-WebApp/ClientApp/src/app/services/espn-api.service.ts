import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { Observable } from "rxjs";
import { ScoreboardResult } from "../models/scoreboard-result";
import { ConferencesResult } from "../models/conferences-result";
import { QueryObserverResult, injectQuery } from "@ngneat/query";
import { Result } from "@ngneat/query/lib/types";

@Injectable({
  providedIn: 'root'
})
export class EspnApiService {
  private readonly httpClient = inject(HttpClient);
  private readonly query = injectQuery();

  public getScoreboard(date: Date): Result<QueryObserverResult<ScoreboardResult, Error>> {
    // Date as yyyyMMdd
    const dateString = date.toISOString().split('T')[0].replace(/-/g, '');

    const url = `https://site.web.api.espn.com/apis/site/v2/sports/basketball/mens-college-basketball/scoreboard?region=us&lang=en&contentorigin=espn&limit=300&calendartype=offdays&includeModules=videos&dates=${dateString}&groups=50&tz=America%2FNew_York&buyWindow=1m&showAirings=live&showZipLookup=true`

    return this.query({
      queryKey: ['scoreboard', dateString],
      queryFn: () => {
        return this.httpClient.get<ScoreboardResult>(url);
      },
      staleTime: 10000, // 10 seconds,
    })
  }

  public getConferences(): Observable<ConferencesResult> {
    const url = "https://site.web.api.espn.com/apis/site/v2/sports/basketball/mens-college-basketball/scoreboard/conferences?groups=50";

    return this.httpClient.get<ConferencesResult>(url);
  }
}
