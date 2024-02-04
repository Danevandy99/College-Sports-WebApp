import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ScoreboardResult } from "../models/scoreboard-result";
import { ConferencesResult } from "../models/conferences-result";

@Injectable({
  providedIn: 'root'
})
export class EspnApiService {
  constructor(private httpClient: HttpClient) { }

  public getScoreboard(date: Date): Observable<ScoreboardResult> {
    // Date as yyyyMMdd
    const dateString = date.toISOString().split('T')[0].replace(/-/g, '');

    const url = `https://site.web.api.espn.com/apis/site/v2/sports/basketball/mens-college-basketball/scoreboard?region=us&lang=en&contentorigin=espn&limit=300&calendartype=offdays&includeModules=videos&dates=${dateString}&groups=50&tz=America%2FNew_York&buyWindow=1m&showAirings=live&showZipLookup=true`

    return this.httpClient.get<ScoreboardResult>(url);
  }

  public getConferences(): Observable<ConferencesResult> {
    const url = "https://site.web.api.espn.com/apis/site/v2/sports/basketball/mens-college-basketball/scoreboard/conferences?groups=50";

    return this.httpClient.get<ConferencesResult>(url);
  }
}
