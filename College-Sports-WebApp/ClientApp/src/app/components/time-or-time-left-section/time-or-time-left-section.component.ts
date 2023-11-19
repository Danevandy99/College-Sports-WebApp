import { Component, Input, OnInit, computed, signal } from '@angular/core';
import { Event } from 'src/api/models';
import { Utility } from 'src/utility';

@Component({
  selector: 'app-time-or-time-left-section',
  templateUrl: './time-or-time-left-section.component.html',
  styleUrls: ['./time-or-time-left-section.component.css']
})
export class TimeOrTimeLeftSectionComponent implements OnInit {

  protected _game = signal<Event | null>(null);
  @Input() set game(value: Event) {
    this._game.set(value);
  };

  protected isGameLive = computed(() => {
    const game = this._game();
    if (!game) {
      return false;
    }

    return Utility.isGameLive(game);
  });

  protected isGameFinished = computed(() => {
    const game = this._game();
    if (!game) {
      return false;
    }

    return Utility.isGameFinished(game);
  });

  protected isGameScheduled = computed(() => {
    const game = this._game();
    if (!game) {
      return false;
    }

    return Utility.isGameScheduled(game);
  });

  protected periodDisplayName = computed(() => {
    const game = this._game();
    if (!game) {
      return '';
    }

    return Utility.getPeriodDisplayName(game);
  });

  protected percentageOfGameRemaining = computed(() => {
    const game = this._game();
    if (!game) {
      return 0;
    }

    return Utility.getPercentageOfGameRemaining(game);
  });

  protected progressBarWidth = computed(() => {
    const percentageOfGameRemaining = this.percentageOfGameRemaining();
    return `${percentageOfGameRemaining * 100}%`;
  });

  constructor() { }

  ngOnInit() {

  }
}
