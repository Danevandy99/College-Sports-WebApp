import { Component, Input, computed, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Event } from 'src/api/models';
import { Utility } from 'src/utility';

@Component({
  selector: 'app-watch-button',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './watch-button.component.html',
  styleUrl: './watch-button.component.css'
})
export class WatchButtonComponent {

  protected game = signal<Event | null>(null);
  @Input('game') set _game(value: Event) {
    this.game.set(value);
  }

  protected channelName = computed(() => {
    const game = this.game();

    if (!game) {
      return '';
    }

    return game.competitions?.at(0)?.broadcasts?.at(0)?.names?.at(0);
  });

  protected isGameFinished = computed(() => {
    const game = this.game();

    if (!game) {
      return false;
    }

    return Utility.isGameFinished(game);
  });

  protected isGameLive = computed(() => {
    const game = this.game();

    if (!game) {
      return false;
    }

    return Utility.isGameLive(game);
  });

  protected linkToWatch = computed(() => {
    const game = this.game();
    const channelName = this.channelName();

    if (!game || !channelName) {
      return ';'
    }

    switch (channelName) {
      case "ESPN":
      case "ESPN2":
      case "ESPN+":
      case "BIG12|ESPN+":
        const airing = game.competitions?.at(0)?.airings?.at(0);

        if (!airing) {
          return 'https://www.espn.com/watch/'
        }

        if (Utility.isMobileDevice()) {
          return airing.appGameLink;
        } else {
          return airing.webGameLink;
        }
      case "CBSSN":
        return "https://www.cbssports.com/watch/college-basketball";
      case "FS1":
        return "https://www.foxsports.com/live/fs1";
      case "BTN":
        return "https://www.foxsports.com/live/btn";
      default:
        return 'https://www.espn.com/watch/';
    }
  });

  protected getChannelColorClasses(channelName?: string | null): string {
    switch (channelName) {
      case "ESPN":
      case "ESPN2":
        return "bg-red-500 text-white";
      case "ESPN+":
      case "BIG12|ESPN+":
        return "bg-yellow-400 text-black";
      case "ESPNU":
        return "bg-black text-red-500";
      case "FS1":
        return "bg-blue-900 text-white";
      case "BTN":
        return "bg-sky-600 text-white";
      case "CBSSN":
        return "bg-blue-700 text-white";
      default:
        return "bg-purple-500 text-white";
    }
  }
}
