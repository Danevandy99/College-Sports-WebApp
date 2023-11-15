import { EspnApiService } from './../api/services/espn-api.service';
import { Component, signal } from '@angular/core';
import { toObservable, toSignal } from '@angular/core/rxjs-interop';
import { switchMap } from 'rxjs';
import { ApiEspnApiScoreboardGet$Json$Params } from 'src/api/fn/espn-api/api-espn-api-scoreboard-get-json';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  protected date = signal(new Date());

  protected scoreboardResult = toSignal(toObservable(this.date).pipe(
    switchMap(date => {
      const data: ApiEspnApiScoreboardGet$Json$Params = { filterDate: date.toDateString() };

      return this.espnApiService.apiEspnApiScoreboardGet$Json(data)
    })
  ));

  constructor(private espnApiService: EspnApiService) { }
}
