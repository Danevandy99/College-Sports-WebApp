import { Injectable } from '@angular/core';
import { map, shareReplay } from 'rxjs';
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
}
