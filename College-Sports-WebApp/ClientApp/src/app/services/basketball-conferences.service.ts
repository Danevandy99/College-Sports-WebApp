import { EspnApiService } from './../../api/services/espn-api.service';
import { Injectable } from '@angular/core';
import { map, shareReplay } from 'rxjs';
import { Conference } from 'src/api/models';

@Injectable({
  providedIn: 'root'
})
export class BasketballConferencesService {

  public conferences$ = this.espnApiService.apiEspnApiConferencesGet$Json()
    .pipe(
      shareReplay(1),
      map(result => result.conferences),
    );

  constructor(private espnApiService: EspnApiService) { }
}
