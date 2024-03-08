import { Injectable } from '@angular/core';
import { Observable, map, shareReplay } from 'rxjs';
import { EspnApiService } from './espn-api.service';

@Injectable({
  providedIn: 'root'
})
export class BasketballConferencesService {

  public conferences$ = this.espnApiService.getConferences()
    .pipe(
      shareReplay(1),
      map(result => result.conferences),
    );

  constructor(private espnApiService: EspnApiService) { }

  public getConferenceName(conferenceId: string): Observable<string | null> {
    return this.conferences$.pipe(
      map(conferences => conferences?.find(conference => conference.uid === conferenceId)?.name ?? conferenceId)
    );
  }
}
