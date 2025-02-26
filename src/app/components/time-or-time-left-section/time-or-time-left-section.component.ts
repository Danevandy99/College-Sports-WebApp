import { Component, Input, OnInit, computed, input, signal } from '@angular/core';
import { Event } from '../../models/event';
import { Utility } from 'src/utility';
import { DatePipe, NgStyle } from '@angular/common';

@Component({
  standalone: true,
  imports: [
    DatePipe,
    NgStyle,
  ],
  selector: 'app-time-or-time-left-section',
  templateUrl: './time-or-time-left-section.component.html',
  styleUrls: ['./time-or-time-left-section.component.css']
})
export class TimeOrTimeLeftSectionComponent implements OnInit {

  public game = input<Event | null>(null);

  protected isGameLive = computed(() => {
    const game = this.game();
    if (!game) {
      return false;
    }

    return Utility.isGameLive(game);
  });

  protected isGameFinished = computed(() => {
    const game = this.game();
    if (!game) {
      return false;
    }

    return Utility.isGameFinished(game);
  });

  protected isGameScheduled = computed(() => {
    const game = this.game();
    if (!game) {
      return false;
    }

    return Utility.isGameScheduled(game);
  });

  protected liveGameText = computed(() => {
    const game  = this.game();

    if (!game) {
      return '';
    }

    if (Utility.isGameAtHalftime(game)) {
      return 'Halftime';
    } else if (Utility.isGameAtEndOfRegulation(game)) {
      return 'End of Regulation';
    } else {
      return `${game?.status?.displayClock} - ${this.periodDisplayName()}`
    }
  });


  protected periodDisplayName = computed(() => {
    const game = this.game();
    if (!game) {
      return '';
    }

    return Utility.getPeriodDisplayName(game);
  });

  protected percentageOfGameRemaining = computed(() => {
    const game = this.game();
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
