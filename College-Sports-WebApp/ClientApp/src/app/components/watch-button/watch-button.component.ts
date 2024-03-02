import { Component, Input, computed, input, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Utility } from 'src/utility';
import { Event } from '../../models/event';

@Component({
  selector: 'app-watch-button',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './watch-button.component.html',
  styleUrl: './watch-button.component.css'
})
export class WatchButtonComponent {

  public game = input<Event | null>(null);

  protected isLoading = computed(() => !this.game());

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
      case "ESPN3":
      case "ESPNNEWS":
      case "ESPN+":
      case "BIG12|ESPN+":
      case "ACCN":
      case "ACCNX":
      case "SECN":
      case "SECN+":
      case "PAC12":
      case "LHN":
      case "ABC":
        const airing = game.competitions?.at(0)?.airings?.at(0);

        if (!airing) {
          return 'https://www.espn.com/watch/'
        }

        if (Utility.isMobileDevice()) {
          return airing.appGameLink;
        } else {
          return airing.webGameLink;
        }
      case "CBS":
      case "CBSSN":
        return "https://www.cbssports.com/watch/college-basketball";
      case "FS1":
        return "https://www.foxsports.com/live/fs1";
      case "FS2":
        return "https://www.foxsports.com/live/fs2";
      case "BTN":
        return "https://www.foxsports.com/live/btn";
      case "CW NETWORK":
        return "https://www.cwtv.com/";
      default:
        return 'https://www.espn.com/watch/';
    }
  });

   protected channelColorClasses = computed(() => {
    switch (this.channelName()) {
      case "ESPN":
      case "ESPN2":
      case "ESPN3":
      case "ESPNNEWS":
        return "bg-red-500 text-white dark:bg-red-600 dark:text-red-900 ";
      case "ESPN+":
      case "BIG12|ESPN+":
        return "bg-yellow-400 text-black dark:bg-yellow-500 dark:text-yellow-900";
      case "ESPNU":
        return "bg-black text-red-500 hover:text-red-500";
      case "FOX":
      case "FS1":
      case "FS2":
      case "ACCN":
      case "ACCNX":
        return "bg-blue-900 text-white";
      case "BTN":
        return "bg-sky-600 text-white";
      case "CBS":
      case "CBSSN":
        return "bg-blue-700 text-white";
      case "SECN":
      case "SECN+":
        return "bg-[#004b8d] text-[#ffd046] hover:text-[#ffd046]";
      case "PAC12":
        return "bg-[#004b91] text-[#fff] hover:text-[#fff]";
      case "LHN":
        return "bg-[#bf5700] text-white hover:text-white";
      case "ABC":
        return "bg-[#000] text-[#fff] dark:bg-[#fff] dark:text-[#000] dark:hover:text-[#000] dark:hover:bg-[#fff] hover:text-[#fff] hover:bg-[#000]";
      case "CW NETWORK":
        return "bg-[#ff4500] text-[#fff] hover:text-[#fff] dark:bg-[#de3d01] dark:text-[#000] dark:hover:text-[#000]";
      default:
        return "bg-purple-500 text-white";
    }
  });
}
